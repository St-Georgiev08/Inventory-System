using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Entities
{
    public class Categories
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string? Description { get; set; }

        public ICollection<Products> Products { get; set; } = new List<Products>();
    }
}
