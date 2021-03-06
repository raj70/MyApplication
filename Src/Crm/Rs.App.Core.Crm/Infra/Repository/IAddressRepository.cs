﻿/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/14/2020 6:30:11 PM
* 
* [%clrversion%]
*/
using Rs.App.Core.Crm.Domain;
using Rs.App.Core.Crm.Domain.Spec;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rs.App.Core.Crm.Infra.Repository
{
    public interface IAddressRepository : IRepository<Address>, IURepository
    {
        IEnumerable<Address> AllNotUsed();
    }
}
