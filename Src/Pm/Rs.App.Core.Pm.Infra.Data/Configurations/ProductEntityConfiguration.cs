/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/22/2020 4:28:07 PM
*/
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rs.App.Core.Pm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Pm.Infra.Configurations
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public ProductEntityConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product) + "s", "dbo.Pm");
            builder.Property(p => p.Cost).HasColumnType("decimal(18,4)");
            builder.Property(p => p.Name).IsRequired(true);
            builder.Property(p => p.Description).IsRequired(true);
            builder.Property(p => p.CreatedDate).IsRequired(true);
            builder.Property(p => p.IsActive).HasDefaultValue(true);
        }
    }

}


