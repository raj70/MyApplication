/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/21/2020 5:34:07 PM
* 
* [%clrversion%]
*/
using Rs.App.Core.Pm.Application.Dtos;
using Rs.App.Core.Pm.Infra.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Pm.Application.Services
{
    public interface IProductService
    {
        Task<Result> AddAsync(ProductAddDto productDto);
        Task<Result> RemoveAsync(ProductRemoveDto productDto);
    }
}
