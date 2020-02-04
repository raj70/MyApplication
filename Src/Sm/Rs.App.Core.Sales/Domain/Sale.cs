/** 
* Copyright 2020 rajen.shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: RAJDEVMAC rajen.shrestha
* Machine: RAJDEVMAC
* Time: 2/3/2020 7:46:14 PM
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Sales.Domain
{
    public class Sale : AbstractModel
    {
        public Sale()
        {
        }

        public Guid CustomerId { get; set; }
        public Guid SalePersionId { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.UtcNow;

        public virtual Customer Customer { get; set; }
        public virtual SalePerson SalePerson { get; set; }

        public bool IsValidCustomer()
        {
            return CustomerId != SalePersionId;
        }
    }
}

