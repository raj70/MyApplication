using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.App.Core.Mvc.Client.Sale.Utilities
{
    public static class CrmServiceUrls
    {
        public static string CrmGetContacts(this IConfiguration configuration)
        {
            return configuration.GetValue<string>("CrmBaseUrl")+"/api/contact";
        }
    }
}
