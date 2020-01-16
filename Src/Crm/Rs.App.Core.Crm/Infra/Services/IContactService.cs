﻿/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/14/2020 6:42:30 PM
* 
* [%clrversion%]
*/
using Rs.App.Core.Crm.ClientModel;
using Rs.App.Core.Crm.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Infra.Services
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAllAsync(int pageIndex, int pageSize = 10);
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact> GetAsync(Guid id);
        Task AddedAsync(ContactClient contactClient);
    }
}
