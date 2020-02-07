/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 2/6/2020 4:32:40 PM
*/
using Microsoft.EntityFrameworkCore;
using Rs.App.Core.Sales.Domain;
using Rs.App.Core.Sales.Infra.Repository;
using System;
using System.Threading.Tasks;

namespace Rs.App.Core.Sales.Infra.Data.Repository
{
    public class AuditRepository : AbstractRepository<Audit>, IAuditRepository
    {
        private readonly AuditContext _auditContext;

        public AuditRepository(AuditContext AuditContext) : base(AuditContext)
        {
            _auditContext = AuditContext;
        }


        public void Complete()
        {
            _auditContext.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await _auditContext.SaveChangesAsync();
        }

        public void Transacation()
        {
            _auditContext.Database.BeginTransaction();
        }
    }


}

