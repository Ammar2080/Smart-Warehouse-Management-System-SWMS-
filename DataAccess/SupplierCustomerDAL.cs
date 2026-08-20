using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WarehouseManagement.Models;

namespace WarehouseManagement.DataAccess
{
    public class SupplierDAL
    {
        public List<Supplier> GetAllSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();
            string query = "SELECT * FROM Suppliers WHERE IsActive = 1";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            suppliers.Add(new Supplier
                            {
                                SupplierId = Convert.ToInt32(reader["SupplierId"]),
                                SupplierCode = reader["SupplierCode"].ToString(),
                                SupplierName = reader["SupplierName"].ToString(),
                                CompanyName = reader["CompanyName"]?.ToString(),
                                Phone = reader["Phone"]?.ToString(),
                                Email = reader["Email"]?.ToString(),
                                Address = reader["Address"]?.ToString(),
                                IsActive = Convert.ToBoolean(reader["IsActive"]),
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                            });
                        }
                    }
                }
            }
            return suppliers;
        }
    }

    public class CustomerDAL
    {
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            string query = "SELECT * FROM Customers WHERE IsActive = 1";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new Customer
                            {
                                CustomerId = Convert.ToInt32(reader["CustomerId"]),
                                CustomerCode = reader["CustomerCode"].ToString(),
                                CustomerName = reader["CustomerName"].ToString(),
                                CompanyName = reader["CompanyName"]?.ToString(),
                                Phone = reader["Phone"]?.ToString(),
                                Email = reader["Email"]?.ToString(),
                                Address = reader["Address"]?.ToString(),
                                IsActive = Convert.ToBoolean(reader["IsActive"]),
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                            });
                        }
                    }
                }
            }
            return customers;
        }
    }
}
