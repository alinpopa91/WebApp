using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApp.DAL.Context;
using WebApp.DAL.Persistence.Abstract;

namespace WebApp.DAL.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext) { }
    }
}
