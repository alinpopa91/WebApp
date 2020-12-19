using System;
using System.Collections.Generic;
using System.Text;
using WebApp.DAL.Context;

namespace WebApp.DAL.Persistence.Abstract
{
    public interface IArtDirectoryRepository : IRepository<ArtDirectory>
    {
        List<ArtDirectory> SearchArt(
            string? Name, int? Category, decimal? PriceMin,
            decimal? PriceMax, string? Size, string? Original,
            bool? Signed, int Page = 0);
    }
}
