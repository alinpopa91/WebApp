using System;
using System.Collections.Generic;
using System.Text;
using WebApp.BLL.Contracts;
using WebApp.DAL.Context;

namespace WebApp.BLL.Services
{
    public interface ICatalogService
    {
        SearchRS SearchArtDirectory(SearchRQ request);
    }
}
