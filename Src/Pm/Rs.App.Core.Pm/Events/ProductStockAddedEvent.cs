/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/21/2020 5:04:06 PM
*/
using Rs.App.Core.Pm.Application.Dtos;
using Rs.App.Core.Pm.Domain;
using Rs.App.Core.Pm.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Pm.Events
{
    public class ProductStockAddedEvent : IDomainEvent<StockAddDto>
    {
        private readonly IAuditRepository _auditRepository;

        public ProductStockAddedEvent(IAuditRepository auditRepository)
        {
            _auditRepository = auditRepository;
        }

        public void Raise(AbstractModel stock)
        {
            _auditRepository.Add(stock.ToString());
        }
    }
}

