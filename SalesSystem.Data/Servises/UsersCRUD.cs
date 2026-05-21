using Inventory_System;
using Inventory_System.Entities;
using Inventory_System.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Data.Servises
{
    public class UsersCRUD
    {
        private readonly SalesManagementSystemContext _context;
        public UsersCRUD()
        {
            _context = new();
        }
        public async Task<int> Count()
        {
            return await _context.Users.CountAsync();
        }   
        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetById (int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task Add(User user)
        {
           await _context.Users.AddAsync(user);
           await _context.SaveChangesAsync();
        }
        public async Task Update(int id, string username, string pass, RoleType role, string phone, string email)
        {
            var find = await _context.Users.FindAsync(id);
            if(find != null)
            {
                find.Username = username;
                find.PasswordHash = pass;
                find.Role = role;
                find.PhoneNumber = phone;
                find.Email = email;
                await _context.SaveChangesAsync();
            }
        }

        internal async Task Delete(int id)
        {
            var find = await _context.Users.FindAsync(id);
            if (find != null)
            {
                _context.Users.Remove(find);
                await _context.SaveChangesAsync();
            }
        }
    }
}
