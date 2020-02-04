/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 2/4/2020 4:25:16 PM
* 
* [4.0.30319.42000]
*/
using Rs.App.Core.Sales.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rs.App.Core.Sales.Infra.Repository
{
    public interface IOrderProductRepository : IRepository<OrderProduct>, IURepository
    {
    }
}
