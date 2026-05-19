using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Entities
{
    public partial class ProductDetails
    {
        public override string ToString()
        {
            return $" Created By: {CreatedByUser.Username}, Updated By: {(UpdatedByUser != null ? UpdatedByUser.Username : "N/A")}\n";
        }
    }
}
