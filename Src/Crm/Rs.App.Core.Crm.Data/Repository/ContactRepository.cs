/** 
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
    public class ContactRepository : AbstractRepository<Contact>, IContactRepository
    {
        protected ContactContext DbContactContext;
        public ContactRepository(ContactContext dbContactContext) : base(dbContactContext)
        {
            DbContactContext = dbContactContext;
        }


        public void Complete()
        {
            this.DbContactContext.SaveChanges();
        }

        public async void CompleteAsync()
        {
            await this.DbContactContext.SaveChangesAsync();
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
    }
}
