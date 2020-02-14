/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 2/4/2020 5:14:55 PM
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

    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public ProductEntityConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "dbo.Sale");
            builder.Property(nameof(Product.Id)).IsRequired(true);
        }
    }

}

