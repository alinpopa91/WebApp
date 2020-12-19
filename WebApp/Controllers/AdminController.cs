using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Authorize(Policy = "AdminAccessAuthorize")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}