using Inventory_System.Entities;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Business.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingControllerUser.Helpers;

namespace TestigSystem.Services
{
    public class CategoriesControllerTest
    {
        [Test]
        public async Task AddCategory()
        {
            var context = TestDbShop.CreateContext();
            CategoriesController cat = new(context);
            Assert.That(await cat.AddCategory("Tech", ""), Is.EqualTo("Category added successfully"));
        }
        [Test]
        public async Task AddCategory_InvalidName()
        {
            var context = TestDbShop.CreateContext();
            CategoriesController cat = new(context);
            Assert.ThrowsAsync<ArgumentException>(async () => await cat.AddCategory("", ""));
        }
        [Test]
        public async Task GetAllTest()
        {
            var context = TestDbShop.CreateContext();
            CategoriesController cat = new(context);
            Assert.That(await cat.GetAllCategories(), Is.Not.Null);
        }
        [Test]
        public async Task UpdateCategories()
        {
            var context = TestDbShop.CreateContext();
            context.Add(new Categories
            {
                Name = "Test",
                Description = ""
            });
            await context.SaveChangesAsync(); ;
            CategoriesController cat = new(context);
            Assert.That(await cat.UpdateCategory(1,"Te","test"), Is.Not.Null);
        }
        [Test]
        public async Task UpdateCategories_InvalidIdName()
        {
            var context = TestDbShop.CreateContext();
            await context.SaveChangesAsync(); ;
            CategoriesController cat = new(context);
            Assert.ThrowsAsync<ArgumentException>(async () => await cat.UpdateCategory(-1,"", ""));
        }
        [Test]
        public async Task UpdateCategories_NotFound()
        {
            var context = TestDbShop.CreateContext();
            await context.SaveChangesAsync(); ;
            CategoriesController cat = new(context);
            Assert.ThrowsAsync<ArgumentException>(async () => await cat.UpdateCategory(3, "Name", ""));
        }
        [Test]
        public async Task testController()
        {
            CategoriesController categories = new();
        }
    }
}
