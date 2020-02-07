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

namespace Rs.App.Core.Sales.Application.ClientModel
{
    public class SaleAddClientModel
    {
        public SaleAddClientModel()
        {
            ProductIds = new List<Guid>();
        }

        public List<Guid> ProductIds { get; set; }
        // from CRM (not the id of customer)
        public Guid CustomerId { get; set; }
        // same as above
        public Guid SalePersonId { get; set; }
        public decimal TotalCost { get; set; }

        public Sale Create()
        {
            return new Sale()
            {
                TotalCost = TotalCost
            };
        }
        public OrderProduct CreateOrderProduct(Guid orderId, Guid productId)
        {
            return new OrderProduct
            {
                OrderId = orderId,
                ProductId = productId
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
        public Product Product(Guid productId)
        {
            return new Product() {
                ProductId = productId,
            };
        }
    }
}

