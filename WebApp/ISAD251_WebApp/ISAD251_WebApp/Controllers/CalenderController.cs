using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ISAD251_WebApp.Models;

namespace ISAD251_WebApp.Controllers
{
    public class CalenderController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public CalenderController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Calender()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
