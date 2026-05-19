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
    public class ProductCRUD
    {
        private readonly SalesManagementSystemContext _context;
        public ProductCRUD()
        {
            _context = new();
        }
        public async Task<int> Count()
        {
            return await _context.Products.CountAsync();
        }
        public async Task<List<Products>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Products> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        public async Task Add(Products products)
        {
            await _context.Products.AddAsync(products);
            await _context.SaveChangesAsync();
        }
        public async Task Update(int id, string name, decimal price, int quantity, int CreatedBy, int? updatedBy, int catId)
        {

            var find = await _context.Products.FindAsync(id);
            if (find != null)
            {
                find.Name = name;
                find.Price = price;
                find.Quantity = quantity;
                find.CreatedBy = CreatedBy;
                find.UpdatedBy = updatedBy;
                find.CategoryId = catId;
                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var find = await _context.Products.FindAsync(id);
            if (find != null)
            {
                _context.Products.Remove(find);
                await _context.SaveChangesAsync();
            }
        }
    }
}
