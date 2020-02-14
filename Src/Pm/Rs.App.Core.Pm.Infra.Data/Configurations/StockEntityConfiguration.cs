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

namespace Rs.App.Core.Pm.Infra.Configurations
{
    public class StockEntityConfiguration : IEntityTypeConfiguration<Stock>
    {
        public StockEntityConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable(nameof(Stock) + "s", "dbo.Pm");
            builder.Property(nameof(Stock.Id)).IsRequired(true);
        }
    }

}


