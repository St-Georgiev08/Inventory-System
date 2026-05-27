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
    public class OrderItemsController
    {
        private readonly OrderItemsCRUD orderItems;
        public OrderItemsController(SalesManagementSystemContext order)
        {
            orderItems = new(order);
        }
        public async Task<string> AddOrder(int OrderId, int prId, int Qantity, decimal UnitPrice)
        {
            if(OrderId < 0 || prId < 0 || Qantity < 1 || UnitPrice < 1)
            {
                throw new ArgumentException("Invalid input data");
            }
            OrderItems orderItem = new()
            {
                OrderId = OrderId,
                ProductId = prId,
                Quantity = Qantity,
                UnitPrice = UnitPrice
            };
            await orderItems.Add(orderItem);
                        return "Order item added successfully";
        }
        public async Task<string> UpdateOrder(int id, int OrderId, int prId, int Qantity, decimal UnitPrice)
        {
            if (id < 0 || OrderId < 0 || prId < 0 || Qantity < 1 || UnitPrice < 1)
            {
                throw new ArgumentException("Invalid input data");
            }
            if (await orderItems.GetById(id) == null)
            {
                throw new ArgumentException("Order item not found");
            }
            await orderItems.Update(id, OrderId, prId, Qantity, UnitPrice);
            return "Order item updated successfully";
        }
        public async Task<string> DeleteOrderItem(int id)
        {
            if(id<0 && await orderItems.GetById(id) == null)
            {
                throw new ArgumentException("Invalid order item ID");
            }
            await orderItems.Delete(id);
            return "Order item deleted successfully";
        }
            public async Task<OrderItems> GetById(int id)
            {
                if (id < 0)
                {
                    throw new ArgumentException("Invalid order item ID");
                }
                var orderItem = await orderItems.GetById(id);
                if (orderItem == null)
                {
                    throw new ArgumentException("Order item not found");
                }
                return orderItem;
        }
    }
}
