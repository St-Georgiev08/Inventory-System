using SalesSystem.Business.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestigSystem.Services
{
    public class AllConstructorsTest
    {
        [Test]
        public void Constructor()
        {
            AuditLogsController auditLogsController = new AuditLogsController();
            CategoriesController categoriesController = new CategoriesController();
            OrderItemsController orderItemsController = new OrderItemsController();
            OrdersController ordersController = new OrdersController();
            ProductDetailsController productDetailsController = new ProductDetailsController();
            ProductsController productsController = new ProductsController();
            ProductSuppliersController productSuppliersController = new ProductSuppliersController();
            SuppliersController suppliersController = new SuppliersController();
            UsersCotroller users = new();
        }
    }
}
