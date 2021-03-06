﻿/** 
* Copyright 2020 rajen.shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: RAJDEVMAC rajen.shrestha
* Machine: RAJDEVMAC
* Time: 2/3/2020 7:46:14 PM
*/
using Rs.App.Core.Sales.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Sales.Events
{
    public interface IDomainEvent<TDto> where TDto : class
    {
        void Raise(AbstractModel model);
        Task RaiseAsync(AbstractModel model);
    }
}
