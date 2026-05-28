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

namespace TestingControllerUser.Services
{
    public class AuthenticateServiceAndUserControllerTest
    {
        [Test]
        public async Task TestAuthenticateUserAsync()
        {
            var context = TestDbShop.CreateContext();
            var passwordHasher = new HashingPaswords();
            string inputPassword = await passwordHasher.HashPassword("testpassword");
            context.Add(new User
            {
                Username = "testuser",
                PasswordHash = inputPassword,
                Role = Inventory_System.Enums.RoleType.Client,
                PhoneNumber = "1234567890",
                Email = "gosho@gamil.com"
            });
            await context.SaveChangesAsync();
            UsersCotroller user = new(context);
            User? us = await user.AuthenticateUserAsync("testuser", "testpassword");
            string m = us.Username;
            Assert.That(us.Username, Is.EqualTo("testuser"));
            Assert.That(us, Is.Not.Null);
        }
        [Test]
        public async Task TestAuthenticateUserAsync_InvalidCredentials()
        {
            var context = TestDbShop.CreateContext();
            var passwordHasher = new HashingPaswords();
            string inputPassword = await passwordHasher.HashPassword("testpassword");
            context.Add(new User
            {
                Username = "testuser",
                PasswordHash = inputPassword,
                Role = Inventory_System.Enums.RoleType.Client,
                PhoneNumber = "1234567890",
                Email = ""
            });
            await context.SaveChangesAsync();
            UsersCotroller user = new(context);
            //User? us = await user.AuthenticateUserAsync("testuser", "wrongpassword");
            //Assert.That(us, Is.Null);
            
            Assert.ThrowsAsync<ArgumentException>(async () => await user.AuthenticateUserAsync("nonexistentuser", "testpassword"));
        }
        [Test]
        public async Task TestAuthenticateUserAsync_NotFoundUser()
        {
            var context = TestDbShop.CreateContext();
            var passwordHasher = new HashingPaswords();
            string inputPassword = await passwordHasher.HashPassword("testpassword");
            context.Add(new User
            {
                Username = "testuser",
                PasswordHash = inputPassword,
                Role = Inventory_System.Enums.RoleType.Client,
                PhoneNumber = "1234567890",
                Email = ""
            });
            await context.SaveChangesAsync();
            UsersCotroller users = new(context);
            Assert.ThrowsAsync<ArgumentException>(async () => await users.AuthenticateUserAsync("nonexistentuser", "testpassword"));
        }
        [Test]
        public async Task TestAuthenticateUserAsync_WrongPassword()
        {
            var context = TestDbShop.CreateContext();
            var passwordHasher = new HashingPaswords();
            string inputPassword = await passwordHasher.HashPassword("testpassword");
            context.Add(new User
            {
                Username = "testuser",
                PasswordHash = inputPassword,
                Role = Inventory_System.Enums.RoleType.Client,
                PhoneNumber = "1234567890",
                Email = ""
            });
            await context.SaveChangesAsync();
            UsersCotroller users = new(context);
            Assert.ThrowsAsync<ArgumentException>(async () => await users.AuthenticateUserAsync("testuser", "wrongpassword"));
        }
        [Test]
        public async Task DeleteUserAsync()
        {
            var context = TestDbShop.CreateContext();
            var passwordHasher = new HashingPaswords();
            string inputPassword = await passwordHasher.HashPassword("testpassword");
            context.Add(new User
            {
                Username = "testuser",
                PasswordHash = inputPassword,
                Role = Inventory_System.Enums.RoleType.Client,
                PhoneNumber = "1234567890",
                Email = ""
            });
            await context.SaveChangesAsync();
            UsersCotroller users = new(context);
            await users.DeleteUserAsync(0);
            Assert.That(await context.Users.FirstOrDefaultAsync(u => u.Id == 0), Is.Null);
        }
        [Test]
        public async Task DeleteUserAsync_InvalidId()
        {
            var context = TestDbShop.CreateContext();
            var passwordHasher = new HashingPaswords();
            string inputPassword = await passwordHasher.HashPassword("testpassword");
            context.Add(new User
            {
                Username = "testuser",
                PasswordHash = inputPassword,
                Role = Inventory_System.Enums.RoleType.Client,
                PhoneNumber = "1234567890",
                Email = ""
            });
            await context.SaveChangesAsync();
            UsersCotroller users = new(context);
            Assert.ThrowsAsync<ArgumentException>(async () => await users.DeleteUserAsync(-1));
        }
        [Test]
        public async Task UpdateUserAsync()
        {
            var context = TestDbShop.CreateContext();
            var passwordHasher = new HashingPaswords();
            string inputPassword = await passwordHasher.HashPassword("testpassword");
            context.Add(new User
            {
                Username = "testuser",
                PasswordHash = inputPassword,
                Role = Inventory_System.Enums.RoleType.Client,
                PhoneNumber = "1234567890",
                Email = ""
            });
            await context.SaveChangesAsync();
            UsersCotroller users = new(context);
            Assert.That(await users.UpdateUserAsync(0, "updateduser", "newpassword", "Client", "0987654321", "updatedemail@example.com"), Is.EqualTo("User updated successfully"));
        }
        [Test]
        public async Task UpdateUserAsync_InvalidId()
        {
            var context = TestDbShop.CreateContext();
            var passwordHasher = new HashingPaswords();
            string inputPassword = await passwordHasher.HashPassword("testpassword");
            context.Add(new User
            {
                Username = "testuser",
                PasswordHash = inputPassword,
                Role = Inventory_System.Enums.RoleType.Client,
                PhoneNumber = "1234567890",
                Email = ""
            });
            await context.SaveChangesAsync();
            UsersCotroller users = new(context);
            Assert.ThrowsAsync<ArgumentException>(async () => await users.UpdateUserAsync(-1, "updateduser", "newpassword", "Client", "0987654321", "updatedemail@example.com"));
        }
        [Test]
        public async Task UpdateUserAsync_InvalidData()
        {
            var context = TestDbShop.CreateContext();
            var passwordHasher = new HashingPaswords();
            string inputPassword = await passwordHasher.HashPassword("testpassword");
            context.Add(new User
            {
                Username = "testuser",
                PasswordHash = inputPassword,
                Role = Inventory_System.Enums.RoleType.Client,
                PhoneNumber = "1234567890",
                Email = ""
            });
            await context.SaveChangesAsync();
            UsersCotroller users = new(context);
            Assert.ThrowsAsync<ArgumentException>(async () => await users.UpdateUserAsync(0, "updateduser", "", "Client", "0987654321", "updatedemail@example.com"));
        }
        [Test]
        public async Task UpdateUserAsync_NotFound()
        {
            var context = TestDbShop.CreateContext();
            UsersCotroller users = new(context);
            Assert.That(await users.UpdateUserAsync(10, "updateduser", "test", "Client", "0987654321", "updatedemail@example.com"), Is.EqualTo("Not found"));
        }
        [Test]
        public async Task AddUserAsync()
        {
            var context = TestDbShop.CreateContext();
            UsersCotroller users = new(context);
            string us = await users.AddUserAsync("Name", "testpassword", "Client","0895650627","");
            Assert.That(us, Is.EqualTo("User added successfully"));
        }
        [Test]
        public async Task AddUserAsync_InvalidData()
        {
            var context = TestDbShop.CreateContext();
            UsersCotroller users = new(context);
            Assert.ThrowsAsync<ArgumentException>(async () => await users.AddUserAsync("", "testpassword", "Client", "0895650627", ""));
        }
        [Test]
        public async Task AddUserAsync_InvalidRole()
        {
            var context = TestDbShop.CreateContext();
            UsersCotroller users = new(context);
            Assert.ThrowsAsync<ArgumentException>(async () => await users.AddUserAsync("Pepi", "testpassword", "cl", "0895650627", ""));
        }
        [Test]
        public async Task GetUserAsync()
        {
            var context = TestDbShop.CreateContext();
            UsersCotroller users = new(context);
            context.Add(new User
            {
                Username = "testuser",
                PasswordHash = "pass",
                Role = Inventory_System.Enums.RoleType.Client,
                PhoneNumber = "1234567890",
                Email = ""
            });
            await context.SaveChangesAsync();
            Assert.That(await users.GetUserAsync(1), Is.EqualTo(await context.Users.FirstOrDefaultAsync(x => x.Id == 1)));
        }
        [Test]
        public async Task GetUserAsync_InvalidId()
        {
            var context = TestDbShop.CreateContext();
            UsersCotroller users = new(context);
            Assert.ThrowsAsync<ArgumentException>(async () => await users.GetUserAsync(-1));
        }
        [Test]
        public async Task GetUserAsync_InvalidData()
        {
            var context = TestDbShop.CreateContext();
            UsersCotroller users = new(context);
            context.Add(new User
            {
                Username = "testuser",
                PasswordHash = "pass",
                Role = Inventory_System.Enums.RoleType.Client,
                PhoneNumber = "1234567890",
                Email = ""
            });
            await context.SaveChangesAsync();
            Assert.ThrowsAsync<ArgumentException>(async () => await users.GetUserAsync(3));
        }
        [Test]
        public async Task GetAllUsersAsync()
        {
            var context = TestDbShop.CreateContext();
            UsersCotroller users = new(context);
            context.Add(new User
            {
                Username = "testuser",
                PasswordHash = "pass",
                Role = Inventory_System.Enums.RoleType.Client,
                PhoneNumber = "1234567890",
                Email = ""
            });
            await context.SaveChangesAsync();
            Assert.That((await users.GetAllUsersAsync()).Count, Is.EqualTo(2));
        }
        [Test]
        public async Task GetAllUsersAsync_Invalid()
        {
            var context = TestDbShop.CreateContext();
            UsersCotroller users = new(context);
            await users.DeleteUserAsync(1);
            await context.SaveChangesAsync();
            Assert.ThrowsAsync<ArgumentException>(async () => await users.GetAllUsersAsync()); ;
        }
    }
}
