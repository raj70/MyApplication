using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rs.App.Core.Auth.Server.Models;

namespace Rs.App.Core.Auth.Server.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IHostEnvironment _environment;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IIdentityServerInteractionService interaction, ILogger<HomeController> logger, IHostEnvironment environment)
        {
            _interaction = interaction;
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

        public async Task<IActionResult> Error(string errorId)
        {
            var vm = new ErrorViewModel();

            // retrieve error details from identityserver
            var message = await _interaction.GetErrorContextAsync(errorId);
            if (message != null)
            {
                vm.Error = message;

                if (!_environment.IsDevelopment())
                {
                    // only show in development
                    message.ErrorDescription = null;
                }
            }

            return View("Error", vm);
        }
    }
}
