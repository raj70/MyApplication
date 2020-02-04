/** 
* Copyright 2020 rajen.shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: RAJDEVMAC rajen.shrestha
* Machine: RAJDEVMAC
* Time: 2/3/2020 7:49:22 PM
*/
using Rs.App.Core.Sales.Domain;
using Rs.App.Core.Sales.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Sales.Infra.Data.Repository
{
    public class SaleRepository : AbstractRepository<Sale>, ISaleRepository
    {
        // Composited
        private readonly SaleContext _aContext;

        public SaleRepository(SaleContext aContext) : base(aContext)
        {
            _aContext = aContext;
        }

        public void Complete()
        {
            _aContext.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await _aContext.SaveChangesAsync();
        }
    }
}

