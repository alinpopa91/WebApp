using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using WebApp.BLL.Contracts;
using WebApp.DAL.Context;
using WebApp.DAL.Persistence.Abstract;
using WebApp.DAL.Utils;

namespace WebApp.BLL.Services
{
    public class CatalogService : ICatalogService
    {
        private IUnitOfWork _unitOfWork;

        public CatalogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public AuthRS auth(AuthRQ request, ClientRequest clientRequest)
        {
            return new AuthRS();
        }

        public SearchRS SearchArtDirectory(SearchRQ request)
        {
            var response = new SearchRS();

            var list = _unitOfWork.ArtDirectoryRepository.SearchArt(
            request.Name, request.Category, request.PriceMin, request.PriceMax,
            request.Size, request.Original, request.Signed, request.Page);

            response.ArtDirectory = list;
            response.Page = request.Page;

            return response;
        }

    }
}
