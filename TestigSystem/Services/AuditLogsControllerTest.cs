using Inventory_System.Entities;
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
        [Test]
        public async Task AddAuditlogTest()
        {
            var context = TestDbShop.CreateContext();
            context.Add(new User
            {
                Username = "testuser",
                PasswordHash = "testpassword",
                Role = Inventory_System.Enums.RoleType.Client,
                PhoneNumber = "1234567890",
                Email = ""
            });
            await context.SaveChangesAsync();
            AuditLogsController auditLogs = new(context);
            await auditLogs.AddAuditLogs(0,"test","");
            Assert.That(await auditLogs.AddAuditLogs(1, "test", ""), Is.Not.Null);
        }
    }
}
