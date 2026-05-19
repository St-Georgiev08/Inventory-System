using Inventory_System.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Entities
{
    public partial class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Username { get; set; }
        [Required]
        [MaxLength(256)]
        public string PasswordHash { get; set; }
        [Required]

        public RoleType Role { get; set; }
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        [MaxLength(254)]
        public string? Email { get; set; }


        public ICollection<ProductDetails> CreatedProducts { get; set; } = new List<ProductDetails>();
        public ICollection<ProductDetails> UpdatedProducts { get; set; } = new List<ProductDetails>();
        public ICollection<Orders> Orders { get; set; }
        = new List<Orders>();

        public ICollection<AuditLogs> AuditLogs { get; set; } = new List<AuditLogs>();
    }
}
