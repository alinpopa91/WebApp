using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.DAL.Context;
using WebApp.DAL.Persistence.Abstract;

namespace WebApp.DAL.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext) { }

        public async Task<User> Login(string username, string password)
        {
            var hashPassword = Utils.Utils.CreateMD5(password);
            var user = await Context.Set<User>().FirstOrDefaultAsync(a => a.UserName == username && a.Password == hashPassword);

            return user;
        }
    }
}
