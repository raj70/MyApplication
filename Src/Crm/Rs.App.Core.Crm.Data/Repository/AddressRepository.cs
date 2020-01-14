/** 
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
        public AddressRepository(AddressContext dbContext) : base(dbContext)
        {

        }

        public void Complete()
        {
            _dbContext.SaveChanges();
        }

        public async void CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

