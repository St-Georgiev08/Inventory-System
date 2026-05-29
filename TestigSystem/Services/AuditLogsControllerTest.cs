using Inventory_System;
using Inventory_System.Entities;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Data.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingControllerUser.Helpers;

namespace TestigSystem.Services
{
    public class AuditLogsControllerTest
    {
        private SalesManagementSystemContext _context;
        private AuditLogsController _controller;

        [SetUp]
        public void SetUp()
        {
            // Create a fresh, unique in-memory database instance for each test execution
            var options = new DbContextOptionsBuilder<SalesManagementSystemContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new SalesManagementSystemContext(options);

            // Injecting the context so the controller uses our in-memory DB
            _controller = new AuditLogsController(_context);
        }
        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
        [Test]
        public async Task AddAuditLogs_UserIdIsNegative_ReturnsNullAndDoesNotSave()
        {
            // Act
            var result = await _controller.AddAuditLogs(-1, "Action", "Description");

            // Assert
            Assert.That(result, Is.Null);

            // Verify nothing was added to the database
            var count = await _context.AuditLogs.CountAsync();
            Assert.That(count, Is.EqualTo(0));
        }

        [Test]
        public async Task AddAuditLogs_UserDoesNotExistInLogs_ReturnsNullAndDoesNotSave()
        {
            // Arrange: Database is completely empty, so GetById(1) will return null
            int nonExistentUserId = 1;

            // Act
            var result = await _controller.AddAuditLogs(nonExistentUserId, "Login", "User logged in");

            // Assert
            Assert.That(result, Is.Null);

            var count = await _context.AuditLogs.CountAsync();
            Assert.That(count, Is.EqualTo(0));
        }

        [Test]
        public async Task AddAuditLogs_UserExistsInLogs_SavesNewLogAndReturnsNull()
        {
            // Arrange: Seed a USER with all required properties populated
            var existingUser = new User
            {
                Id = 99,
                Username = "testuser",
                PasswordHash = "hashed_password_placeholder", // Satisfies the required constraint
                PhoneNumber = "000-000-0000"                  // Satisfies the required constraint
            };

            _context.Users.Add(existingUser);
            await _context.SaveChangesAsync(); // This will pass successfully now

            // Act
            var result = await _controller.AddAuditLogs(99, "Update", "User updated settings");

            // Assert
            Assert.That(result, Is.Null);

            // Verify that the audit log was successfully written
            var allLogs = await _context.AuditLogs.ToListAsync();
            Assert.That(allLogs.Count, Is.EqualTo(1));
            Assert.That(allLogs[0].UserId, Is.EqualTo(99));
            Assert.That(allLogs[0].Action, Is.EqualTo("Update"));
            Assert.That(allLogs[0].Description, Is.EqualTo("User updated settings"));
        }


        #region GetAll Tests

        [Test]
        public void GetAll_NoLogsInSystem_ThrowsArgumentException()
        {
            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _controller.GetAll());
            Assert.That(ex.Message, Is.EqualTo("No logs in system"));
        }

        [Test]
        public async Task GetAll_LogsExist_ReturnsListOfLogs()
        {
            // Arrange: Seed data
            _context.AuditLogs.AddRange(new List<AuditLogs>
            {
                new() { UserId = 1, Action = "Action1", Timestamp = DateTime.Now },
                new() { UserId = 2, Action = "Action2", Timestamp = DateTime.Now }
            });
            await _context.SaveChangesAsync();

            // Act
            var result = await _controller.GetAll();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Action, Is.EqualTo("Action1"));
        }

        #endregion
    }
}
