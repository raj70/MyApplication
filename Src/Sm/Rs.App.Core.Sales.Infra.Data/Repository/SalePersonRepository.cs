/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 2/4/2020 6:09:00 PM
*/
using Microsoft.EntityFrameworkCore;
using Rs.App.Core.Sales.Domain;
using Rs.App.Core.Sales.Infra.Repository;
using System.Threading.Tasks;

namespace Rs.App.Core.Sales.Infra.Data.Repository
{
    public class SalePersonRepository : AbstractRepository<SalePerson>, ISalePersonRepository
    {
        private readonly SalePersonContext _SalePersonContext;

        public SalePersonRepository(SalePersonContext SalePersonContext) : base(SalePersonContext)
        {
            _SalePersonContext = SalePersonContext;
        }

        public void Complete()
        {
            _SalePersonContext.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await _SalePersonContext.SaveChangesAsync();
        }

        public void Transacation()
        {
            _SalePersonContext.Database.BeginTransaction();
        }
    }

}

