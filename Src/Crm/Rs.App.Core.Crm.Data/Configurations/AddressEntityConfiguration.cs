/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/13/2020 10:59:14 PM
*/
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rs.App.Core.Crm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Infra.Configurations
{
    public class AddressEntityConfiguration : IEntityTypeConfiguration<Address>
    {
        public AddressEntityConfiguration()
        {
           

        }

        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable(nameof(Address) + "s");
            builder.HasKey(nameof(Address.Id));
            builder.Property(nameof(Address.Id)).ValueGeneratedOnAdd();

            builder.Property(nameof(Address.Line1)).HasMaxLength(150).IsRequired();
            builder.Property(nameof(Address.City)).HasMaxLength(25).IsRequired();
            builder.Property(nameof(Address.Country)).HasMaxLength(25).IsRequired();           
        }
    }
}
