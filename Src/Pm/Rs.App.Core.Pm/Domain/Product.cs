﻿/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/20/2020 9:36:30 PM
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Pm.Domain
{
    public class Product : AbstractModel
    {
        public Product()
        {

        }
        // from your crm
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ModifiedDate { get; set; }
        public decimal Cost { get; set; }
        public bool? IsActive { get; set; }
        public Units Unit { get; set; }
        public override string ToString()
        {
            return $"{nameof(Product)}: {Id}: {CompanyId} {Name}-{Description}-{Cost}-{CreatedDate}";
        }
    }
}

