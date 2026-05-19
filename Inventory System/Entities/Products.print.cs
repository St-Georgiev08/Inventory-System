using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Entities
{
    public partial class Products
    {
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Price: {Price}, Quantity: {Quantity}, Category: {Category.Name}\n" +
                $" Created By: {CreatedByUser.Username}, Updated By: {(UpdatedByUser != null ? UpdatedByUser.Username : "N/A")}\n";
        }
    }
}
