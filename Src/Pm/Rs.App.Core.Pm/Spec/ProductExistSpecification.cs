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
using Rs.App.Core.Pm.Infra.Domain;
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
        private readonly Product _product;

        public ProductExistSpecification(Product product)
        {
            _product = product;
        }

        public bool IsSatisfiedBy(Product model)
        {
            // now this object doing two things; actually validation, we don't want to validate here; we want to valid from FluentValidataion
            // Expression<Func<Product, bool>> d = x => (x.Cost > 0)  && (x.IsActive.Value == true) && !string.IsNullOrWhiteSpace(x.Description) && !string.IsNullOrWhiteSpace(x.Name);
            return ToExpression().Compile().Invoke(model);
        }

        public Expression<Func<Product, bool>> ToExpression()
        {
            return x =>
                       x.Name == _product.Name &&
                       x.Description == _product.Description &&
                       x.IsActive == true;
        }
    }
}

