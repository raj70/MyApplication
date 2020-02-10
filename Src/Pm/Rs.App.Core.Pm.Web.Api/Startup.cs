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
using Rs.App.Core.Pm.Application.Dtos;
using Rs.App.Core.Pm.Application.Services;
using Rs.App.Core.Pm.Events;
using Rs.App.Core.Pm.Infra.Repository;
using Rs.App.Core.Pm.Infra.Validatation;

namespace Rs.App.Core.Pm.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining<ProductAddClientValidator>();
            });

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options => {
                    options.Authority = Configuration.GetValue<string>("AuthHost");

                    if (Environment.IsDevelopment())
                    {
                        options.RequireHttpsMetadata = false; // for test
                    }

                    options.Audience = "api1_Pm";
                });

            services.AddDbContext<ProductContext>(o => o.UseSqlServer(Configuration.GetConnectionString("pmConnString")));
            services.AddDbContext<AuditContext>(o => o.UseSqlServer(Configuration.GetConnectionString("pmConnString")));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IAuditRepository, AuditRepository>();
            services.AddScoped<IStockRepository, StockRepository>();

            services.AddScoped<IProductService, ProductService>();

            // Events 
            services.AddScoped<IDomainEvent<ProductAddDto>, ProductNewAddedEvent>();
            services.AddScoped<IDomainEvent<StockAddDto>, ProductStockAddedEvent>();
            services.AddScoped<IDomainEvent<StockRemoveDto>, ProductStockRemovedEvent>();
            services.AddScoped<IDomainEvent<ProductRemoveDto>, ProductRemovedEvent>();

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
            app.UseAuthentication();
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
