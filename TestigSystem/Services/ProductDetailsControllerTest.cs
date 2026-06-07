using Inventory_System;
using Inventory_System.Entities;
using Inventory_System.Enums;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Business.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestigSystem.Services
{
    public class ProductDetailsControllerTest
    {
        private SalesManagementSystemContext _context;
        private ProductDetailsController _controller;

        [SetUp]
        public void SetUp()
        {
            // Configure a unique In-Memory Database for each test run to ensure isolation
            var options = new DbContextOptionsBuilder<SalesManagementSystemContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new SalesManagementSystemContext(options);
            _controller = new ProductDetailsController(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        #region GetAll Tests

        [Test]
        public async Task GetAll_WhenDataExists_ReturnsAllItemsWithProductsIncluded()
        {
            // Arrange
            var product = new Products { Name = "Laptop", Price = 999.99m, Category = new Categories { Name = "Electronics" } };
            var details = new ProductDetails { Id = 1, Description = "High performance", ImagePath = "img.png", Products = product };

            _context.ProductDetails.Add(details);
            await _context.SaveChangesAsync();

            // Act
            var result = await _controller.GetAll();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Products.Name, Is.EqualTo("Laptop"));
        }

        #endregion

        #region AddProductDetails Tests
        [TestCase("", 1, 1)]
        [TestCase("null", 1, 1)]
        [TestCase(null, 9999, 1)]
        [TestCase(null, 1, 9999)]
        public  void AddProductDetails_InvalidInput_ThrowsArgumentException(string? img, int productId, int createdBy)
        {
          
            Assert.ThrowsAsync<ArgumentException>(async () =>
               await _controller.AddProductDetails(productId, "desc", img, createdBy));
        }

        [Test]
        public async Task AddProductDetails_InvalidInput_ThrowsArgumentExceptionNull()
        {
            _context.Products.Add(new Products { Id = 1, Name = "Test Product", Price = 10.00m, Category = new Categories { Name = "Test Category" } });
            _context.Users.Add(new User { Id = 1, Username = "TestUser", PasswordHash = "hash", Role = RoleType.Client, PhoneNumber = "1234567890", Email = "test@example.com" });
            await _context.SaveChangesAsync();
            Assert.ThrowsAsync<ArgumentException>(async () =>
               await _controller.AddProductDetails(1,"description", null,1));
        }

        [Test]
        public async Task AddProductDetails_ValidInput_ReturnsSuccessMessage()
        {
            _context.Products.Add(new Products { Id = 1, Name = "Test Product", Price = 10.00m, Category = new Categories { Name = "Test Category" } });
            _context.Users.Add(new User { Id = 1, Username = "TestUser", PasswordHash = "hash", Role = RoleType.Client, PhoneNumber = "1234567890", Email = "test@example.com" });
            await _context.SaveChangesAsync();
            // Act
            var result = await _controller.AddProductDetails(1,"Valid Description", "valid_path.png", 1);

            // Assert
            Assert.That(result, Is.EqualTo("Product details added successfully"));
        }

        #endregion

        #region UpdateProductDetails Tests

        [TestCase(-1,1, "Desc", "img.png", 1)]
        [TestCase(1, -1, "Desc", "img.png", 1)]
        [TestCase(1, 1, "Desc", "img.png", -1)]
        public void UpdateProductDetails_InvalidInput_ThrowsArgumentException(int id ,int productId , string description, string img, int createdBy)
        {
            Assert.ThrowsAsync<ArgumentException>(async () =>
                await _controller.UpdateProductDetails(id, productId, description, img, createdBy));
        }

        [Test]
        public async Task UpdateProductDetails_ProductNotFound_ThrowsArgumentException()
        {
            _context.Products.Add(new Products { Id = 1, Name = "Test Product", Price = 10.00m, Category = new Categories { Name = "Test Category" } });
            _context.Users.Add(new User { Id = 1, Username = "TestUser", PasswordHash = "hash", Role = RoleType.Client, PhoneNumber = "1234567890", Email = "test@example.com" });
            _context.ProductDetails.Add(new ProductDetails { Id = 1, Description = "Old Desc", ImagePath = "old_img.png", ProductId = 1, CreatedBy = 1, UpdatedBy = 1 });
            await _context.SaveChangesAsync();
            Assert.ThrowsAsync<ArgumentException>(async () =>
                await _controller.UpdateProductDetails(99,1, "New Desc", "new_img.png",1));
        }

        #endregion

        #region GetProductDetailsById Tests

        [Test]
        public void GetProductDetailsById_NegativeId_ThrowsArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(async () =>
                await _controller.GetProductDetailsById(-5));
        }

        [Test]
        public void GetProductDetailsById_NotFound_ThrowsArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(async () =>
                await _controller.GetProductDetailsById(404));
        }

        #endregion

        #region DeleteProductDetails Tests

        [Test]
        public void DeleteProductDetails_NegativeId_ThrowsArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(async () =>
                await _controller.DeleteProductDetails(-1));
        }

        [Test]
        public void DeleteProductDetails_NotFound_ThrowsArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(async () =>
                await _controller.DeleteProductDetails(999));
        }

        #endregion

        #region FindAllWith Tests

        [Test]
        public async Task FindAllWith_MatchingText_ReturnsFilteredResults()
        {
            // Arrange
            var p1 = new ProductDetails { Id = 1, Products = new Products { Name = "Apple iPhone"}, ImagePath = "test",CreatedBy = 0, UpdatedBy = 0 };
            var p2 = new ProductDetails { Id = 2, Products = new Products { Name = "Samsung Galaxy" }, ImagePath = "test", CreatedBy = 0, UpdatedBy = 0 };

            await _context.ProductDetails.AddRangeAsync(p1, p2);
            await _context.SaveChangesAsync(); // 👈 ADD THIS LINE HERE

            // Act
            var result = await _controller.FindAllWith("Apple");

            // Assert
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Products.Name, Is.EqualTo("Apple iPhone"));
        }

        #endregion

        #region SortByType Tests

        [Test]
        public async Task SortByType_SortByNameAscending_SortsCorrectly()
        {
            // Arrange
            var list = new List<ProductDetails>
            {
                new ProductDetails { Products = new Products { Name = "Zebra" } },
                new ProductDetails { Products = new Products { Name = "Apple" } }
            };

            // Act
            var result = await _controller.SortByType(list, name: true, price: false, desc: false, type: null);

            // Assert
            Assert.That(result[0].Products.Name, Is.EqualTo("Apple"));
            Assert.That(result[1].Products.Name, Is.EqualTo("Zebra"));
        }

        [Test]
        public async Task SortByType_SortByPriceDescending_SortsCorrectly()
        {
            // Arrange
            var list = new List<ProductDetails>
            {
                new ProductDetails { Products = new Products { Price = 10.00m } },
                new ProductDetails { Products = new Products { Price = 50.00m } }
            };

            // Act
            var result = await _controller.SortByType(list, name: false, price: true, desc: true, type: null);

            // Assert
            Assert.That(result[0].Products.Price, Is.EqualTo(50.00));
            Assert.That(result[1].Products.Price, Is.EqualTo(10.00));
        }

        #endregion
    }
}

