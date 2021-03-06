﻿/** 
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
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rs.App.Core.Sales.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Sales.Infra.Data.Configurations
{
    public class SaleEntityConfiguration : IEntityTypeConfiguration<Sale>
    {
        public SaleEntityConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales", "dbo.Sale");
            builder.Property(nameof(Sale.CustomerId)).IsRequired(true);
            builder.Property(nameof(Sale.IsActive)).IsRequired(true);
            builder.Property(nameof(Sale.TotalCost))
                .HasColumnType("decimal(18,4)")
                .IsRequired(true);
        }
    }
}

