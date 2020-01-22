/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/21/2020 5:35:23 PM
*/
using Rs.App.Core.Pm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Pm.Application.Dtos
{
    public class ProductAddDto
    {
        public ProductAddDto()
        {

        }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
        public decimal Cost { get; set; }
        public bool IsActive { get; set; } = true;
        public Units Unit { get; set; } = Units.Pieces;

        public int Quantity { get; set; }
        public int MinQuantity { get; set; } = 5;

        public Stock CreateStock(Guid id)
        {
            return new Stock()
            {
                ProductId = id,
                MinQuantity = MinQuantity,
                Quantity = Quantity,
            };
        }

        public Product CreateProduct()
        {
            return new Product
            {
                Name = Name,
                Description = Description,
                Cost = Cost,
                ModifiedDate = ModifiedDate,
                Unit = Unit,
                IsActive = IsActive
            };
        }

        public override string ToString()
        {
            return $"{Name} {Description} {Cost} {Quantity} {CreatedDate}";
        }
    }
}

