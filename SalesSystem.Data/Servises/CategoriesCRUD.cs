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
    public class CategoriesCRUD
    {
        private readonly SalesManagementSystemContext context;
        public CategoriesCRUD()
        {
            context = new();
        }
        public CategoriesCRUD(SalesManagementSystemContext Context)
        {
            context = Context;
        }
        public async Task<int> Count()
        {
            return await context.Categories.CountAsync();
        }
        public async Task<List<Categories>> GetAll()
                    {
            return await context.Categories.ToListAsync();
        }
        public async Task<Categories> GetBYId(int id)
        {
            return await context.Categories.FindAsync(id);
        }
        public async Task Add(Categories category)
        {
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
        }
         public async Task Update(int id, string name, string? desc)
        {
            var find = await context.Categories.FindAsync(id);
            if (find != null)
            {
                find.Name = name;
                find.Description = desc;
                await context.SaveChangesAsync();
            }
         }
          public async Task Delete(int id)
        {
            var find = await context.Categories.FindAsync(id);
            if (find != null)
            {
                context.Categories.Remove(find);
                await context.SaveChangesAsync();
            }
        }

     

        internal async Task<Categories> GetById(int id)
        {
            return await context.Categories.FindAsync(id);
        }
    }
}
