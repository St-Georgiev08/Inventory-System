using Inventory_System;
using Inventory_System.Entities;
using Inventory_System.Enums;
using SalesSystem.Data.HelpMethods;
using SalesSystem.Data.Servises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Data.Controllers
{
    public class UsersCotroller
    {
        private readonly UsersCRUD users;
        private readonly SalesManagementSystemContext context;
        public UsersCotroller()
        {
            users = new();
        }
        public UsersCotroller(SalesManagementSystemContext context)
        {
            this.context = context;
            users = new(context);
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            int count = await users.Count();
            if (count == 0)
            {
                throw new ArgumentException("No Users in system");
            }
            return await users.GetAll();
        }
        public async Task<User> GetUserAsync(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Invalid User ID");
            }
            var user = await users.GetById(id);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }
            return user;
        }
        public async Task<string> AddUserAsync(string username, string pass, string role, string phone, string? email)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(role)
                || string.IsNullOrEmpty(phone))
            {
                throw new ArgumentException("All fields are required");
            }
            var hashing = new HashingPaswords();
            var hash = await hashing.HashPassword(pass);

            if (!Enum.TryParse<RoleType>(role, true, out var parsedRole))
            {
                throw new ArgumentException("Invalid role type");
            }

            await users.Add(new User
            {
                Username = username,
                PasswordHash = hash,
                Role = parsedRole,
                PhoneNumber = phone,
                Email = email
            });

            return "User added successfully";
        }
        public async Task<string> UpdateUserAsync(int id, string username, string pass, string role, string phone, string email)
        {
            if (id < 0 || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(role)
                || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("All fields are required and ID must be valid");
            }
            var hashing = new HashingPaswords();
            var hash = await hashing.HashPassword(pass);
            if (!Enum.TryParse<RoleType>(role, true, out var parsedRole))
            {
                throw new ArgumentException("Invalid role type");
            }
            var mm =  users.Update(id, username, hash, parsedRole, phone, email);
            if (mm != null)
                return "User updated successfully";
            else
                return "Not found";
        }
        public async Task<string> DeleteUserAsync(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Invalid User ID");
            }
            await users.Delete(id);
            return "User deleted successfully";
        }
        public async Task<User> AuthenticateUserAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Username and password are required");
            }
            var user = (await users.GetAll()).FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }
            var hashing = new HashingPaswords();
            string hash = user.PasswordHash;
            bool isPasswordValid = await hashing.VerifyPassword(password, user.PasswordHash);
            if (!isPasswordValid)
            {
                throw new ArgumentException("Invalid password");
            }
            return user;
        }
       
    }
}
