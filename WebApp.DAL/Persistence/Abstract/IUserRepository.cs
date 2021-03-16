using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.DAL.Context;

namespace WebApp.DAL.Persistence.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Login(string username, string password);
    }
}
