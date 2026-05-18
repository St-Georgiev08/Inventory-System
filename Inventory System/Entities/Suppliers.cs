using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Entities
{
    public class Suppliers
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        [MaxLength(254)]
        public string? Email { get; set; }
        [Required]
        [MaxLength(250)]
        public string Address { get; set; }
        public ICollection<ProductSuppliers> ProductSuppliers { get; set; } = new List<ProductSuppliers>();
    }
}
