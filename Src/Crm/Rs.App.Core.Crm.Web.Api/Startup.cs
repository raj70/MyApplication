using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rs.App.Core.Crm.Infra.Repository;
using Rs.App.Core.Crm.Application.Services;
using Rs.App.Core.Crm.Infra.Validation;
using Rs.App.Core.Crm.Web.Api.AppConfig;
using Rs.App.Core.Crm.Web.Api.CustomMiddleware;
using Rs.App.Core.Crm.Web.Api.Filters;

namespace Rs.App.Core.Crm.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; private set; }
        public ILogger Logger { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            services
                .AddControllers()                
                .AddFluentValidation(opt =>
                {
                    opt.RegisterValidatorsFromAssemblyContaining<ContactClientModelValidator>();
                });

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options => {
                    options.Authority = Configuration.GetValue<string>("AuthHost");
                    if (Environment.IsDevelopment())
                    {
                        options.RequireHttpsMetadata = false; // for test
                    }
                    options.Audience = "api1_Crm";
                });

            //filters:
            services.AddScoped<ActionResultFilter>();

            services.AddDbsAndServices(Configuration);
            services.AddOpenApiDocument();
            services.AddAntiforgery();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddLog4Net();

            if (env.IsDevelopment())
            {                
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseGeneralExceptionHandler();
            app.UseDebugLoggerHandler();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
