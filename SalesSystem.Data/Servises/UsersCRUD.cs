using Inventory_System;
using Inventory_System.Entities;
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
        
    }
}
