/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 2/4/2020 7:17:06 PM
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
    public class SaleExistSpecification : ISpecification<Sale>
    {
        private readonly Sale _sale;

        public SaleExistSpecification(Sale sale)
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
                       _sale.Id == x.Id;
        }

        public static SaleExistSpecification Create(Sale sale)
        {
            return new SaleExistSpecification(sale);
        }
    }
}

