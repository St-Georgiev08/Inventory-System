using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Entities
{
    [PrimaryKey(nameof(ProductId), nameof(SupplierId))]
    public class ProductSuppliers
    {
        

        public int ProductId { get; set; }
        public Products Product { get; set; }
        
        public int SupplierId { get; set; }
        public Suppliers Supplier { get; set; }
    }
}
