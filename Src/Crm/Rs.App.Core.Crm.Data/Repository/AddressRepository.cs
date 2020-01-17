﻿/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/14/2020 6:33:03 PM
*/
using Microsoft.EntityFrameworkCore;
using Rs.App.Core.Crm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Infra.Repository
{
    public class AddressRepository : AbstractRepository<Address>, IAddressRepository
    {
        private readonly AddressContext addressContext;
        public AddressRepository(AddressContext dbContext) : base(dbContext)
        {
            addressContext = dbContext;
        }

        public IEnumerable<Address> AllNotUsed()
        {
            return addressContext.Addresses.FromSqlRaw(@"
                    select 
	                    a.* from Addresss a
                    left outer join Contacts c on a.Id = c.AddressId
                    left outer join Contacts cd on a.Id = cd.DeliveryAddressId
                    where c.id is null and cd.id is null")
                .ToList();
        }

        public void Complete()
        {
            _dbContext.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public Address Exist(Address address)
        {
            var a = Find(x =>
                   x.Line1.ToLower() == address.Line1.ToLower() &&
                   (x.Line2 ?? "").ToLower() == address.Line2.ToLower() &&
                   (x.Line3 ?? "").ToLower() == address.Line3.ToLower() &&
                   x.City.ToLower() == address.City.ToLower() &&
                   x.State.ToLower() == address.State.ToLower() &&
                   x.Country.ToLower() == address.Country.ToLower() &&
                   x.PostalCode.ToLower() == address.PostalCode.ToLower()
                ).FirstOrDefault();

            return a;
        }
    }
}

