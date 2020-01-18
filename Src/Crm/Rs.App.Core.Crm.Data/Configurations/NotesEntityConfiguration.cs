/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/13/2020 11:50:55 PM
*/
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rs.App.Core.Crm.Domain;
using System;

namespace Rs.App.Core.Crm.Infra.Configurations
{
    public class NotesEntityConfiguration : IEntityTypeConfiguration<Note>
    {

        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable(nameof(Note) + "s");
            builder.HasKey(nameof(Note.Id));

            builder.Property(nameof(Note.Id)).ValueGeneratedOnAdd();

            builder.Property(nameof(Note.ShortNote)).HasMaxLength(500);

            builder.Property(nameof(Note.CreatedDate)).HasColumnType(nameof(DateTime));

            builder.Property(nameof(Note.IsDeleted)).HasColumnName("Active").HasDefaultValue(true);

        }
    }
}
