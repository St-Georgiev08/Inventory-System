using Inventory_System;
using SalesSystem.Data.Servises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Data.Controllers
{
    public class CategoriesController
    {
        private readonly CategoriesCRUD categories;
        public CategoriesController()
        {
            categories = new();
        }
        public CategoriesController(SalesManagementSystemContext Context)
        {
            categories = new CategoriesCRUD(Context);
        }
        public async Task<List<Inventory_System.Entities.Categories>> GetAllCategories()
        {
            return await categories.GetAll();
        }

            public async Task<string> AddCategory(string name,string? desk)
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException("Category name is required");
                }
                await categories.Add(new Inventory_System.Entities.Categories { Name = name ,Description = desk});
                return "Category added successfully";
            }
        public async Task<string> UpdateCategory(int id, string name, string? desc)
        {
            if (id < 0 || string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Invalid input data");
            }
            if (await categories.GetById(id) == null)
            {
                throw new ArgumentException("Category not found");
            }
            await categories.Update(id, name, desc);
            return "Category updated successfully";
        }
    }
}
