/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 2/14/2020 4:35:51 PM
*/
using Microsoft.EntityFrameworkCore;
using Rs.App.Core.Crm.Domain;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Infra.Repository
{
    public class CompanyRepository : AbstractRepository<Company>, ICompanyRepository
    {
        private readonly CompanyContext _CompanyContext;

        public CompanyRepository(CompanyContext CompanyContext) : base(CompanyContext)
        {
            _CompanyContext = CompanyContext;
        }

        public void Complete()
        {
            _CompanyContext.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await _CompanyContext.SaveChangesAsync();
        }

        public void Transacation()
        {
            _CompanyContext.Database.BeginTransaction();
        }
    }

}

