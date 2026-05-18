using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Entities
{
    public class AuditLogs
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }
        [MaxLength(300)]
        public string? Description { get; set; }
    }
}
