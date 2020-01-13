﻿/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/13/2020 5:23:37 PM
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
    // https://www.learnentityframeworkcore.com/configuration/fluent-api
    public class ContactEntityConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable(nameof(Contact) + "s");
            builder.HasKey(nameof(Contact.Id)); 

            builder.Property(nameof(Contact.Id)).ValueGeneratedOnAdd();

            builder.Property(nameof(Contact.LastName)).HasMaxLength(25).IsRequired();
            builder.Property(nameof(Contact.Name)).HasMaxLength(25).IsRequired();
            builder.Property(nameof(Contact.MiddleName)).HasMaxLength(25).IsRequired();
            builder.Property(nameof(Contact.MobileNumber)).HasMaxLength(25).IsRequired();

            builder.Property(nameof(Contact.Dob)).HasColumnType(nameof(DateTime));
            builder.Property(nameof(Contact.Dod)).HasColumnType(nameof(DateTime));
            builder.Property(nameof(Contact.IsActive)).HasDefaultValue(true);

            
            //builder
            //    .HasMany(a => a.HomeAddress)
            //    .WithOne(b => b.ContactHome)
            //    .HasForeignKey<Contact>(b => b.AddressId);

            //builder
            //    .HasOne(a => a.Title)
            //    .WithOne(b => b.Contact)
            //    .HasForeignKey<Title>(b => b.Id);


        }
    }
}
