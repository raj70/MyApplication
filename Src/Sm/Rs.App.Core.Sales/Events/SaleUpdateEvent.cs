﻿/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 2/6/2020 9:55:09 PM
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
    public class SaleUpdateEvent : AbstractDomainEvent<SaleUpdateClientModel>
    {
        public SaleUpdateEvent(IAuditRepository auditRepository) : base(auditRepository)
        {
        }
    }
}

