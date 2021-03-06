﻿/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/25/2020 2:39:56 PM
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
    public class ProductExistSpecification : ISpecification<Product>
    {
        private readonly Guid _productId;

        public ProductExistSpecification(Guid id)
        {
            _productId = id;
        }

        public bool IsSatisfiedBy(Product model)
        {
            return ToExpression().Compile().Invoke(model);
        }

        public Expression<Func<Product, bool>> ToExpression()
        {
            return x =>
                       _productId == x.Id;
        }
    }
}

