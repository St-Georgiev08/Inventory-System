using Inventory_System.Entities;
using SalesSystem.Data.Controllers;
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
            context.Add(new Inventory_System.Entities.User
            {
                Username = "testuser",
                PasswordHash = "testpassword",
                Role = Inventory_System.Enums.RoleType.Client,
                PhoneNumber = "1234567890",
                Email = "gosho@gamil.com"
            });
            await context.SaveChangesAsync();
            UsersCotroller user = new();
           User? us = await user.AuthenticateUserAsync("testuser", "testpassword");
            
            Assert.Equals("testuser", us.Username);
            Assert.That()
        }
    }
}
