using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Rs.App.Core.Pm.Web.Api.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthEnquiryMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthEnquiryMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var hasAuthHeader = httpContext.Request.Headers.TryGetValue("Authorization", out StringValues values);

            if (hasAuthHeader)
            {
                if(values.Count > 0)
                {
                    var value = values[0];                    
                }
            }

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuthEnquiryMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthEnquiryMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthEnquiryMiddleware>();
        }
    }
}
