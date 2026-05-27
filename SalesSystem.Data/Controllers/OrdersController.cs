using Inventory_System;
using Inventory_System.Entities;
using SalesSystem.Data.Servises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Data.Controllers
{
    public class OrdersController
    {
        private readonly OrderCRUD orders;
        public OrdersController()
        {
            orders = new();
        }
        public OrdersController(SalesManagementSystemContext context)
        {
            orders = new(context);
        }
        public async Task<List<Orders>> GetAll()
        {
            int count = await orders.Count();
            if (count == 0)
            {
                throw new ArgumentException("No orders in system");
            }
            return await orders.GetAll();
        }
        public async Task<Orders> GetById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Invalid order ID");
            }
            Orders orders = await this.orders.GetBYId(id);
            if (orders == null)
            {
                throw new ArgumentException("Order not found");
            }
            return orders;
        }
        public async Task<string> Add(int uId, DateTime dateTime, decimal total)
        {
            if (uId < 0 || dateTime == default || total < 0)
            {
                throw new ArgumentException("Invalid input data");
            }
            await orders.Add(new Orders
            {
                UserId = uId,
                OrderDate = dateTime,
                TotalAmount = total
            });
            return "Order added successfully";
        }
        public async Task<string> Update(int id, int uId, DateTime dateTime, decimal total)
        {
            if (id < 0 || uId < 0 || dateTime == default || total < 0)
            {
                throw new ArgumentException("Invalid input data");
            }
            await orders.Update(id, uId, dateTime, total);
            return "Order updated successfully";
        }
        public async Task<string> Delete(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Invalid order ID");
            }
            await orders.Delete(id);
            return "Order deleted successfully";
        }
    }
}
