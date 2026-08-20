using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WarehouseManagement.Models;

namespace WarehouseManagement.DataAccess
{
    public class WarehouseDAL
    {
        public List<Warehouse> GetAllWarehouses()
        {
            List<Warehouse> warehouses = new List<Warehouse>();
            string query = "SELECT * FROM Warehouses WHERE IsActive = 1";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            warehouses.Add(new Warehouse
                            {
                                WarehouseId = Convert.ToInt32(reader["WarehouseId"]),
                                WarehouseCode = reader["WarehouseCode"].ToString(),
                                WarehouseName = reader["WarehouseName"].ToString(),
                                Location = reader["Location"]?.ToString(),
                                ManagerName = reader["ManagerName"]?.ToString(),
                                Phone = reader["Phone"]?.ToString(),
                                Description = reader["Description"]?.ToString(),
                                IsActive = Convert.ToBoolean(reader["IsActive"]),
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                            });
                        }
                    }
                }
            }
            return warehouses;
        }
    }

    public class InventoryDAL
    {
        public List<InventoryItem> GetWarehouseStock(int warehouseId)
        {
            List<InventoryItem> items = new List<InventoryItem>();
            string query = @"SELECT ws.*, w.WarehouseName, p.ProductCode, p.ProductName 
                             FROM WarehouseStock ws
                             INNER JOIN Warehouses w ON ws.WarehouseId = w.WarehouseId
                             INNER JOIN Products p ON ws.ProductId = p.ProductId
                             WHERE ws.WarehouseId = @WarehouseId";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@WarehouseId", warehouseId);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(new InventoryItem
                            {
                                WarehouseStockId = Convert.ToInt32(reader["WarehouseStockId"]),
                                WarehouseId = Convert.ToInt32(reader["WarehouseId"]),
                                WarehouseName = reader["WarehouseName"].ToString(),
                                ProductId = Convert.ToInt32(reader["ProductId"]),
                                ProductCode = reader["ProductCode"].ToString(),
                                ProductName = reader["ProductName"].ToString(),
                                Quantity = Convert.ToDecimal(reader["Quantity"]),
                                LastUpdated = Convert.ToDateTime(reader["LastUpdated"])
                            });
                        }
                    }
                }
            }
            return items;
        }
    }
}
