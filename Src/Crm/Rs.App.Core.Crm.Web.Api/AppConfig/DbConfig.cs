using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rs.App.Core.Crm.Infra.Repository;
using Rs.App.Core.Crm.Infra.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Web.Api.AppConfig
{
    public static class DbConfig
    {
        public static void AddDbsAndServices(this IServiceCollection services, IConfiguration configuration)
        {
            // databases
            services.AddDbContext<ContactContext>(o => o.UseSqlServer(configuration.GetConnectionString("CrmConnString")));
            services.AddDbContext<TitleContext>(o => o.UseSqlServer(configuration.GetConnectionString("CrmConnString")));
            services.AddDbContext<NoteContext>(o => o.UseSqlServer(configuration.GetConnectionString("CrmConnString")));
            services.AddDbContext<AddressContext>(o => o.UseSqlServer(configuration.GetConnectionString("CrmConnString")));

            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ITitleRepository, TitleRepository>();
            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<ITitleService, TitleService>();
        }
    }
}
