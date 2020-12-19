using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.BLL.Contracts;
using WebApp.BLL.Services;
using WebApp.DAL.Context;
using WebApp.DAL.Core.Repositories;
using WebApp.Filters;

namespace WebApp.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private ICatalogService _catalogService;
        private ILogRepository _logRepository;
        public InventoryController(ICatalogService catalogService, ILogRepository logRepository)
        {
            _catalogService = catalogService;
            _logRepository = logRepository;
        }
        // GET: api/Inventory
        [HttpGet]
        [ModelStateValidationActionFilterAttribute]
        public IEnumerable<ArtDirectory> Get()
        {
            var searchRQ = new SearchRQ
            {
                Name = "Pictura a",
                Category = 1,
                PriceMin = 74,
                PriceMax = 78,
                Size = "M",
                Original = "ORIGINAL",
                Signed = true,
                Page = 0
            };

            var response = _catalogService.SearchArtDirectory(searchRQ);

            return response.ArtDirectory.Select(index => new ArtDirectory
            {
                Name = index.Name,
                Description = index.Description,
                Price = index.Price,
                Original = index.Original
            })
            .ToArray();
        }

        //// GET: api/Inventory/5
        //[HttpGet("{id}", Name = "Get")]
        //[ModelStateValidationActionFilterAttribute]
        //[Authorize(Policy = "UserAccessAuthorize")]
        //public string Get(string id)
        //{
        //    return "value";
        //}

        // POST: api/Inventory
        [HttpPost]
        public ActionResult Post(SearchRQ id)      
        {
            //var request = JsonConvert.DeserializeObject<SearchRQ>(id);
            var results = _catalogService.SearchArtDirectory(id);

            var json = JsonConvert.SerializeObject(results);
            return Ok(results);
        }

        // PUT: api/Inventory/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("api/[controller]/HoHo")]
        [ModelStateValidationActionFilterAttribute]
        [Authorize(Policy="UserAccessAuthorize")]
        public async Task<IActionResult> Hoho()
        {
            return BadRequest();
        }
    }
}
