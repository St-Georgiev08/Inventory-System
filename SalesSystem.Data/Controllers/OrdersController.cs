using Inventory_System;
using Inventory_System.Entities;
using SalesSystem.Business.Servises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Business.Controllers
{
    public class OrdersController
    {
        private readonly OrderCRUD orders;
        private readonly OrderItemsController orderItems;
        private readonly UsersCotroller usersCotroller;
        public OrdersController()
        {
            orders = new();
            orderItems = new();
            orderItems = new();
        }
        public OrdersController(SalesManagementSystemContext context)
        {
            orders = new(context);
            orderItems = new(context);
            usersCotroller = new(context);
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
        public async Task<string> Add(string name, DateTime dateTime, decimal total)
        {
            if (string.IsNullOrEmpty(name) || dateTime == default || total < 0)
            {
                throw new ArgumentException("Invalid input data");
            }
            var find = (await usersCotroller.GetAllUsersAsync()).FirstOrDefault(x=>x.Username == name);
            if (find == null)
            {
                throw new ArgumentException("Invalid user name");
            }
            await orders.Add(new Orders
            {
                UserId = find.Id,
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
