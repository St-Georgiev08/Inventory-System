using Inventory_System;
using Inventory_System.Entities;
using SalesSystem.Business.Servises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Business.Controllers
{
    public class SuppliersController
    {
        private readonly SuppliersCRUD suppliers;
        public SuppliersController()
        {
            suppliers = new();
        }
        public SuppliersController(SalesManagementSystemContext context)
        {
            suppliers = new(context);
        }
        public async Task<List<Inventory_System.Entities.Suppliers>> GetAll()
        {
            int count = await suppliers.Count();
            if(count == 0)
            {
                throw new ArgumentException("No suppliers in system");
            }
            return await suppliers.GetAll();
        }
         public async Task<Suppliers> GetById(int id)
        {
            if(id < 0)
            {
                throw new ArgumentException("Invalid supplier ID");
            }
            var supplier = await suppliers.GetById(id);
            if(supplier == null)
            {
                throw new ArgumentException("Supplier not found");
            }
            return supplier;
        }
         public async Task<string> Add(string name, string phoneNum, string? email, string addres)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phoneNum) || string.IsNullOrEmpty(addres))
            {
                throw new ArgumentException("Name, Phone Number and Address are required");
            }
             await suppliers.Add(new Suppliers
             {
                 Name = name,
                 PhoneNumber = phoneNum,
                 Email = email,
                 Address = addres
             });
             return "Supplier added successfully";
        }
         public async Task<string> Update(int id, string name, string phoneNum, string? email, string addres)
        {
             if (id < 0 || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phoneNum) || string.IsNullOrEmpty(addres))
             {
                 throw new ArgumentException("Invalid input data");
             }
             await suppliers.Update(id, name, phoneNum, email, addres);
             return "Supplier updated successfully";
        }
    }
}
