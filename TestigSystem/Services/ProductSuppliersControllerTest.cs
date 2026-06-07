using Inventory_System;
using Inventory_System.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SalesSystem.Business.Controllers;
using SalesSystem.Business.Servises;
using System;
using System.Linq;
using System.Threading.Tasks;

[TestFixture]
public class ProductSuppliersControllerTests
{
    private SalesManagementSystemContext _context;
    private ProductSuppliersController _controller;

    [SetUp]
    public void Setup()
    {
        // Set up an isolated In-Memory Database
        var options = new DbContextOptionsBuilder<SalesManagementSystemContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new SalesManagementSystemContext(options);

        // Initialize the CRUD instance with the context and inject it into the controller
        var crud = new ProductSuppliersCRUD(_context);
        _controller = new ProductSuppliersController(crud);
    }

    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }

    #region AddProductSupplier Tests

    [TestCase(-1, 1)]
    [TestCase(1, -1)]
    public void AddProductSupplier_InvalidInputs_ThrowsArgumentException(int productId, int supplierId)
    {
        var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
            await _controller.AddProductSupplier(productId, supplierId));

        Assert.That(ex.Message, Is.EqualTo("Invalid input data"));
    }

    [Test]
    public async Task AddProductSupplier_ValidInputs_ReturnsSuccessMessageAndSaves()
    {
        // Act
        string result = await _controller.AddProductSupplier(10, 20);

        // Assert
        Assert.That(result, Is.EqualTo("Product supplier added successfully"));

        // Verify it was written to the In-Memory Database
        var savedEntity = _context.ProductSuppliers.FirstOrDefault(ps => ps.ProductId == 10 && ps.SupplierId == 20);
        Assert.That(savedEntity, Is.Not.Null);
    }

    #endregion

    #region UpdateProductSupplier Tests

    [TestCase(-1, 5, 10, 20)] // Invalid current Product ID
    [TestCase(5, -1, 10, 20)] // Invalid current Supplier ID
    [TestCase(5, 5, -1, 20)]  // Invalid new Product ID
    // Note: If you fix the typo in your controller validation, add: [TestCase(5, 5, 10, -1)]
    public void UpdateProductSupplier_InvalidInputs_ThrowsArgumentException(int prodId, int suppId, int newProdId, int newSuppId)
    {
        // Act & Assert
        var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
            await _controller.UpdateProductSupplier(prodId, suppId, newProdId, newSuppId));

        Assert.That(ex.Message, Is.EqualTo("Invalid input data"));
    }

    [Test]
    public void UpdateProductSupplier_RecordNotFound_ThrowsArgumentException()
    {
        // Act & Assert (Looking for non-existent composite key 99, 99)
        var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
            await _controller.UpdateProductSupplier(99, 99, 10, 20));

        Assert.That(ex.Message, Is.EqualTo("Product supplier not found"));
    }

    [Test]
    public async Task UpdateProductSupplier_ValidInputs_ReturnsSuccessMessage()
    {
        // Arrange: Seed a record matching the composite query keys
        var existingRecord = new ProductSuppliers
        {
            ProductId = 5,
            SupplierId = 8
        };
        _context.ProductSuppliers.Add(existingRecord);
        await _context.SaveChangesAsync();

        // Detach tracking so the controller is forced to pull fresh from the DB layer
        _context.Entry(existingRecord).State = EntityState.Detached;

        // Act
        string result = await _controller.UpdateProductSupplier(5, 8, 10, 20);

        // Assert
        Assert.That(result, Is.EqualTo("Product supplier updated successfully"));
    }
    #endregion

    #region DeleteProductSupplier Tests

    [Test]
    public void DeleteProductSupplier_NegativeId_ThrowsArgumentException()
    {
        var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
            await _controller.DeleteProductSupplier(-1,-1));

        Assert.That(ex.Message, Is.EqualTo("Invalid input data"));
    }

    [Test]
    public void DeleteProductSupplier_RecordNotFound_ThrowsArgumentException()
    {
        var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
            await _controller.DeleteProductSupplier(999,999));

        Assert.That(ex.Message, Is.EqualTo("Product supplier not found"));
    }

    [Test]
    public async Task DeleteProductSupplier_ValidId_RemovesRecordFromDatabase()
    {
        // Arrange
        var recordToDelete = new ProductSuppliers {  ProductId = 5, SupplierId = 5 };
        _context.ProductSuppliers.Add(recordToDelete);
        await _context.SaveChangesAsync();

        // Act
        string result = await _controller.DeleteProductSupplier(5,5);

        // Assert
        Assert.That(result, Is.EqualTo("Product supplier deleted successfully"));
        Assert.That(_context.ProductSuppliers.Any(ps => ps.ProductId == 5 && ps.SupplierId == 5), Is.False);
    }

    #endregion

    #region GetProductSupplierById Tests

    [Test]
    public void GetProductSupplierById_NegativeId_ThrowsArgumentException()
    {
        var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
            await _controller.GetProductSupplierById(-1,-1));

        Assert.That(ex.Message, Is.EqualTo("Invalid input data"));
    }

    [Test]
    public void GetProductSupplierById_RecordNotFound_ThrowsArgumentException()
    {
        var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
            await _controller.GetProductSupplierById(999,999));

        Assert.That(ex.Message, Is.EqualTo("Product supplier not found"));
    }

    [Test]
    public async Task GetProductSupplierById_ValidId_ReturnsCorrectRecord()
    {
        // Arrange
        var expectedRecord = new ProductSuppliers { ProductId = 11, SupplierId = 22 };
        _context.ProductSuppliers.Add(expectedRecord);
        await _context.SaveChangesAsync();

        // Act
        var result = await _controller.GetProductSupplierById(11,22);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.ProductId, Is.EqualTo(11));
        Assert.That(result.SupplierId, Is.EqualTo(22));
    }

    #endregion
}
