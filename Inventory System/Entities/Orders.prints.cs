using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Entities
{
    public partial class Orders
    {
        public override string ToString()
        {
            return $"Id: {Id}, By User: {User.Username}\n" +
                $" OrderDate: {OrderDate}, TotalAmount: {TotalAmount}\n";
        }
    }
}
