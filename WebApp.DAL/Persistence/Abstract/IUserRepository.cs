using System;
using System.Collections.Generic;
using System.Text;
using WebApp.DAL.Context;

namespace WebApp.DAL.Persistence.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
