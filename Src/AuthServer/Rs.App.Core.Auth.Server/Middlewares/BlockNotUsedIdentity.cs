using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Rs.App.Core.Auth.Server.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class BlockNotUseIdentity
    {
        private readonly RequestDelegate _next;

        public BlockNotUseIdentity(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var url = httpContext.Request.Path;
            if (url.HasValue)
            {
                if (url.Value != "/" &&
                    !url.Value.Contains("Index") &&
                    url.Value.ToLower() != "/Identity/Account/Login".ToLower() &&
                    url.Value.ToLower() != "/Identity/Account/Manage/ChangePassword".ToLower() &&
                    url.Value.ToLower() != "/Identity/Account/Logout".ToLower() &&
                    url.Value.ToLower() != "/Identity/Account/Register".ToLower() &&
                    url.Value.ToLower() != "/Identity/Account/ForgotPassword".ToLower() &&
                    url.Value.ToLower() != "/Identity/Account/ForgotPasswordConfirmation".ToLower() &&
                    url.Value.ToLower() != "/Identity/Account/Manage".ToLower() &&
                    url.Value.ToLower() != "/UserAdmin".ToLower())               
                {
                    if (url != "/Home/ErrorIdentity")
                    {
                        httpContext.Response.Redirect("/Home/ErrorIdentity");
                    }
                }
            }
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class BlockNotUsedIdentityExtensions
    {
        public static IApplicationBuilder UseBlockNodUsedIdentity(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BlockNotUseIdentity>();
        }
    }
}
