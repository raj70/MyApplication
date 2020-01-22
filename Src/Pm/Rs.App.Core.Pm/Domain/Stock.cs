/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/20/2020 9:36:52 PM
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Pm.Domain
{
    public class Stock : AbstractModel
    {
        public Stock()
        {

        }

        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public int MinQuantity { get; set; } = 5;
        public DateTime ModifiedDated { get; set; } = DateTime.UtcNow;

        public override string ToString()
        {
            return $"{nameof(Stock)}: {Id}: ProductId{ProductId} {CreatedDate}";
        }

    }
}

