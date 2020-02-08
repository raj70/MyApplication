/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 2/8/2020 2:40:15 PM
*/
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rs.App.Core.Sales.Application.ClientModel;
using Rs.App.Core.Sales.Application.Services;
using Rs.App.Core.Sales.Events;
using Rs.App.Core.Sales.Infra.Data.Repository;
using Rs.App.Core.Sales.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Sales.Infra.Data.Extensions
{
    public static class ServiceStartExtension
    {
        public static IServiceCollection AddAppDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SaleContext>(o => o.UseSqlServer(configuration.GetConnectionString("saleConnString")));
            services.AddDbContext<SalePersonContext>(o => o.UseSqlServer(configuration.GetConnectionString("saleConnString")));
            services.AddDbContext<ProductContext>(o => o.UseSqlServer(configuration.GetConnectionString("saleConnString")));
            services.AddDbContext<OrderContext>(o => o.UseSqlServer(configuration.GetConnectionString("saleConnString")));
            services.AddDbContext<CustomerContext>(o => o.UseSqlServer(configuration.GetConnectionString("saleConnString")));
            services.AddDbContext<OrderProductContext>(o => o.UseSqlServer(configuration.GetConnectionString("saleConnString")));
            services.AddDbContext<AuditContext>(o => o.UseSqlServer(configuration.GetConnectionString("saleConnString")));         

            return services;
        }

        public static IServiceCollection AddAppRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<ISalePersonRepository, SalePersonRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderProductRepository, OrderProductRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAuditRepository, AuditRepository>();

            services.AddScoped<IDomainEvent<SaleAddClientModel>, SaleAddedEvent>();
            //OrderAddClientModel
            services.AddScoped<IDomainEvent<OrderAddClientModel>, OrderAddedEvent>();
            services.AddScoped<IDomainEvent<SaleUpdateClientModel>, SaleUpdateEvent>();
            services.AddScoped<ISaleService, SaleService>();

            return services;
        }

        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IDomainEvent<SaleAddClientModel>, SaleAddedEvent>();
            //OrderAddClientModel
            services.AddScoped<IDomainEvent<OrderAddClientModel>, OrderAddedEvent>();
            services.AddScoped<IDomainEvent<SaleUpdateClientModel>, SaleUpdateEvent>();
            services.AddScoped<ISaleService, SaleService>();

            return services;
        }
    }
}

