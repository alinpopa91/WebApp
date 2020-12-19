using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApp.DAL.Context;
using WebApp.DAL.Persistence.Abstract;

namespace WebApp.DAL.Persistence.Repositories
{
    public class ArtDirectoryRepository : Repository<ArtDirectory>, IArtDirectoryRepository
    {
        public ArtDirectoryRepository(DbContext dbContext) : base(dbContext) { }

        public List<ArtDirectory> SearchArt(
            string? Name, int? Category, decimal? PriceMin, 
            decimal? PriceMax, string? Size, string? Original, 
            bool? Signed, int Page = 0)
        {
            var result = new List<ArtDirectory>();

            try
            {
                var queryParams = new List<SqlParameter>();
                AddCustomParameter("@Name", Name, ref queryParams);
                AddCustomParameter("@Category", Category, ref queryParams);
                AddCustomParameter("@PriceMin", PriceMin, ref queryParams);
                AddCustomParameter("@PriceMax", PriceMax, ref queryParams);
                AddCustomParameter("@Size", Size, ref queryParams);
                AddCustomParameter("@Original", Original, ref queryParams);
                AddCustomParameter("@Signed", Signed, ref queryParams);
                AddCustomParameter("@Page", Page, ref queryParams);
                result = SPGet<ArtDirectory>("[dbo].[SearchArt]", queryParams);
            }
            catch (Exception e)
            { 
            }

            return result;
        }

        private SqlParameter AddCustomParameter(string paramName, object paramValue, ref List<SqlParameter> paramList)
        {
            SqlParameter result = null;
            if (paramValue != null)
            {
                result = new SqlParameter(paramName, paramValue);
                paramList.Add(result);
            }

            return result;
        }

    }
}
