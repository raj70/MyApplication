/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 2/4/2020 6:00:32 PM
*/
using Microsoft.EntityFrameworkCore;
using Rs.App.Core.Sales.Domain;
using Rs.App.Core.Sales.Infra.Repository;
using System.Threading.Tasks;

namespace Rs.App.Core.Sales.Infra.Data.Repository
{
    public class CustomerRepository : AbstractRepository<Customer>, ICustomerRepository
    {
        private readonly CustomerContext _customerContext;

        public CustomerRepository(CustomerContext CustomerContext) : base(CustomerContext)
        {
            _customerContext = CustomerContext;
        }

        public void Complete()
        {
            _customerContext.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await _customerContext.SaveChangesAsync();
        }

        public void Transacation()
        {
            _customerContext.Database.BeginTransaction();
        }
    }
}

