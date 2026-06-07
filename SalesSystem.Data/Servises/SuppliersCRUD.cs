using Inventory_System;
using Inventory_System.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Business.Servises
{
    public class SuppliersCRUD
    {
        private readonly SalesManagementSystemContext _context;
        public SuppliersCRUD()
        {
            _context = new SalesManagementSystemContext();
        }
        public SuppliersCRUD(SalesManagementSystemContext context)
        {
            _context =context;
        }
        public async Task<int> Count()
        {
            return await _context.Suppliers.CountAsync();
        }
        public async Task<List<Suppliers>> GetAll()
        {
            return await _context.Suppliers.ToListAsync();
        }
        public async Task<Suppliers> GetById(int id)
        {
            return await _context.Suppliers.FindAsync(id);
        }
        public async Task Add(Suppliers supplier)
        {
            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();
        }
        public async Task Update(int id, string name, string phoneNum,string? email, string addres)
        {
            
            var find = await _context.Suppliers.FindAsync(id);
            if (find != null)
            {
                find.Name = name;
                find.PhoneNumber = phoneNum;
                find.Email = email;
                find.Address = addres;
                await _context.SaveChangesAsync();
            }
        }

    }
}
