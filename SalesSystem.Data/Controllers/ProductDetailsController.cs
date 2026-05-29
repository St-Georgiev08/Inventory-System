using Inventory_System;
using Inventory_System.Entities;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Data.Servises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Data.Controllers
{
    public class ProductDetailsController
    {
        private readonly SalesManagementSystemContext context;
        private readonly ProductDetailsCRUD detailsCRUD;
        public ProductDetailsController(SalesManagementSystemContext context)
        {
            this.context = context;
            detailsCRUD = new(context);
        }
        public ProductDetailsController()
        {
            detailsCRUD = new();
            context = new();
        }
        public async Task<List<ProductDetails>> GetAll()
        {
            return await context.ProductDetails.Include(x=>x.Products).ToListAsync();
        }
        public async Task<string> AddProductDetails(string? description, string img)
        {
            if (string.IsNullOrEmpty(img))
            {
                throw new ArgumentException("Invalid input data");
            }
            await detailsCRUD.Add(new ProductDetails { Description = description, ImagePath = img });
            return "Product details added successfully";
        }
        public async Task<string> UpdateProductDetails(int id, string? description, string img)
        {
            if (id < 0 || string.IsNullOrEmpty(img))
            {
                throw new ArgumentException("Invalid input data");
            }
            if (await detailsCRUD.GetById(id) == null)
            {
                throw new ArgumentException("Product details not found");
            }
            await detailsCRUD.Update(id, description, img);
            return "Product details updated successfully";
        }
        public async Task<ProductDetails> GetProductDetailsById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Invalid input data");
            }
            var details = await detailsCRUD.GetById(id);
            if (details == null)
            {
                throw new ArgumentException("Product details not found");
            }
            return details;
        }
        public async Task<string> DeleteProductDetails(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Invalid input data");
            }
            if (await detailsCRUD.GetById(id) == null)
            {
                throw new ArgumentException("Product details not found");
            }
            await detailsCRUD.Delete(id);
            return "Product details deleted successfully";
        }
        public async Task<List<ProductDetails>> FindAllWith(string text)
        {
         
            return await context.ProductDetails.Include(x=>x.Products)
                .Where(p => p.Products.Name.Contains(text))
                .ToListAsync();
        }
        public async Task<List<ProductDetails>> SortByType(List<ProductDetails> products, bool name, bool price, bool desc, string? type)
        {
            //List<ProductDetails> list1 = new List<ProductDetails>();
            if (!string.IsNullOrEmpty(type))
                products = products.Where(x => x.Products.Category.Name == type).ToList();
            if (name)
            {
                if (desc)
                {
                    return products.OrderByDescending(x => x.Products.Name).ToList();
                }
                var list = products.OrderBy(x => x.Products.Name);
                return list.ToList();
            }
            else if (price)
            {
                if(desc)
                {
                    return products.OrderByDescending(x => x.Products.Price).ToList();
                }
                var list = products.OrderBy(x => x.Products.Price);
                return list.ToList();
            }
            else
            {
                return products;
            }
        }
    }
}
