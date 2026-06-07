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
    public class OrderCRUD
    {
        private readonly SalesManagementSystemContext context;
        public OrderCRUD()
        {
            context = new SalesManagementSystemContext();
        }
        public OrderCRUD(SalesManagementSystemContext context1)
        {
            context = context1;
        }
        public async Task<int> Count()
        {
            return await context.Orders.CountAsync();
        }
        public async Task<List<Orders>> GetAll()
        {
            return await context.Orders.ToListAsync();
        }
        public async Task<Orders> GetBYId(int id)
        {
            return await context.Orders.FindAsync(id);
        }
        public async Task Add(Orders category)
        {
            await context.Orders.AddAsync(category);
            await context.SaveChangesAsync();
        }
        public async Task Update(int id,int uId, DateTime dateTime, decimal total)
        {
            var find = await context.Orders.FindAsync(id);
            if (find != null)
            {
                find.UserId = uId;
                find.OrderDate = dateTime;
                find.TotalAmount = total;
                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var find = await context.Orders.FindAsync(id);
            if (find != null)
            {
                context.Orders.Remove(find);
                await context.SaveChangesAsync();
            }
        }
    
    }
}
