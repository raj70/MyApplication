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
using Rs.App.Core.Crm.Infra.Repository;
using Rs.App.Core.Crm.Infra.Services;

namespace Rs.App.Core.Crm.Web.Api
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

            services.AddDbContext<ContactContext>(o => o.UseSqlServer(Configuration.GetConnectionString("CrmConnString")));
            services.AddDbContext<TitleContext>(o => o.UseSqlServer(Configuration.GetConnectionString("CrmConnString")));
            services.AddDbContext<NoteContext>(o => o.UseSqlServer(Configuration.GetConnectionString("CrmConnString")));
            services.AddDbContext<AddressContext>(o => o.UseSqlServer(Configuration.GetConnectionString("CrmConnString")));

            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<ITitleRepository, TitleRepository>();
            services.AddTransient<INoteRepository, NoteRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();

            services.AddTransient<IContactService, ContactService>();
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
