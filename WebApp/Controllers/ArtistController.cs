using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Authorize(Policy = "UserAccessAuthorize")]
    public class ArtistController : Controller
    {
        [Authorize(Policy = "UserAccessAuthorize")]
        public IActionResult Index()
        {
            return Content("An API listing authors of docs.asp.net.");
        }
    }
}