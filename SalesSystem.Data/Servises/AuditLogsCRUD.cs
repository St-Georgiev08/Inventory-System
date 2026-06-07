using Inventory_System;
using Inventory_System.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Business.Servises
{
    public class AuditLogsCRUD
    {
        private readonly SalesManagementSystemContext _context;
        public AuditLogsCRUD()
        {
            _context = new SalesManagementSystemContext();
        }
        public AuditLogsCRUD(SalesManagementSystemContext context)
        {
            _context = context;
        }
        public async Task<int> Count()
        {
            return await _context.AuditLogs.CountAsync();
        }
        public async Task<List<AuditLogs>> GetAll()
        {
            return await _context.AuditLogs.Include(x=>x.User).ToListAsync();
        }
         public async Task<AuditLogs> GetById(int id)
        {
            return await _context.AuditLogs.FindAsync(id);
        }
         public async Task Add(AuditLogs log)
        {
            await _context.AuditLogs.AddAsync(log);
            await _context.SaveChangesAsync();
        }
    }
}
