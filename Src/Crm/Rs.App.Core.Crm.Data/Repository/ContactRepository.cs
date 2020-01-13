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
using Rs.App.Core.Crm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Infra.Repository
{
    public class ContactRepository : AbstractRepository<Contact>, IContactRepository /* Actually, IContactRepository is for DI and any extract works than CRUD */
    {
        protected ContactContext DbContactContext;
        public ContactRepository(ContactContext DbContactContext) : base(DbContactContext)
        {

        }

        public async void CompleteAsync()
        {
            await this.DbContactContext.SaveChangesAsync();
        }
    }
}
