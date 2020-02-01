using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rs.App.Core.Auth.Server.Models;

namespace Rs.App.Core.Auth.Server.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostEnvironment _environment;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IHostEnvironment environment)
        {
            _environment = environment;
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (_environment.IsDevelopment())
            {
                return View();
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Privacy()
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
