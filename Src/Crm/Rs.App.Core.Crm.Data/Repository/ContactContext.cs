/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/13/2020 12:50:13 AM
*/
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rs.App.Core.Crm.Infra.Configurations;
using Rs.App.Core.Crm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Infra.Repository
{
    // Add-Migration -Name CrmRepo -OutputDir CrmMigrations -Context Rs.App.Core.Crm.Infra.Repository.ContactContext -Project Rs.App.Core.Crm.Infra.Data
    // Update-Database   -Context  Rs.App.Core.Crm.Infra.Repository.ContactContext -Project Rs.App.Core.Crm.Infra.Data
    // Remove-Migration -Context  Rs.App.Core.Crm.Infra.Repository.ContactContext -Project Rs.App.Core.Crm.Infra.Data
    public class ContactContext : AbstractDataContext<ContactContext>
    {
        public ContactContext(IConfiguration configuration, DbContextOptions<ContactContext> options)
            : base(configuration, options)
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AddressEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TitleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new NotesEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }       
    }
}
