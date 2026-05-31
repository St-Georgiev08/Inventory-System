using Inventory_System;
using Inventory_System.Entities;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Data.DTOs;
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
        private readonly UsersCRUD usersCRUD;
        private readonly SalesManagementSystemContext context;
        public AuditLogsController()
        {
            auditLogs = new AuditLogsCRUD();
            usersCRUD = new UsersCRUD();
            context = new SalesManagementSystemContext();
        }
        public AuditLogsController(SalesManagementSystemContext context)
        {
            auditLogs = new AuditLogsCRUD(context);
            usersCRUD = new UsersCRUD(context);
            context = new SalesManagementSystemContext();
        }
        public async Task<object> AddAuditLogs(int userId, string Action, string? desc)
        {
            DateTime timeSpan = DateTime.Now;
            if (userId < 0)
            {
                //throw new ArgumentException("Invalid id");
                return null;
            }
            var m = await usersCRUD.GetById(userId);
            if (m != null)
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
        public async Task<List<AuditsLogDto>> GetForGrid()
        {
            var list = context.AuditLogs.Include(x=>x.User).Select(x=> new AuditsLogDto
            {
                Id = x.UserId,
                UsersName = x.User.Username,
                Action = x.Action,
                Time = x.Timestamp,
                Description = x.Description
            }).ToListAsync();
            return await list;
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
