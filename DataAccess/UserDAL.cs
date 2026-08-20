using System;
using System.Data.SqlClient;
using WarehouseManagement.Models;

namespace WarehouseManagement.DataAccess
{
    public class UserDAL
    {
        public User AuthenticateUser(string username, string passwordHash)
        {
            User user = null;
            string query = @"SELECT u.*, r.RoleName 
                             FROM Users u 
                             INNER JOIN Roles r ON u.RoleId = r.RoleId 
                             WHERE u.Username = @Username AND u.PasswordHash = @PasswordHash AND u.IsActive = 1";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                UserId = Convert.ToInt32(reader["UserId"]),
                                Username = reader["Username"].ToString(),
                                FullName = reader["FullName"].ToString(),
                                Email = reader["Email"]?.ToString(),
                                RoleId = Convert.ToInt32(reader["RoleId"]),
                                RoleName = reader["RoleName"].ToString(),
                                IsActive = Convert.ToBoolean(reader["IsActive"]),
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                            };
                        }
                    }
                }
            }
            return user;
        }
    }
}
