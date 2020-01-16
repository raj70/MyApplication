/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/16/2020 6:30:54 AM
* 
* [%clrversion%]
*/
using Rs.App.Core.Crm.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Infra.Services
{
    public interface ITitleService
    {
        Task<IEnumerable<Title>> GetAllAsync();
        Task<Title> GetAsync(Guid Id);
    }
}
