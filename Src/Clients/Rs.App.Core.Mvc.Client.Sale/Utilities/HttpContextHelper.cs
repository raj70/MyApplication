using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Rs.App.Core.Mvc.Client.Sale.Utilities
{
    public static class HttpContextHelper
    {
        public async static Task<HttpClient> CreateHttpAsync(this HttpContext httpContext)
        {
            var apiClient = new HttpClient();
            var accessToken = await httpContext.GetTokenAsync("access_token");
            apiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return apiClient;
        }
    }
}
