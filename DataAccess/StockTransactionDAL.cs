using System;
using System.Data.SqlClient;
using WarehouseManagement.Models;

namespace WarehouseManagement.DataAccess
{
    public class StockTransactionDAL
    {
        public bool InsertStockIn(StockIn stockIn)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert StockIn Header
                        string headerQuery = @"INSERT INTO StockIn (InvoiceNumber, SupplierId, WarehouseId, UserId, TotalAmount, Notes)
                                               OUTPUT INSERTED.StockInId
                                               VALUES (@Invoice, @SupplierId, @WarehouseId, @UserId, @Total, @Notes)";

                        int stockInId = 0;
                        using (SqlCommand cmd = new SqlCommand(headerQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Invoice", stockIn.InvoiceNumber);
                            cmd.Parameters.AddWithValue("@SupplierId", stockIn.SupplierId);
                            cmd.Parameters.AddWithValue("@WarehouseId", stockIn.WarehouseId);
                            cmd.Parameters.AddWithValue("@UserId", stockIn.UserId);
                            cmd.Parameters.AddWithValue("@Total", stockIn.TotalAmount);
                            cmd.Parameters.AddWithValue("@Notes", (object)stockIn.Notes ?? DBNull.Value);

                            stockInId = (int)cmd.ExecuteScalar();
                        }

                        // 2. Insert Details & Update Warehouse Stock
                        foreach (var detail in stockIn.Details)
                        {
                            string detailQuery = @"INSERT INTO StockInDetails (StockInId, ProductId, Quantity, UnitPrice, TotalPrice)
                                                   VALUES (@StockInId, @ProductId, @Qty, @Price, @Total)";

                            using (SqlCommand cmd = new SqlCommand(detailQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@StockInId", stockInId);
                                cmd.Parameters.AddWithValue("@ProductId", detail.ProductId);
                                cmd.Parameters.AddWithValue("@Qty", detail.Quantity);
                                cmd.Parameters.AddWithValue("@Price", detail.UnitPrice);
                                cmd.Parameters.AddWithValue("@Total", detail.Quantity * detail.UnitPrice);
                                cmd.ExecuteNonQuery();
                            }

                            // Update or Insert into WarehouseStock
                            string stockCheckQuery = "SELECT COUNT(1) FROM WarehouseStock WHERE WarehouseId = @WH AND ProductId = @Prod";
                            int stockExists = 0;
                            using (SqlCommand cmd = new SqlCommand(stockCheckQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@WH", stockIn.WarehouseId);
                                cmd.Parameters.AddWithValue("@Prod", detail.ProductId);
                                stockExists = (int)cmd.ExecuteScalar();
                            }

                            if (stockExists > 0)
                            {
                                string updateStock = "UPDATE WarehouseStock SET Quantity = Quantity + @Qty, LastUpdated = GETDATE() WHERE WarehouseId = @WH AND ProductId = @Prod";
                                using (SqlCommand cmd = new SqlCommand(updateStock, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@Qty", detail.Quantity);
                                    cmd.Parameters.AddWithValue("@WH", stockIn.WarehouseId);
                                    cmd.Parameters.AddWithValue("@Prod", detail.ProductId);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                string insertStock = "INSERT INTO WarehouseStock (WarehouseId, ProductId, Quantity) VALUES (@WH, @Prod, @Qty)";
                                using (SqlCommand cmd = new SqlCommand(insertStock, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@WH", stockIn.WarehouseId);
                                    cmd.Parameters.AddWithValue("@Prod", detail.ProductId);
                                    cmd.Parameters.AddWithValue("@Qty", detail.Quantity);
                                    cmd.ExecuteNonQuery();
                                }
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
