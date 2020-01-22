/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/22/2020 4:00:54 PM
*/
using Rs.App.Core.Pm.Infra.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Pm.Infra.Repository
{
    public class AuditRepository : AbstractRepository<Domain.Audit>, IAuditRepository
    {
        private readonly AuditContext _auditContext;

        public AuditRepository(AuditContext auditContext) : base(auditContext)
        {
            _auditContext = auditContext;
        }

        public void Add(string value)
        {
            var new_Audit = new Audit() { Value = value };
            base.Add(new_Audit);
            Complete();
        }

        public void Complete()
        {
            _auditContext.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await _auditContext.SaveChangesAsync();
        }
    }
}

