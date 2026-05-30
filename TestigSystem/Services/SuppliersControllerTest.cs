using Inventory_System;
// Adjust namespace if necessary to match your entity location
using Inventory_System.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SalesSystem.Data.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[TestFixture]
public class SuppliersControllerTests
{
    private SalesManagementSystemContext _context;
    private SuppliersController _controller;

    [SetUp]
    public void Setup()
    {
        // Set up an isolated In-Memory Database for each test run
        var options = new DbContextOptionsBuilder<SalesManagementSystemContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new SalesManagementSystemContext(options);
        _controller = new SuppliersController(_context);
    }

    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }

    #region GetAll Tests

    [Test]
    public void GetAll_NoSuppliersInSystem_ThrowsArgumentException()
    {
        // Act & Assert
        var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _controller.GetAll());
        Assert.That(ex.Message, Is.EqualTo("No suppliers in system"));
    }

    [Test]
    public async Task GetAll_SuppliersExist_ReturnsList()
    {
        // Arrange
        _context.Suppliers.Add(new Suppliers { Id = 1, Name = "Supplier A", PhoneNumber = "123", Address = "Street 1" });
        _context.Suppliers.Add(new Suppliers { Id = 2, Name = "Supplier B", PhoneNumber = "456", Address = "Street 2" });
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
        // Act & Assert
        var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _controller.GetById(-1));
        Assert.That(ex.Message, Is.EqualTo("Invalid supplier ID"));
    }

    [Test]
    public void GetById_SupplierNotFound_ThrowsArgumentException()
    {
        // Act & Assert
        var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _controller.GetById(999));
        Assert.That(ex.Message, Is.EqualTo("Supplier not found"));
    }

    [Test]
    public async Task GetById_ValidId_ReturnsSupplier()
    {
        // Arrange
        var targetSupplier = new Suppliers { Id = 10, Name = "Target Supp", PhoneNumber = "555", Address = "Road 1" };
        _context.Suppliers.Add(targetSupplier);
        await _context.SaveChangesAsync();

        // Act
        var result = await _controller.GetById(10);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Name, Is.EqualTo("Target Supp"));
    }

    #endregion

    #region Add Tests

    [TestCase("", "123456", "Address text")]
    [TestCase("Name text", "", "Address text")]
    [TestCase("Name text", "123456", "")]
    public void Add_MissingRequiredFields_ThrowsArgumentException(string name, string phoneNum, string address)
    {
        // Act & Assert
        var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
            await _controller.Add(name, phoneNum, "email@test.com", address));

        Assert.That(ex.Message, Is.EqualTo("Name, Phone Number and Address are required"));
    }

    [Test]
    public void Add_MissingRequiredFields_ThrowsArgumentExceptionNULL()
    {
        // Act & Assert
        var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
            await _controller.Add(null, "123456"," ", "Address text"));

        Assert.That(ex.Message, Is.EqualTo("Name, Phone Number and Address are required"));
    }

    [Test]
    public async Task Add_ValidInputs_ReturnsSuccessMessageAndSaves()
    {
        // Act
        string result = await _controller.Add("Acme Corp", "555-0100", "contact@acme.com", "123 Factory Lane");

        // Assert
        Assert.That(result, Is.EqualTo("Supplier added successfully"));

        // Double check database state
        var addedSupplier = _context.Suppliers.FirstOrDefault(s => s.Name == "Acme Corp");
        Assert.That(addedSupplier, Is.Not.Null);
        Assert.That(addedSupplier.PhoneNumber, Is.EqualTo("555-0100"));
    }

    #endregion

    #region Update Tests

    [TestCase(-1, "Name", "123", "Address")]
    [TestCase(1, "", "123", "Address")]
    [TestCase(1, "Name", "", "Address")]
    [TestCase(1, "Name", "123", "")]
    public void Update_InvalidInputData_ThrowsArgumentException(int id, string name, string phoneNum, string address)
    {
        // Act & Assert
        var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
            await _controller.Update(id, name, phoneNum, "email@test.com", address));

        Assert.That(ex.Message, Is.EqualTo("Invalid input data"));
    }

    [Test]
    public async Task Update_ValidInputs_ReturnsSuccessMessage()
    {
        // Arrange
        var initialSupplier = new Suppliers { Id = 1, Name = "Old Name", PhoneNumber = "111", Address = "Old Road" };
        _context.Suppliers.Add(initialSupplier);
        await _context.SaveChangesAsync();

        // Act
        string result = await _controller.Update(1, "New Name", "222", "new@email.com", "New Road");

        // Assert
        Assert.That(result, Is.EqualTo("Supplier updated successfully"));
    }

    #endregion
}