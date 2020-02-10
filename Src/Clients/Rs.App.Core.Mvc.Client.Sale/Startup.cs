using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Rs.App.Core.Mvc.Client.Sale
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(o=> {
                o.EnableEndpointRouting = false;
            });
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
             .AddCookie("Cookies")
             .AddOpenIdConnect("oidc", options =>
             {
                 options.Authority = Configuration.GetValue<string>("AuthBaseUrl");

                 options.RequireHttpsMetadata = false;

                 options.ClientId = "mvcClientSale";
                 options.ClientSecret = "3CA46704-2D4B-483F-BF81-D7686DC22973";
                 options.ResponseType = "code";

                 options.SaveTokens = true;

                 options.Scope.Add("api1_Crm");
                 options.Scope.Add("api1_Pm");
                 options.Scope.Add("api1_Sm");
                 options.Scope.Add("offline_access");
             });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMvc(routes =>
            {
                routes.MapAreaRoute(
                  name: "Crms",
                  areaName: "Crms",
                  template: "Crms/{controller}/{action=Index}/{id?}"
                );

                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapAreaControllerRoute(
            //       name: "crms",
            //       areaName: "Crms",
            //       pattern: "Crms/{controller=Customer}/{action}/{id}");

            //    endpoints.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");
            //    endpoints.MapDefaultControllerRoute().RequireAuthorization();

            //});
        }
    }
}
