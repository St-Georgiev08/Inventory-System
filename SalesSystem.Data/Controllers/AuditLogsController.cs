using Inventory_System.Entities;
using SalesSystem.Data.Servises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Data.Controllers
{
    public class AuditLogsController
    {
        private readonly AuditLogsCRUD auditLogs;
        public AuditLogsController()
        {
            auditLogs = new();
        }
        public async Task<List<AuditLogs>> GetAll()
        {
            int count = await auditLogs.Count();
            if(count == 0)
            {
                throw new ArgumentException("No logs in system");
            }
            return await auditLogs.GetAll();
        }
    }
}
