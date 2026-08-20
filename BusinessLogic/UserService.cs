using System;
using WarehouseManagement.DataAccess;
using WarehouseManagement.Models;

namespace WarehouseManagement.BusinessLogic
{
    public class UserService
    {
        private readonly UserDAL _userDAL;

        public UserService()
        {
            _userDAL = new UserDAL();
        }

        public User Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be empty.");

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be empty.");

            // In production, use proper hashing (e.g., BCrypt or SHA256). Here we pass direct or hashed string matching DB.
            string passwordHash = password; // Simplified for initial template setup

            User user = _userDAL.AuthenticateUser(username, passwordHash);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password, or account is inactive.");
            }

            return user;
        }
    }
}
