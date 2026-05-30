using Inventory_System;
using Inventory_System.Entities;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Data.Controllers;
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
        [TestCase("Description", "")]
        public void AddProductDetails_InvalidInput_ThrowsArgumentException(string description, string? img)
        {
            Assert.ThrowsAsync<ArgumentException>(async () =>
               await _controller.AddProductDetails( description, img));
        }

        [Test]
        public void AddProductDetails_InvalidInput_ThrowsArgumentExceptionNull()
        {
            Assert.ThrowsAsync<ArgumentException>(async () =>
               await _controller.AddProductDetails("description", null));
        }

        [Test]
        public async Task AddProductDetails_ValidInput_ReturnsSuccessMessage()
        {
            // Act
            var result = await _controller.AddProductDetails("Valid Description", "valid_path.png");

            // Assert
            Assert.That(result, Is.EqualTo("Product details added successfully"));
        }

        #endregion

        #region UpdateProductDetails Tests

        [TestCase(-1, "Desc", "img.png")]
        [TestCase(1, "Desc", "")]
        [TestCase(1, "Desc", "null")]
        public void UpdateProductDetails_InvalidInput_ThrowsArgumentException(int id, string description, string img)
        {
            Assert.ThrowsAsync<ArgumentException>(async () =>
                await _controller.UpdateProductDetails(id, description, img));
        }

        [Test]
        public void UpdateProductDetails_ProductNotFound_ThrowsArgumentException()
        {
            // Act & Assert (Database is empty, so ID 99 will not be found)
            Assert.ThrowsAsync<ArgumentException>(async () =>
                await _controller.UpdateProductDetails(99, "New Desc", "new_img.png"));
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

