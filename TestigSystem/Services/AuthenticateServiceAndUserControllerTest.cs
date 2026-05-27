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
            Assert.ThrowsAsync<ArgumentException>(async () => await users.UpdateUserAsync(-1, "updateduser", "newpassword", "Client", "0987654321", "updatedemail@example.com"));
        }
    }
}
