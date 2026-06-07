using Inventory_System;
using Inventory_System.Entities;
using Inventory_System.Enums;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SalesSystem.Business.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[TestFixture]
public class OrdersControllerTests
{
    private SalesManagementSystemContext _context;
    private OrdersController _controller;

    [SetUp]
    public void Setup()
    {
        // Setup an isolated In-Memory Database for each test run
        var options = new DbContextOptionsBuilder<SalesManagementSystemContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new SalesManagementSystemContext(options);
        _controller = new OrdersController(_context);
    }

    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }

    #region GetAll Tests

    [Test]
    public void GetAll_NoOrdersInSystem_ThrowsArgumentException()
    {
        var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _controller.GetAll());
        Assert.That(ex.Message, Is.EqualTo("No orders in system"));
    }

    [Test]
    public async Task GetAll_OrdersExist_ReturnsList()
    {
        // Arrange
        _context.Orders.Add(new Orders { Id = 1, UserId = 1, OrderDate = DateTime.Now, TotalAmount = 50.00m });
        _context.Orders.Add(new Orders { Id = 2, UserId = 2, OrderDate = DateTime.Now, TotalAmount = 150.00m });
        await _context.SaveChangesAsync();

        // Act
        var result = await _controller.GetAll();

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(2));
    }

    #endregion

    #region GetById Tests

    [Test]
    public void GetById_NegativeId_ThrowsArgumentException()
    {
        var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _controller.GetById(-1));
        Assert.That(ex.Message, Is.EqualTo("Invalid order ID"));
    }

    [Test]
    public void GetById_OrderNotFound_ThrowsArgumentException()
    {
        var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _controller.GetById(999));
        Assert.That(ex.Message, Is.EqualTo("Order not found"));
    }

    [Test]
    public async Task GetById_ValidId_ReturnsOrder()
    {
        // Arrange
        var testOrder = new Orders { Id = 10, UserId = 1, OrderDate = DateTime.Now, TotalAmount = 99.99m };
        _context.Orders.Add(testOrder);
        await _context.SaveChangesAsync();

        // Act
        var result = await _controller.GetById(10);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.TotalAmount, Is.EqualTo(99.99m));
    }

    #endregion

    #region Add Tests

    [TestCase("", "2026-05-30", 50.00)]       // Empty Name
    [TestCase("JohnDoe", "0001-01-01", 50.00)] // Default DateTime
    [TestCase("JohnDoe", "2026-05-30", -10.00)] // Negative Total
    public void Add_InvalidInputData_ThrowsArgumentException(string name, string dateStr, decimal total)
    {
        DateTime orderDate = DateTime.Parse(dateStr);

        var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
            await _controller.Add(name, orderDate, total));

        Assert.That(ex.Message, Is.EqualTo("Invalid input data"));
    }

    [Test]
    public void Add_UserDoesNotExist_ThrowsArgumentException()
    {
        // Arrange: Seed a completely different user so the system has users,
        // but NOT the one we are trying to look up.
        var unrelatedUser = new User { Id = 99,PasswordHash = "test",Role = RoleType.Client,PhoneNumber = "0895650627",Email = "", Username = "SomeOtherUser" };
        _context.Users.Add(unrelatedUser);
        _context.SaveChanges();

        // Act & Assert
        var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
            await _controller.Add("NonExistentUser", DateTime.Now, 100.00m));

        Assert.That(ex.Message, Is.EqualTo("Invalid user name"));
    }

    [Test]
    public async Task Add_ValidInputs_ReturnsSuccessMessageAndSaves()
    {
        // Arrange: Seed a user with the EXACT username you will test with
        var user = new User
        {
            Id = 99,
            PasswordHash = "test",
            Role = RoleType.Client,
            PhoneNumber = "0895650627",
            Email = "",
            Username = "ValidUser" // 1. Set this to "ValidUser"
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        // Act
        string result = await _controller.Add("ValidUser", DateTime.Now, 120.50m);

        // Assert
        Assert.That(result, Is.EqualTo("Order added successfully"));

        // Confirm it hit the In-Memory DB using the correct seeded Id (99)
        var savedOrder = _context.Orders.FirstOrDefault(o => o.UserId == 99); // 2. Update 42 to 99
        Assert.That(savedOrder, Is.Not.Null);
        Assert.That(savedOrder.TotalAmount, Is.EqualTo(120.50m));
    }
    #endregion

    #region Update Tests

    [TestCase(-1, 1, "2026-05-30", 50.00)]  // Invalid Order Id
    [TestCase(1, -1, "2026-05-30", 50.00)]  // Invalid User Id
    [TestCase(1, 1, "0001-01-01", 50.00)]   // Default Date
    [TestCase(1, 1, "2026-05-30", -5.00)]   // Negative Total
    public void Update_InvalidInputs_ThrowsArgumentException(int id, int uId, string dateStr, decimal total)
    {
        DateTime orderDate = DateTime.Parse(dateStr);

        var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
            await _controller.Update(id, uId, orderDate, total));

        Assert.That(ex.Message, Is.EqualTo("Invalid input data"));
    }

    [Test]
    public async Task Update_ValidInputs_ReturnsSuccessMessage()
    {
        // Arrange
        var existingOrder = new Orders { Id = 1, UserId = 1, OrderDate = DateTime.Now, TotalAmount = 10.00m };
        _context.Orders.Add(existingOrder);
        await _context.SaveChangesAsync();

        // Act
        string result = await _controller.Update(1, 2, DateTime.Now.AddDays(1), 25.00m);

        // Assert
        Assert.That(result, Is.EqualTo("Order updated successfully"));
    }

    #endregion

    #region Delete Tests

    [Test]
    public void Delete_NegativeId_ThrowsArgumentException()
    {
        var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _controller.Delete(-1));
        Assert.That(ex.Message, Is.EqualTo("Invalid order ID"));
    }

    [Test]
    public async Task Delete_ValidId_ReturnsSuccessMessage()
    {
        // Arrange
        var existingOrder = new Orders { Id = 5, UserId = 1, OrderDate = DateTime.Now, TotalAmount = 10.00m };
        _context.Orders.Add(existingOrder);
        await _context.SaveChangesAsync();

        // Act
        string result = await _controller.Delete(5);

        // Assert
        Assert.That(result, Is.EqualTo("Order deleted successfully"));
    }

    #endregion
}
