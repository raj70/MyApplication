using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Rs.App.Core.Mvc.Client.Sale.Models;

namespace Rs.App.Core.Mvc.Client.Sale.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        public IActionResult Index([FromQuery] string code)
        {
            var statusCode = new StatusCodeModel();

            statusCode.RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            statusCode.ErrorStatusCode = code;

            statusCode.Message = "";

            if (code == "400") {
                statusCode.Message = "Bad Request";
            }
            else if (code == "401") {
                statusCode.Message = "Unauthorized";
            }
            else if (code == "404")
            {
                statusCode.Message = "Resource does not exist";
            }
            
            if( code == "500")
            {
                statusCode.Message = "Internal Server Error";
            }
            else if(code == "501")
            {
                statusCode.Message = "Not Implemented";
            }

            return View(statusCode);
        }
    }
}