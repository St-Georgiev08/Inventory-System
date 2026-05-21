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
    public class OrderItemsCRUD
    {
        private readonly SalesManagementSystemContext _context;
        public OrderItemsCRUD()
        {
            _context = new();
        }
        //public async Task<int> Count()
        //{
        //    return await _context.OrderItems.CountAsync();
        //}
        //public async Task<List<OrderItems>> GetAll()
        //{
        //    return await _context.OrderItems.ToListAsync();
        //}
        //public async Task<OrderItems> GetById(int id)
        //{
        //    return await _context.OrderItems.FindAsync(id);
        //}
        public async Task Add(OrderItems orderItem)
        {
            await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();
        }
        public async Task Update(int id, int orderId, int productId, int quantity, decimal price)
        {
            var find = await _context.OrderItems.FindAsync(id);
            if (find != null)
            {
                find.OrderId = orderId;
                find.ProductId = productId;
                find.Quantity = quantity;
                find.UnitPrice = price;
                await _context.SaveChangesAsync();
            }
        }
         public async Task Delete(int id)
        {
            var find = await _context.OrderItems.FindAsync(id);
            if (find != null)
            {
                _context.OrderItems.Remove(find);
                await _context.SaveChangesAsync();
            }
         }

        public async Task<OrderItems> GetById(int id)
        {
            return await _context.OrderItems.FindAsync(id);
        }
    }
}
