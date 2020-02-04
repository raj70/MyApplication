﻿/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 2/4/2020 6:08:04 PM
*/
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rs.App.Core.Sales.Domain;
using Rs.App.Core.Sales.Infra.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rs.App.Core.Sales.Infra.Data.Repository
{
    public class ProductContext : AbstractDataContext<ProductContext>
    {
        public ProductContext(IConfiguration configuration, DbContextOptions<ProductContext> options)
            : base(configuration, options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }


}

