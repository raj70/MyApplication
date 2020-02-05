using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rs.App.Core.Sales.Infra.Data.Repository;
using Rs.App.Core.Sales.Infra.Repository;

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
            services.AddControllers(); 
            
            services.AddDbContext<SaleContext>(o => o.UseSqlServer(Configuration.GetConnectionString("saleConnString")));
            services.AddDbContext<SalePersonContext>(o => o.UseSqlServer(Configuration.GetConnectionString("saleConnString")));
            services.AddDbContext<ProductContext>(o => o.UseSqlServer(Configuration.GetConnectionString("saleConnString")));
            services.AddDbContext<OrderContext>(o => o.UseSqlServer(Configuration.GetConnectionString("saleConnString")));
            services.AddDbContext<CustomerContext>(o => o.UseSqlServer(Configuration.GetConnectionString("saleConnString")));
            services.AddDbContext<OrderProductContext>(o => o.UseSqlServer(Configuration.GetConnectionString("saleConnString")));

            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<ISalePersonRepository, SalePersonRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderProductRepository, OrderProductRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
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
        }
    }
}
