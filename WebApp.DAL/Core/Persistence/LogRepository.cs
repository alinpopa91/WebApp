using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.DAL.Context;
using WebApp.DAL.Core.Repositories;
using WebApp.DAL.Persistence.Repositories;
using WebApp.DAL.Utils;

namespace WebApp.DAL.Core.Persistence
{
    public class LogRepository : Repository<Audit>, ILogRepository
    {
        public LogRepository(DbContext dbContext) : base(dbContext) { }    
        public async Task LogInfo(ClientRequest request, string message)
        {
            var audit = new Audit
            {
                Ipaddress = request.IP,
                UserAgent = request.UserAgent,
            };

            Add(audit);
            await Context.SaveChangesAsync();
        }
        public async Task LogError(ClientRequest request, string message)
        {
            var audit = new Audit
            {
                Ipaddress = request.IP,
                UserAgent = request.UserAgent,
            };

            Add(audit);
            await Context.SaveChangesAsync();
        }
    }
}
