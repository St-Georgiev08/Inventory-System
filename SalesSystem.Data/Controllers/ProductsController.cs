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
    public class ProductsController
    {
        private readonly ProductCRUD product;
        public ProductsController()
        {
            product = new();
        }
        public ProductsController(SalesManagementSystemContext context)
        {
            product = new(context);
        }
        public async Task<List<Products>> GetAllProduct()
        {
            int count = await product.Count();
            if(count == 0)
            {
                throw new ArgumentException("No products in system");
            }
            return await product.GetAll();
        }
         public async Task<Products> GetProductById(int id)
        {
             if(id < 0)
             {
                 throw new ArgumentException("Invalid product ID");
             }
             var prod = await product.GetById(id);
             if(prod == null)
             {
                 throw new ArgumentException("Product not found");
             }
             return prod;
        }
          public async Task<string> AddProduct(string name, decimal price, int quantity, int catId)
        {
              if (string.IsNullOrEmpty(name) || price <= 0 || quantity < 0 || catId < 0)
              {
                  throw new ArgumentException("Invalid input data");
              }
              if ((await product.GetAll()).Any(x=>x.Name == name && x.Price == price && x.CategoryId == catId))
              {
                var get =( await product.GetAll()).First(x=>x.Name == name);
                get.Quantity += quantity;
                return "Products quantity is changed! Product exists in system";
              }
            else
            {
                await product.Add(new Products
                {
                    Name = name,
                    Price = price,
                    Quantity = quantity,
                    CategoryId = catId
                });
                return "Product added successfully";
            }
             
        }
         public async Task<string> UpdateProduct(int id, string name, decimal price, int quantity, int catId)
        {
              if (id < 0 || string.IsNullOrEmpty(name) || price <= 0 || quantity < 0)
              {
                  throw new ArgumentException("Invalid input data");
              }
              await product.Update(id, name, price, quantity, catId);
              return "Product updated successfully";
         }
          public async Task<string> DeleteProduct(int id)
        {
             if (id < 0)
             {
                 throw new ArgumentException("Invalid product ID");
             }
             await product.Delete(id);
             return "Product deleted successfully";
        }
    }
}
