﻿/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 2/6/2020 8:46:05 PM
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Sales.Application.ClientModel
{
    public class SaleUpdateClientModel
    {
        public SaleUpdateClientModel()
        {
            TotalCost = null;
        }

        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
        public decimal? TotalCost { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

