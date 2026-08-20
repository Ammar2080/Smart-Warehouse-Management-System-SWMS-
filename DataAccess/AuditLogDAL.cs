using System;
using System.Data.SqlClient;
using WarehouseManagement.Models;

namespace WarehouseManagement.DataAccess
{
    public class AuditLogDAL
    {
        public static void LogAction(int userId, string action, string tableName, int recordId, string details)
        {
            try
            {
                string query = @"INSERT INTO AuditLogs (UserId, Action, TableName, RecordId, Details, IpAddress)
                                 VALUES (@UserId, @Action, @TableName, @RecordId, @Details, @Ip)";

                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@Action", action);
                        cmd.Parameters.AddWithValue("@TableName", (object)tableName ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@RecordId", recordId);
                        cmd.Parameters.AddWithValue("@Details", (object)details ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Ip", "127.0.0.1");

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Fail silently or log to file to prevent disrupting main transaction
                Console.WriteLine("Audit Log Error: " + ex.Message);
            }
        }
    }
}
