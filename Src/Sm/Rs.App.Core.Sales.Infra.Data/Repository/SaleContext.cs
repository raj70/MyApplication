/** 
* Copyright 2020 rajen.shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: RAJDEVMAC rajen.shrestha
* Machine: RAJDEVMAC
* Time: 2/3/2020 7:49:22 PM
*/
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rs.App.Core.Sales.Domain;
using Rs.App.Core.Sales.Infra.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Sales.Infra.Data.Repository
{
    public class SaleContext : AbstractDataContext<SaleContext>
    {
        public SaleContext(IConfiguration configuration, DbContextOptions<SaleContext> options)
            : base(configuration, options)
        {
        }

        public virtual DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuditEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderProductEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SaleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SalePersonEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

