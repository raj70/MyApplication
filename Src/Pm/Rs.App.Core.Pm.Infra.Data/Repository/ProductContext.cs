/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/22/2020 3:42:48 PM
*/
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rs.App.Core.Pm.Domain;
using Rs.App.Core.Pm.Infra.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Pm.Infra.Repository
{

    // Add-Migration -Name PmRepo -OutputDir PmMigrations -Context Rs.App.Core.Pm.Infra.Repository.ProductContext -Project Rs.App.Core.Pm.Infra.Data
    // Update-Database   -Context  Rs.App.Core.Pm.Infra.Repository.ProductContext -Project Rs.App.Core.Pm.Infra.Data
    // Remove-Migration -Context  Rs.App.Core.Pm.Infra.Repository.ProductContext -Project Rs.App.Core.Pm.Infra.Data
    public class ProductContext : AbstractDataContext<ProductContext>
    {
        public ProductContext(IConfiguration configuration, DbContextOptions<ProductContext> options)
            : base(configuration, options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

