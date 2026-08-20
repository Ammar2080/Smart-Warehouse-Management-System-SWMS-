using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WarehouseManagement.Models;

namespace WarehouseManagement.DataAccess
{
    public class ProductDAL
    {
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            string query = @"SELECT p.*, c.CategoryName, u.UnitName 
                             FROM Products p 
                             LEFT JOIN Categories c ON p.CategoryId = c.CategoryId 
                             LEFT JOIN Units u ON p.UnitId = u.UnitId 
                             WHERE p.IsActive = 1";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product
                            {
                                ProductId = Convert.ToInt32(reader["ProductId"]),
                                ProductCode = reader["ProductCode"].ToString(),
                                Barcode = reader["Barcode"]?.ToString(),
                                ProductName = reader["ProductName"].ToString(),
                                Description = reader["Description"]?.ToString(),
                                CategoryId = Convert.ToInt32(reader["CategoryId"]),
                                CategoryName = reader["CategoryName"]?.ToString(),
                                UnitId = Convert.ToInt32(reader["UnitId"]),
                                UnitName = reader["UnitName"]?.ToString(),
                                PurchasePrice = Convert.ToDecimal(reader["PurchasePrice"]),
                                SellingPrice = Convert.ToDecimal(reader["SellingPrice"]),
                                MinimumStock = Convert.ToDecimal(reader["MinimumStock"]),
                                MaximumStock = Convert.ToDecimal(reader["MaximumStock"]),
                                IsActive = Convert.ToBoolean(reader["IsActive"]),
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                                UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"])
                            });
                        }
                    }
                }
            }
            return products;
        }

        public bool InsertProduct(Product product)
        {
            string query = @"INSERT INTO Products (ProductCode, Barcode, ProductName, Description, CategoryId, UnitId, PurchasePrice, SellingPrice, MinimumStock, MaximumStock, IsActive)
                             VALUES (@Code, @Barcode, @Name, @Desc, @CatId, @UnitId, @BuyPrice, @SellPrice, @MinStock, @MaxStock, @IsActive)";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Code", product.ProductCode);
                    cmd.Parameters.AddWithValue("@Barcode", (object)product.Barcode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Name", product.ProductName);
                    cmd.Parameters.AddWithValue("@Desc", (object)product.Description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CatId", product.CategoryId);
                    cmd.Parameters.AddWithValue("@UnitId", product.UnitId);
                    cmd.Parameters.AddWithValue("@BuyPrice", product.PurchasePrice);
                    cmd.Parameters.AddWithValue("@SellPrice", product.SellingPrice);
                    cmd.Parameters.AddWithValue("@MinStock", product.MinimumStock);
                    cmd.Parameters.AddWithValue("@MaxStock", product.MaximumStock);
                    cmd.Parameters.AddWithValue("@IsActive", product.IsActive);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateProduct(Product product)
        {
            string query = @"UPDATE Products SET ProductCode = @Code, Barcode = @Barcode, ProductName = @Name, 
                             Description = @Desc, CategoryId = @CatId, UnitId = @UnitId, 
                             PurchasePrice = @BuyPrice, SellingPrice = @SellPrice, 
                             MinimumStock = @MinStock, MaximumStock = @MaxStock, UpdatedAt = GETDATE()
                             WHERE ProductId = @Id";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", product.ProductId);
                    cmd.Parameters.AddWithValue("@Code", product.ProductCode);
                    cmd.Parameters.AddWithValue("@Barcode", (object)product.Barcode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Name", product.ProductName);
                    cmd.Parameters.AddWithValue("@Desc", (object)product.Description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CatId", product.CategoryId);
                    cmd.Parameters.AddWithValue("@UnitId", product.UnitId);
                    cmd.Parameters.AddWithValue("@BuyPrice", product.PurchasePrice);
                    cmd.Parameters.AddWithValue("@SellPrice", product.SellingPrice);
                    cmd.Parameters.AddWithValue("@MinStock", product.MinimumStock);
                    cmd.Parameters.AddWithValue("@MaxStock", product.MaximumStock);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteProduct(int productId)
        {
            string query = "UPDATE Products SET IsActive = 0 WHERE ProductId = @Id";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", productId);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
