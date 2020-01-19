/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/16/2020 3:28:15 PM
* 
* [%clrversion%]
*/
using Rs.App.Core.Crm.Domain;
using Rs.App.Core.Crm.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Application.Services
{
    public interface IAddressService
    {
        Task<Address> GetAddress(Guid id);

        Task<IEnumerable<Address>> AllNotUsed();

        Task<Result> DeleteAsync(Guid id);
    }
}
