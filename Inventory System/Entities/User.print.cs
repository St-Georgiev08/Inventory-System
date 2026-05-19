using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Entities
{
    public partial class User
    {
        public override string ToString()
        {
            return $"Id: {Id}, Username: {Username}, Role: {Role}:\n" +
                $"Phone Number: {PhoneNumber}, Email: {Email}";
        }
    }
}
