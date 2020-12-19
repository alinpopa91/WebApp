using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApp.DAL.Core.Repositories;
using WebApp.DAL.Context;
using WebApp.DAL.Persistence.Repositories;

namespace WebApp.DAL.Core.Persistence
{
    public class SettingRepository : Repository<ApplicationSetting>, ISettingRepository
    {
        public SettingRepository(DbContext dbContext) : base(dbContext) { }

        public ApplicationSetting GetSetting(string key)
        {
            return SingleOrDefault(x => x.Key == key);
        }

        public new List<ApplicationSetting> GetAll()
        {
            return Set.OrderBy(s => s.Key).ToList();
        }

        public List<ApplicationSetting> GetAllForCache()
        {
            return Set.OrderBy(s => s.Key).AsNoTracking().ToList();
        }
    }
}
