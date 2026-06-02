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
    public class ProductDetailsCRUD
    {
        private readonly SalesManagementSystemContext product;
        public ProductDetailsCRUD()
        {
            product = new SalesManagementSystemContext();
        }
        public ProductDetailsCRUD(SalesManagementSystemContext context)
        {
            product = context;
        }
            public async Task<int> Count()
            {
                return await product.ProductDetails.CountAsync();
        }
        public async Task<List<ProductDetails>> GetAll()
        {
            return await product.ProductDetails.Include(x=>x.Products).ThenInclude(x=>x.Category).ToListAsync();
        }
        public async Task<ProductDetails> GetById(int id)
        {
            return await product.ProductDetails.FindAsync(id);
        }
        public async Task Add(ProductDetails details)
        {
            await product.ProductDetails.AddAsync(details);
            await product.SaveChangesAsync();
        }
        public async Task Update(int id,int Prid, string? description, string img, int updated)
        {
            var find = await product.ProductDetails.FindAsync(id);
            if (find != null)
            {
                find.ProductId = Prid;
                find.Description = description;
                find.ImagePath = img;
                find.UpdatedBy = updated;
                await product.SaveChangesAsync();
            }
        }
         public async Task Delete(int id)
        {
            var find = await product.ProductDetails.FindAsync(id);
            if (find != null)
            {
                product.ProductDetails.Remove(find);
                await product.SaveChangesAsync();
            }
        }

    }
}
