using System;
using System.Collections.Generic;
using System.Linq;
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
using Rs.App.Core.Sales.Application.ClientModel;
using Rs.App.Core.Sales.Application.Services;
using Rs.App.Core.Sales.Events;
using Rs.App.Core.Sales.Infra.Data.Extensions;
using Rs.App.Core.Sales.Infra.Data.Repository;
using Rs.App.Core.Sales.Infra.Repository;
using Rs.App.Core.Sales.Infra.Validation;

namespace Rs.App.Core.Sales.Web.Api
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
            services
                .AddControllers()
                .AddFluentValidation(o =>
                {
                    o.RegisterValidatorsFromAssemblyContaining<SaleAddModelValidator>();
                });

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options => {
                    options.Authority = Configuration.GetValue<string>("AuthHost");
                    options.RequireHttpsMetadata = false; // for test

                    options.Audience = "api1";
                });

            services.AddAppDbContexts(Configuration);
            services.AddAppRepositories();
            services.AddAppServices();

            services.AddOpenApiDocument();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOpenApi();
            app.UseSwaggerUi3(); // serve Swagger UI
        }
    }
}
