/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 2/6/2020 3:58:19 PM
*/
using Microsoft.Extensions.DependencyInjection;
using Rs.App.Core.Sales.Domain;
using Rs.App.Core.Sales.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Sales.Events
{
    public class AbstractDomainEvent<TDto> : IDomainEvent<TDto> where TDto : class
    {
        protected IAuditRepository _auditRepository;

        public AbstractDomainEvent(IAuditRepository auditRepository)
        {
            _auditRepository = auditRepository;
        }

        public virtual void Raise(AbstractModel model)
        {
            var audit = new Audit() { Value = model.ToString() };
            _auditRepository.Add(audit);
            _auditRepository.Complete();
        }

        public static IDomainEvent<TDto> Create(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetRequiredService<IDomainEvent<TDto>>();
        }

        public async Task RaiseAsync(AbstractModel model)
        {
            var audit = new Audit() { Value = model.ToString() };
            await _auditRepository.AddAsync(audit);
            await _auditRepository.CompleteAsync();
        }
    }
}

