using Inventory_System.Entities;
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
        public ProductSuppliersController(ProductSuppliersCRUD suppliersCRUD)
        {
            this.suppliersCRUD = suppliersCRUD;
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
        public async Task<string> UpdateProductSupplier(int productId, int supplierId, int productIdnew, int supplierIdnew)
        {
            if (productId < 0 || supplierId < 0 || productIdnew < 0 || productId < 0)
            {
                throw new ArgumentException("Invalid input data");
            }
            if (await suppliersCRUD.GetById(productId,supplierId) == null)
            {
                throw new ArgumentException("Product supplier not found");
            }
            await suppliersCRUD.Update(productId, supplierId);
            return "Product supplier updated successfully";
        }
        public async Task<string> DeleteProductSupplier(int id, int sub)
        {
            if (id < 0)
            {
                throw new ArgumentException("Invalid input data");
            }
            if (await suppliersCRUD.GetById(id,sub) == null)
            {
                throw new ArgumentException("Product supplier not found");
            }
            await suppliersCRUD.Delete(id,sub);
            return "Product supplier deleted successfully";
        }
        public async Task<ProductSuppliers> GetProductSupplierById(int id,int prId)
        {
            if (id < 0)
            {
                throw new ArgumentException("Invalid input data");
            }
            var productSupplier = await suppliersCRUD.GetById(id,prId);
            if (productSupplier == null)
            {
                throw new ArgumentException("Product supplier not found");
            }
            return productSupplier;
        }
    }
}
