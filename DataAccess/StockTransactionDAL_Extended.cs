using System;
using System.Data.SqlClient;
using WarehouseManagement.Models;

namespace WarehouseManagement.DataAccess
{
    public partial class StockTransactionDAL
    {
        public bool InsertStockOut(StockOut stockOut)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Check stock availability before issuing
                        foreach (var detail in stockOut.Details)
                        {
                            string checkStock = "SELECT Quantity FROM WarehouseStock WHERE WarehouseId = @WH AND ProductId = @Prod";
                            decimal currentQty = 0;
                            using (SqlCommand cmd = new SqlCommand(checkStock, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@WH", stockOut.WarehouseId);
                                cmd.Parameters.AddWithValue("@Prod", detail.ProductId);
                                object result = cmd.ExecuteScalar();
                                if (result != null) currentQty = Convert.ToDecimal(result);
                            }

                            if (currentQty < detail.Quantity)
                            {
                                throw new InvalidOperationException($"Insufficient stock for Product ID {detail.ProductId}. Available: {currentQty}, Required: {detail.Quantity}");
                            }
                        }

                        // 2. Insert StockOut Header
                        string headerQuery = @"INSERT INTO StockOut (InvoiceNumber, CustomerId, WarehouseId, UserId, TotalAmount, Notes)
                                               OUTPUT INSERTED.StockOutId
                                               VALUES (@Invoice, @CustomerId, @WarehouseId, @UserId, @Total, @Notes)";

                        int stockOutId = 0;
                        using (SqlCommand cmd = new SqlCommand(headerQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Invoice", stockOut.InvoiceNumber);
                            cmd.Parameters.AddWithValue("@CustomerId", stockOut.CustomerId);
                            cmd.Parameters.AddWithValue("@WarehouseId", stockOut.WarehouseId);
                            cmd.Parameters.AddWithValue("@UserId", stockOut.UserId);
                            cmd.Parameters.AddWithValue("@Total", stockOut.TotalAmount);
                            cmd.Parameters.AddWithValue("@Notes", (object)stockOut.Notes ?? DBNull.Value);

                            stockOutId = (int)cmd.ExecuteScalar();
                        }

                        // 3. Insert Details & Decrease Warehouse Stock
                        foreach (var detail in stockOut.Details)
                        {
                            string detailQuery = @"INSERT INTO StockOutDetails (StockOutId, ProductId, Quantity, UnitPrice, TotalPrice)
                                                   VALUES (@StockOutId, @ProductId, @Qty, @Price, @Total)";

                            using (SqlCommand cmd = new SqlCommand(detailQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@StockOutId", stockOutId);
                                cmd.Parameters.AddWithValue("@ProductId", detail.ProductId);
                                cmd.Parameters.AddWithValue("@Qty", detail.Quantity);
                                cmd.Parameters.AddWithValue("@Price", detail.UnitPrice);
                                cmd.Parameters.AddWithValue("@Total", detail.Quantity * detail.UnitPrice);
                                cmd.ExecuteNonQuery();
                            }

                            string updateStock = "UPDATE WarehouseStock SET Quantity = Quantity - @Qty, LastUpdated = GETDATE() WHERE WarehouseId = @WH AND ProductId = @Prod";
                            using (SqlCommand cmd = new SqlCommand(updateStock, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Qty", detail.Quantity);
                                cmd.Parameters.AddWithValue("@WH", stockOut.WarehouseId);
                                cmd.Parameters.AddWithValue("@Prod", detail.ProductId);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
