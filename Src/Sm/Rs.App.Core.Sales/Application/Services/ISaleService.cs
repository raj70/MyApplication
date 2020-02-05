﻿/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 2/4/2020 6:53:28 PM
*/
using Rs.App.Core.Sales.Domain;
using Rs.App.Core.Sales.Infra.Domain;
using System;
using System.Threading.Tasks;

namespace Rs.App.Core.Sales.Application.Services
{
    public interface ISaleService
    {
        Task<Sale> GetSaleAsync(Guid id);
        Task<Result> UpdateAsync(Guid id, Dtos.SaleAddDto dto);
        Task<Result> AddAsync(Dtos.SaleAddDto dto);
    }  

}

