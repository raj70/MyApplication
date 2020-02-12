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
            return configuration.GetValue<string>("CrmBaseUrl") + "/api/contact";
        }

        public static string CrmGetContact(this IConfiguration configuration, Guid id)
        {
            return $"{configuration.GetValue<string>("CrmBaseUrl")}/api/contact/{id}";
        }

        public static string CrmPostContact(this IConfiguration configuration)
        {
            return $"{configuration.GetValue<string>("CrmBaseUrl")}/api/contact";
        }

        public static string CrmPutContact(this IConfiguration configuration, Guid id)
        {
            return $"{configuration.GetValue<string>("CrmBaseUrl")}/api/contact/{id}";
        }
    }

    public static class CrmAddressUrls
    {
        public static string CrmAddress(this IConfiguration configuration, Guid id)
        {
            return $"{configuration.GetValue<string>("CrmBaseUrl")}/api/Address/{id}";
        }
    }

    public static class CrmNoteUrls
    {
        public static string CrmNotes(this IConfiguration configuration, Guid contactId)
        {
            return $"{configuration.GetValue<string>("CrmBaseUrl")}/api/Note/{contactId}";
        }
    }
}
