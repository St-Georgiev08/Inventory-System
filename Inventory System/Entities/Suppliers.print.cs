using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Entities
{
    public partial class Suppliers
    {
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Contact Info: {PhoneNumber} Email: {Email ?? "N/A"}\n" +
                $" Products: {string.Join(", ", ProductSuppliers.Select(ps => ps.Product.Name))}\n";
        }
    }
}
