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
    public class ProductSuppliersCRUD
    {
        private readonly SalesManagementSystemContext _context;
        public ProductSuppliersCRUD()
        {
            _context = new();
        }
        //public async Task<int> Count()
        //{
        //    return await _context.ProductSuppliers.CountAsync();
        //}
        //public async Task<List<ProductSuppliers>> GetAll()
        //{
        //    return await _context.ProductSuppliers.ToListAsync();
        //}
        //public async Task<OrderItems> GetById(int id)
        //{
        //    return await _context.OrderItems.FindAsync(id);
        //}
        public async Task Add(ProductSuppliers orderItem)
        {
            await _context.ProductSuppliers.AddAsync(orderItem);
            await _context.SaveChangesAsync();
        }
        public async Task Update(int prId, int subId)
        {
            var find = await _context.ProductSuppliers.FirstOrDefaultAsync(x=>x.ProductId == prId && x.SupplierId == subId);
            if (find != null)
            {
                prId = find.ProductId;
                subId = find.SupplierId;
                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var find = await _context.ProductSuppliers.FindAsync(id);
            if (find != null)
            {
                _context.ProductSuppliers.Remove(find);
                await _context.SaveChangesAsync();
            }
        }
    }
}
