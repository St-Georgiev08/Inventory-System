using Inventory_System;
using Inventory_System.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SalesSystem.Data.Controllers;
using System;
using System.Linq;
using System.Threading.Tasks;

[TestFixture]
public class OrderItemsControllerTests
{
    private SalesManagementSystemContext _context;
    private OrderItemsController _controller;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<SalesManagementSystemContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new SalesManagementSystemContext(options);
        _controller = new OrderItemsController(_context);
    }

    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }

    #region AddOrder Tests

    
    [Test]
    public void AddOrder_InvalidInputs_ThrowsArgumentException()
    {
        // Assert
        var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
            await _controller.AddOrder(-1, 1, 5, 10.00m));

        Assert.That(ex.Message, Is.EqualTo("Invalid input data"));
    }

    [Test]
    public async Task AddOrder_InsufficientStock_ThrowsArgumentException()
    {
        // Arrange
        var product = new Products { Id = 1,Name = "test", Quantity = 2, Price = 10.00m,CategoryId = 1 };
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        // Act & Assert
        // Requesting 5 when only 2 are available
        var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
            await _controller.AddOrder(1, 1, 5, 10.00m));

        Assert.That(ex.Message, Is.EqualTo("Not enough products"));
    }

    [Test]
    public async Task AddOrder_ValidInputs_ReturnsSuccessMessage()
    {
        // Arrange
        var product = new Products { Id = 1, Name = "test", Quantity = 3, Price = 10.00m, CategoryId = 1 };
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        // Act
        string result = await _controller.AddOrder(1, 1, 3, 10.00m);

        // Assert
        Assert.That(result, Is.EqualTo("Order item added successfully"));

        // Verify DB updates
        var addedItem = _context.OrderItems.FirstOrDefault(x => x.ProductId == 1);
        Assert.That(addedItem, Is.Not.Null);
        Assert.That(product.Quantity, Is.EqualTo(0)); // 10 - 3
    }

    #endregion

    #region UpdateOrder Tests

    [Test]
    public void UpdateOrder_InvalidInputs_ThrowsArgumentException()
    {
        var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
            await _controller.UpdateOrder( -1, 1, 5, 10.00m));

        Assert.That(ex.Message, Is.EqualTo("Invalid input data"));
    }

    [Test]
    public void UpdateOrder_ItemNotFound_ThrowsArgumentException()
    {
        var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
            await _controller.UpdateOrder( 9999, 1, 5, 10.00m));

        Assert.That(ex.Message, Is.EqualTo("Order item not found"));
    }

    [Test]
    public async Task UpdateOrder_ValidInputs_ReturnsSuccessMessage()
    {
        // Arrange
        var existingItem = new OrderItems { OrderId = 1, ProductId = 1, Quantity = 2, UnitPrice = 10.00m };
        _context.OrderItems.Add(existingItem);
        await _context.SaveChangesAsync();

        // Act
        string result = await _controller.UpdateOrder(1, 1, 5, 12.00m);

        // Assert
        Assert.That(result, Is.EqualTo("Order item updated successfully"));
    }

    #endregion

    #region DeleteOrderItem Tests

    [Test]
    public async Task DeleteOrderItem_ValidId_RemovesItem()
    {
        // Arrange
        var existingItem = new OrderItems { OrderId = 1, ProductId = 1, Quantity = 2, UnitPrice = 10.00m };
        _context.OrderItems.Add(existingItem);
        await _context.SaveChangesAsync();

        // Act
        string result = await _controller.DeleteOrderItem(1,1);

        // Assert
        Assert.That(result, Is.EqualTo("Order item deleted successfully"));
        Assert.That(_context.OrderItems.Any(x => x.OrderId == 1 && x.ProductId == 1), Is.False);
    }
    [TestCase(-1, 1)]
    [TestCase(1, -1)]
    [TestCase(1, 9999)]
    public async Task DeleteOrderItem_ValidId_RemovesItem_Invalid(int id, int prId)
    {
        // Arrange
        var existingItem = new OrderItems { OrderId = 1, ProductId = 1, Quantity = 2, UnitPrice = 10.00m };
        _context.OrderItems.Add(existingItem);
        await _context.SaveChangesAsync();

        // Assert
          Assert.ThrowsAsync<ArgumentException>(async () =>
           await _controller.DeleteOrderItem(id, prId));
    }


    #endregion

    //#region GetById Tests

    //[Test]
    //public void GetById_NegativeId_ThrowsArgumentException()
    //{
    //    var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _controller.GetById(-1,-2));
    //    Assert.That(ex.Message, Is.EqualTo("Invalid order item ID"));
    //}

    //[Test]
    //public void GetById_NotFound_ThrowsArgumentException()
    //{
    //    var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _controller.GetById(999));
    //    Assert.That(ex.Message, Is.EqualTo("Order item not found"));
    //}

    //[Test]
    //public async Task GetById_ValidId_ReturnsOrderItem()
    //{
    //    // Arrange
    //    var item = new OrderItems { OrderId = 5, ProductId = 1, Quantity = 2, UnitPrice = 10.00m };
    //    _context.OrderItems.Add(item);
    //    await _context.SaveChangesAsync();

    //    // Act
    //    var result = await _controller.GetById(5);

    //    // Assert
    //    Assert.That(result, Is.Not.Null);
    //    Assert.That(result.OrderId, Is.EqualTo(5));
    //}
    //#endregion
}