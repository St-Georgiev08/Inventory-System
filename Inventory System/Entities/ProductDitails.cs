using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Entities
{
    public partial class ProductDetails
    {
        [Key]
        public int Id { get; set; }
      
        [Required]
        [MaxLength(int.MaxValue)]
        public string ImagePath { get; set; }

        [MaxLength(300)]
        public string? Description { get; set; }

        public User CreatedByUser { get; set; }
        [Required]
        public int CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }
        public User UpdatedByUser { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Products Products { get; set; }

    }
}
