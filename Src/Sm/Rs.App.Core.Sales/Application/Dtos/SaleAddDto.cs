/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 2/4/2020 7:03:02 PM
*/
using Rs.App.Core.Sales.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Sales.Application.Dtos
{
    public class SaleAddDto
    {
        public SaleAddDto()
        {

        }

        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid SalePersonId { get; set; }
        public DateTime SaleDateTime { get; set; } = DateTime.UtcNow;

        public Sale Create()
        {
            return new Sale()
            {
                CustomerId = CustomerId,
                SaleDate = SaleDateTime,
                SalePersionId = SalePersonId,
            };
        }
        public OrderProduct CreateOrderProduct(Guid orderId)
        {
            return new OrderProduct
            {
                OrderId = orderId,
                ProductId = ProductId
            };
        }
        public Customer Customer()
        {
            return new Customer()
            {
                ContactId = CustomerId
            };
        }

        public SalePerson SalePerson()
        {
            return new SalePerson() {
                ContactId = SalePersonId
            };
        }

        public Product Product()
        {
            return new Product() {
                ProductId = ProductId,
            };
        }
    }
}

