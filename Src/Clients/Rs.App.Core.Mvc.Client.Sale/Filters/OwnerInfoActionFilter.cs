using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.App.Core.Mvc.Client.Sale.Filters
{
    public class OwnerInfoActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            context.HttpContext.Response.Headers.Add("Owner", new StringValues("Silk Software Developers"));
            context.HttpContext.Response.Headers.Add("Author", new StringValues("Rajen Shrestha"));
            context.HttpContext.Response.Headers.Add("Author Contact", new StringValues("Rajen.Shrestha@outlook.com"));
        }
    }
}
