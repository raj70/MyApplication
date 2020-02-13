using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Rs.App.Core.Mvc.Client.Sale.Middleweres
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SameSiteMiddleware
    {
        private readonly RequestDelegate _next;

        public SameSiteMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            // TODO: need more info
            if (!httpContext.Response.Headers.ContainsKey("Set-Cookie"))
            {
                httpContext.Response.Headers.Add("Set-Cookie", "Secure;SameSite=Strict");
            }
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SameSiteMiddlewareExtensions
    {
        public static IApplicationBuilder UseSameSiteMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SameSiteMiddleware>();
        }
    }
}
