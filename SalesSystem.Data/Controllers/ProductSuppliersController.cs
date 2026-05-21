using SalesSystem.Data.Servises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Data.Controllers
{
    public class ProductSuppliersController
    {
        private readonly ProductSuppliersCRUD suppliersCRUD;
        public ProductSuppliersController()
        {
            suppliersCRUD = new();
        }
            public async Task<string> AddProductSupplier(int productId, int supplierId)
            {
                if (productId < 0 || supplierId < 0)
                {
                    throw new ArgumentException("Invalid input data");
                }
                await suppliersCRUD.Add(new Inventory_System.Entities.ProductSuppliers { ProductId = productId, SupplierId = supplierId });
                return "Product supplier added successfully";
            }
        public async Task<string> UpdateProductSupplier(int id, int productId, int supplierId)
        {
            if (id < 0 || productId < 0 || supplierId < 0)
            {
                throw new ArgumentException("Invalid input data");
            }
            if (await suppliersCRUD.GetById(id) == null)
            {
                throw new ArgumentException("Product supplier not found");
            }
            await suppliersCRUD.Update( productId, supplierId);
            return "Product supplier updated successfully";
        }
        public async Task<string> DeleteProductSupplier(int id)
        {
            if (id < 0)
            {
                
            }

        }
    }
}
