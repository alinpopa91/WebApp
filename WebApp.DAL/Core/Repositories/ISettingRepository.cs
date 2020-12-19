using System;
using System.Collections.Generic;
using System.Text;
using WebApp.DAL.Context;
using WebApp.DAL.Persistence.Abstract;

namespace WebApp.DAL.Core.Repositories
{
    public interface ISettingRepository : IRepository<ApplicationSetting>
    {
        ApplicationSetting GetSetting(string key);

        new List<ApplicationSetting> GetAll();
        List<ApplicationSetting> GetAllForCache();
    }
}
