/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/21/2020 4:51:05 PM
*/
using Rs.App.Core.Pm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Pm.Spec
{
    public class StockExistSpecification : ISpecification<Stock>
    {
        private readonly Stock _stock;

        public StockExistSpecification(Stock stock)
        {
            _stock = stock;
        }

        public bool IsSatisfiedBy(Stock model)
        {
            return ToExpression().Compile().Invoke(model);
        }

        public Expression<Func<Stock, bool>> ToExpression()
        {
            return x =>
                       x.ProductId == _stock.ProductId;
        }


        public static StockExistSpecification Create(Guid productId)
        {
            return new StockExistSpecification(new Stock() { ProductId = productId });
        }
    }
}

