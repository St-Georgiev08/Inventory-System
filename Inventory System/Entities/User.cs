using Inventory_System.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Entities
{
    public class User
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

        public ICollection<Products> CreatedProducts { get; set; } = new List<Products>();
        public ICollection<Products> UpdatedProducts { get; set; } = new List<Products>();
        public ICollection<Orders> Orders { get; set; }
        = new List<Orders>();

        public ICollection<AuditLogs> AuditLogs { get; set; } = new List<AuditLogs>();
    }
}
