﻿/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/14/2020 12:11:30 AM
*/
using Microsoft.EntityFrameworkCore;
using Rs.App.Core.Crm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Infra.Repository
{
    /* Actually, IContactRepository is for DI and any extract works than CRUD */
    public sealed class ContactRepository : AbstractRepository<Contact>, IContactRepository
    {
        private readonly ContactContext DbContactContext;
        public ContactRepository(ContactContext dbContactContext) : base(dbContactContext)
        {
            DbContactContext = dbContactContext;
        }

        public void Complete()
        {
            this.DbContactContext.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await this.DbContactContext.SaveChangesAsync();
        }

        public override Contact Get(Guid id)
        {
            var db = DbContactContext.Contacts
                .Where(x => x.Id == id)
                .Include(x => x.HomeAddress)
                .Include(x => x.Title).FirstOrDefault();

            return db;
        }

        public override IEnumerable<Contact> GetAll()
        {
            var db = DbContactContext.Contacts
                .Include(c => c.HomeAddress)
                .Include(c => c.Title);
            return db.ToList();
        }

        public IEnumerable<Contact> GetAll(int pageIndex = 1, int pageSize = 10)
        {
            var db = DbContactContext.Contacts
                .Include(c => c.HomeAddress)
                .Include(c => c.Title)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);
            return db.ToList();
        }

        public void Update(Guid id, Contact contact)
        {
            var existed_contact = Find(x => x.Id == id).FirstOrDefault();
            if (existed_contact != null)
            {
                existed_contact.TitleId = contact.TitleId;
                existed_contact.Name = contact.Name;
                existed_contact.MiddleName = contact.MiddleName;
                existed_contact.LastName = contact.LastName;
                existed_contact.PhoneNumber = contact.PhoneNumber;
                existed_contact.MobileNumber = contact.MobileNumber;
                existed_contact.IsActive = contact.IsActive.Value;
                existed_contact.Dob = contact.Dob;
                existed_contact.Dod = contact.Dod;

                this.DbContactContext.Entry(existed_contact).State = EntityState.Modified;
                this.DbContactContext.SaveChanges();
            }
            else
            {
                throw new Exceptions.CrmException("Contact does not exist");
            }
        }

    }
}
