using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Entities
{
    public class Customers
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(60)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        [MaxLength(254)]
        public string? Email { get; set; }

        public ICollection<Orders> Orders { get; set; } = new List<Orders>();
    }
}
