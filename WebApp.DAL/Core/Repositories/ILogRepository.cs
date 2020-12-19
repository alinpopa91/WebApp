using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.DAL.Context;
using WebApp.DAL.Persistence.Abstract;
using WebApp.DAL.Utils;

namespace WebApp.DAL.Core.Repositories
{
    public interface ILogRepository : IRepository<Audit>
    {
        Task LogInfo(ClientRequest request, string message);
        Task LogError(ClientRequest request, string message);
    }
}
