/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 2/14/2020 4:24:28 PM
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
    public class CompanyEntityConfiguration : IEntityTypeConfiguration<Company>
    {
        public CompanyEntityConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable(nameof(Company) + "s", "dbo.Crms");
            builder.HasKey(nameof(Company.Id));
            builder.Property(nameof(Company.Id)).ValueGeneratedOnAdd();
            builder.Property(nameof(Company.AddressId)).IsRequired(true);

            builder.HasOne(x => x.ContactPerson).WithOne(x => x.Company);//.HasForeignKey<Company>(x => x.ContactPersonId);
            builder.HasMany(x => x.Contacts).WithOne(x => x.CompanyContacts);

            builder.HasOne(x => x.Address).WithOne(x => x.Company).HasForeignKey<Company>(x => x.AddressId);
            builder.HasOne(x => x.DeliveryAddress).WithOne(x => x.DeliveryCompany).HasForeignKey<Company>(x => x.DeliveryAddressId);
            builder.Property(nameof(Company.BusinessNumber))
                .IsRequired(true)
                .HasMaxLength(25);
            builder.Property(nameof(Company.ContactPersonId))
               .IsRequired(true)
               .HasMaxLength(15);
        }
    }

}

