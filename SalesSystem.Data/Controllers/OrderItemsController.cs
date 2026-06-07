using DocumentFormat.OpenXml.InkML;
using Inventory_System;
using Inventory_System.Entities;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Business.DTOs;
using SalesSystem.Business.Servises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Business.Controllers
{
    public class OrderItemsController
    {
        private readonly OrderItemsCRUD orderItems;
        private readonly ProductsController products;
        private readonly SalesManagementSystemContext context;
        public OrderItemsController()
        {
            orderItems = new();
            products = new ProductsController();
            context = new();
        }
        public OrderItemsController(SalesManagementSystemContext order)
        {
            orderItems = new(order);
            products = new ProductsController(order);
            context = new();
        }
        public async Task<string> AddOrder(int OrderId, int prId, int Qantity, decimal UnitPrice)
        {
            if(OrderId < 0 || prId < 0 || Qantity < 1 || UnitPrice < 1)
            {
                throw new ArgumentException("Invalid input data");
            }
            var pro = (await products.GetAllProduct()).FirstOrDefault(x => x.Id == prId);
            if (pro.Quantity - Qantity < 0)
            {
                throw new ArgumentException("Not enough products");
            }
            OrderItems orderItem = new()
            {
                OrderId = OrderId,
                ProductId = prId,
                Quantity = Qantity,
                UnitPrice = UnitPrice
            };
          
            pro.Quantity -= Qantity;
            await orderItems.Add(orderItem);
                        return "Order item added successfully";
        }
        public async Task<string> UpdateOrder( int OrderId, int prId, int Qantity, decimal UnitPrice)
        {
            if (OrderId < 0 || prId < 0 || Qantity < 1 || UnitPrice < 1)
            {
                throw new ArgumentException("Invalid input data");
            }
            if (await orderItems.GetById(OrderId,prId) == null)
            {
                throw new ArgumentException("Order item not found");
            }
            await orderItems.Update(OrderId, prId, Qantity, UnitPrice);
            return "Order item updated successfully";
        }
        public async Task<string> DeleteOrderItem(int id,int prId)
        {
            if(id<0 || prId < 0 || await orderItems.GetById(id,prId) == null)
            {
                throw new ArgumentException("Invalid order item ID");
            }
            await orderItems.Delete(id, prId);
            return "Order item deleted successfully";
        }
            public async Task<List<OrderGridDto>> GetForGrid()
        {
            var orders = await context.OrderItems.Include(x => x.Order).ThenInclude(x=>x.User).Include(x=>x.Product).Select( x => new OrderGridDto
            {
                OrderId = x.OrderId,
                OrderedBy = x.Order.User.Username,
                Product = x.Product.Name,
                Qantity = x.Quantity,
                UnitPrice = x.UnitPrice
            }).ToListAsync();
            return orders;
        }


        public async Task<List<ProductDetails>> GetOrderedProductDetailsByUserAsync(int userId)
        {
            return await context.ProductDetails
                .Where(pd => pd.Products.OrderItems
                    .Any(oi => oi.Order.UserId == userId))
                .ToListAsync();
        }
    }
    }
        //public async Task<OrderItems> GetById(int id)
        //{
        //    if (id < 0)
        //    {
        //        throw new ArgumentException("Invalid order item ID");
        //    }
        //    var orderItem = await orderItems.GetById(id);
        //    if (orderItem == null)
        //    {
        //        throw new ArgumentException("Order item not found");
        //    }
        //    return orderItem;
        //}


