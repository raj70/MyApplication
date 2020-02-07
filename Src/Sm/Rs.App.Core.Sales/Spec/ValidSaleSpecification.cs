/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 2/7/2020 8:06:06 PM
*/
using Rs.App.Core.Sales.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Sales.Spec
{
    public class ValidSaleSpecification : ISpecification<Sale>
    {
        private readonly Sale _sale;

        public ValidSaleSpecification(Sale sale)
        {
            _sale = sale;
        }

        public bool IsSatisfiedBy(Sale model)
        {
            return ToExpression().Compile().Invoke(model);
        }

        public Expression<Func<Sale, bool>> ToExpression()
        {           
            return x =>
                x.Id == _sale.Id
                && x.TotalCost <= _sale.TotalCost;
        }

        public static ValidSaleSpecification Create(Guid salesId, decimal totalCost)
        {
            return new ValidSaleSpecification(new Sale
            {
                Id = salesId,
                TotalCost = totalCost
            });
        }
    }
}

