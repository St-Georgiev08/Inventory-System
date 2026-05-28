using Inventory_System;
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
            auditLogs = new AuditLogsCRUD();
        }
        public AuditLogsController(SalesManagementSystemContext context)
        {
            auditLogs = new AuditLogsCRUD(context);
        }
        public async Task<object> AddAuditLogs(int userId, string Action, string? desc)
        {
            DateTime timeSpan = DateTime.Now;
            if (userId < 0)
            {
                //throw new ArgumentException("Invalid id");
                return null;
            }
            if (await auditLogs.GetById(userId) != null)
            {
                AuditLogs logs = new()
                {
                    UserId = userId,
                    Action = Action,
                    Timestamp = timeSpan,
                    Description = desc
                };
                await auditLogs.Add(logs);
               
            }
            return null;
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
