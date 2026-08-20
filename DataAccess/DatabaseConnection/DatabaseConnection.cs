using System;
using System.Configuration;
using System.Data.SqlClient;

namespace WarehouseManagement.DataAccess
{
    public class DatabaseConnection
    {
        private static readonly string connectionString = 
            ConfigurationManager.ConnectionStrings["WarehouseDB"]?.ConnectionString ?? 
            @"Server=localhost;Database=WarehouseManagementDB;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection Error: " + ex.Message);
                return false;
            }
        }
    }
}
