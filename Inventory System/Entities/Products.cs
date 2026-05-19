using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Entities
{
    public partial class Products
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }

        public User CreatedByUser { get; set; }
        public int CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }
        public User UpdatedByUser { get; set; }


        [Required]
        public int CategoryId { get; set; }
        public Categories Category { get; set; }
        public ICollection<ProductSuppliers> ProductSuppliers { get; set; } = new List<ProductSuppliers>();
        public ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();
    }
}
