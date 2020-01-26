/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/26/2020 10:11:38 PM
*/
using Rs.App.Core.Pm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Pm.Application.Dtos
{
    public class StockUpdateDto
    {
        public StockUpdateDto()
        {

        }

        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public int MinQuantity { get; set; }
        public DateTime ModifiedDated { get; set; } = DateTime.UtcNow;

        public Stock Update(Stock existStock)
        {
            existStock.ProductId = ProductId;
            existStock.Quantity = Quantity;
            existStock.MinQuantity = MinQuantity;
            existStock.ModifiedDated = ModifiedDated;
            return existStock;            
        }
    }
}

