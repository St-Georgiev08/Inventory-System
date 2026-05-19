using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Entities
{
    public partial class Categories
    {
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name} \n Description: {Description}\n";
        }
    }
}
