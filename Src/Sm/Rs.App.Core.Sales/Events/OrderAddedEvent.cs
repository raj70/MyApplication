/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 2/7/2020 4:50:45 PM
*/
using Rs.App.Core.Sales.Application.ClientModel;
using Rs.App.Core.Sales.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Sales.Events
{
    public class OrderAddedEvent : AbstractDomainEvent<OrderAddClientModel>
    {
        public OrderAddedEvent(IAuditRepository auditRepository) : base(auditRepository)
        {
        }
    }
}

