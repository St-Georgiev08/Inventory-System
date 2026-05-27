using Inventory_System;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingControllerUser.Helpers
{
    public class TestDbShop
    {
        public static SalesManagementSystemContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<SalesManagementSystemContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            SalesManagementSystemContext context = new SalesManagementSystemContext(options);
            context.Database.EnsureCreated();
            return context;
        }
    }
}
