/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/22/2020 3:42:19 PM
*/
using Rs.App.Core.Pm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Pm.Infra.Repository
{
    public class ProductRepository : AbstractRepository<Product>, IProductRepository
    {
        private readonly ProductContext _productContext;

        public ProductRepository(ProductContext productContext): base(productContext)
        {
            _productContext = productContext;
        }

        public void Complete()
        {
            _productContext.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await _productContext.SaveChangesAsync();
        }

        public void Transacation()
        {
            _dbContext.Database.BeginTransaction();
        }
    }
}

