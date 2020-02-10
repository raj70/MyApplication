using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.App.Core.Mvc.Client.Sale.Utilities
{
    public static class PmServiceUrls
    {
        public static string GetAllProducts(this IConfiguration configuration)
        {
            return configuration.GetValue<string>("PmBaseUrl") + "/api/Product";
        }
    }
}
