using Inventory_System.Entities;
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
    public class AuthenticateServiceTest
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
    }
}
