using Inventory_System.Entities;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Data.Controllers;
using SalesSystem.Data.HelpMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingControllerUser.Helpers;

namespace TestigSystem.Services
{
    public class ProductControllerTest
    {
        [Test]
        public async Task DeleteUserAsync()
        {
            var context = TestDbShop.CreateContext();
            context.Add(new Categories
            {
                Name = "Tech"
            });
            context.Add(new Products
            {
                Name = "Test",
                Price = 12,
                Quantity = 12,
                CategoryId = 1
            });
            await context.SaveChangesAsync();
            CategoriesController cat = new(context);
            ProductsController productsController = new(context);
            await productsController.DeleteProduct(0);
            Assert.That(await context.Users.FirstOrDefaultAsync(u => u.Id == 0), Is.Null);
        }
        [Test]
        public async Task DeleteUserAsync_InvalidId()
        {
            var context = TestDbShop.CreateContext();
            CategoriesController cat = new(context);
            ProductsController productsController = new(context);
            Assert.ThrowsAsync<ArgumentException>(async () => await productsController.DeleteProduct(-1));
        }
        [Test]
        public async Task UpdateProduct()
        {
            var context = TestDbShop.CreateContext();
            context.Add(new Categories
            {
                Name = "Tech"
            });
            context.Add(new Products
            {
                Name = "Test",
                Price = 12,
                Quantity = 12,
                CategoryId = 1
            });
            await context.SaveChangesAsync();
            ProductsController pr = new(context);
            Assert.That(await pr.UpdateProduct(0,"Name",13,3,1), Is.EqualTo("Product updated successfully"));
        }
        [Test]
        public async Task UpdateProduct_InvalidId()
        {
            var context = TestDbShop.CreateContext();
            CategoriesController cat = new(context);
            ProductsController productsController = new(context);
            Assert.ThrowsAsync<ArgumentException>(async () => await productsController.UpdateProduct(-1, "", 13, 3, 1));
        }
        [Test]
        public async Task AddProductAsyncTest()
        {
            var context = TestDbShop.CreateContext();
            CategoriesController cat = new(context);
            ProductsController productsController = new(context);
            Assert.That(await productsController.AddProduct("Name", 13, 3, 1), Is.EqualTo("Product added successfully"));

        }
        [Test]
        public async Task AddProductAsyncTest_InvalidData()
        {
            var context = TestDbShop.CreateContext();
            CategoriesController cat = new(context);
            ProductsController productsController = new(context);
            Assert.ThrowsAsync<ArgumentException>(async () => await productsController.AddProduct("",-1,1,1));

        }
        [Test]
        public async Task GetProductAsyncTEst()
        {

            var context = TestDbShop.CreateContext();
            context.Add(new Products
            {
                Name = "Test",
                Price = 12,
                Quantity = 12,
                CategoryId = 1
            });
            await context.SaveChangesAsync();
            ProductsController productsController = new(context);
            Assert.That(await productsController.GetProductById(1), Is.Not.Null);
        }
        [Test]
        public async Task GetProductAsyncTest_InvalidId()
        {
            var context = TestDbShop.CreateContext();
            await context.SaveChangesAsync();
            ProductsController productsController = new(context);
            Assert.ThrowsAsync<ArgumentException>(async () => await productsController.GetProductById(-1));
        }
        [Test]
        public async Task GetProductAsyncTest()
        {
            var context = TestDbShop.CreateContext();
            await context.SaveChangesAsync();
            ProductsController productsController = new(context);
            Assert.ThrowsAsync<ArgumentException>(async () => await productsController.GetProductById(3));
        }
        [Test]
        public async Task GetAllProduct()
        {
            var context = TestDbShop.CreateContext();
            context.Add(new Products
            {
                Name = "Test",
                Price = 12,
                Quantity = 12,
                CategoryId = 1
            });
            await context.SaveChangesAsync();
            ProductsController productsController = new(context);
            Assert.That(await productsController.GetAllProduct(), Is.Not.Null);
        }
        [Test]
        public async Task GetAllProduct_NoElements()
        {
            var context = TestDbShop.CreateContext();
            await context.SaveChangesAsync();
            ProductsController productsController = new(context);
            Assert.ThrowsAsync<ArgumentException>(async () => await productsController.GetAllProduct());
        }
        [Test]
        public async Task ControllerTest()
        {
            ProductsController test = new();
        }
    }
}
