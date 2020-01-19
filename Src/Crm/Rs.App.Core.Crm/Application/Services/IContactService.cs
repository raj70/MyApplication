/** 
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
using Rs.App.Core.Crm.Application.ClientModel;
using Rs.App.Core.Crm.Domain;
using Rs.App.Core.Crm.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Application.Services
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAllAsync(int pageIndex, int pageSize = 10);
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact> GetAsync(Guid id);
        Task<Result> AddedAsync(ContactClient contactClient);
        Task<Result> UpdateAsync(Guid id, ContactUpdate contact);
        Task<Result> DeleteAsync(Guid id);
    }
}
