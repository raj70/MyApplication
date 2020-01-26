/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/26/2020 8:31:09 PM
*/
using Microsoft.Extensions.DependencyInjection;
using Rs.App.Core.Pm.Domain;
using Rs.App.Core.Pm.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Pm.Events
{
    public class AbstractDomainEvent<T> : IDomainEvent<T> where T : class
    {
        protected IAuditRepository _auditRepository;

        public AbstractDomainEvent(IAuditRepository auditRepository)
        {
            _auditRepository = auditRepository;
        }

        public virtual void Raise(AbstractModel model)
        {
            _auditRepository.Add(model.ToString());
        }

        public static IDomainEvent<T> Create(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetRequiredService<IDomainEvent<T>>();
        }
    }
}

