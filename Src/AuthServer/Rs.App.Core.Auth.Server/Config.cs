using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.App.Core.Auth.Server
{
    // https://identityserver4.readthedocs.io/en/release/quickstarts/1_client_credentials.html
    public class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
           new IdentityResource[]
           {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
           };

        public static IEnumerable<ApiResource> Apis =>
           new ApiResource[]
           {
               // https://identityserver4.readthedocs.io/en/release/reference/api_resource.html?highlight=api1
               // https://identityserver4.readthedocs.io/en/release/topics/resources.html?highlight=api1
                new ApiResource("api1_Crm", "API #1"),
                new ApiResource("api1_Pm", "API #1"),
                new ApiResource("api1_Sm", "API #1"),
           };

        // Grant Type: https://www.digitalocean.com/community/tutorials/an-introduction-to-oauth-2
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "crm",
                    ClientName = "Customer Relation Management",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("8B853906-EC58-4F1F-87DF-A7EA754EF806".Sha256()) },

                    AllowedScopes = { "api1_Crm" }
                },

                new Client
                {
                    ClientId = "pm",
                    ClientName = "Product Management",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    RequirePkce = true,
                    ClientSecrets = { new Secret("A2F6FA17-962F-471F-93A6-EB0A49BA7110".Sha256()) },

                    AllowedScopes = { "api1_Pm" }
                },

                new Client
                {
                    ClientId = "sm",
                    ClientName = "Sales Management",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    RequirePkce = true,
                    ClientSecrets = { new Secret("F5FD61CA-4CB6-4A65-9FFB-4EF47AC8BC23".Sha256()) },

                    AllowedScopes = { "api1_Sm" }
                },

                new Client
                {
                    ClientId = "mvcClientSale",
                    ClientSecrets = { new Secret("3CA46704-2D4B-483F-BF81-D7686DC22973".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireConsent = false,
                    RequirePkce = true,

                    RedirectUris = { "http://localhost:5996/signin-oidc" },
                    PostLogoutRedirectUris  = { "http://localhost:5996/signout-callback-oidc"  },

                     AllowedScopes = new List<string>
                     {
                         IdentityServerConstants.StandardScopes.OpenId,
                         IdentityServerConstants.StandardScopes.Profile,
                         "api1_Crm",
                         "api1_Pm",
                         "api1_Sm",
                         "api2"
                     },
                    AllowOfflineAccess = true,
                }
            };
    }
}
