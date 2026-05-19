using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Entities
{
    public partial class AuditLogs
    {
        public override string ToString()
        {
            return $"Id: {Id}, UserId: {UserId}, Action: {Action} - Timestamp: {Timestamp}\n" +
                $" Description: {Description} \n";
        }
    }
}
