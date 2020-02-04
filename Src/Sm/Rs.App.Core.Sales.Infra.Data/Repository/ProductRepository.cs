/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 2/4/2020 6:08:04 PM
*/
using Microsoft.EntityFrameworkCore;
using Rs.App.Core.Sales.Domain;
using Rs.App.Core.Sales.Infra.Repository;
using System.Threading.Tasks;

namespace Rs.App.Core.Sales.Infra.Data.Repository
{
    public class ProductRepository : AbstractRepository<Product>, IProductRepository
    {
        private readonly ProductContext _ProductContext;

        public ProductRepository(ProductContext ProductContext) : base(ProductContext)
        {
            _ProductContext = ProductContext;
        }

        public void Complete()
        {
            _ProductContext.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await _ProductContext.SaveChangesAsync();
        }

        public void Transacation()
        {
            _ProductContext.Database.BeginTransaction();
        }
    }


}

