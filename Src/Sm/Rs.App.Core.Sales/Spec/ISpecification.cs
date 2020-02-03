/** 
* Copyright 2020 rajen.shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: RAJDEVMAC rajen.shrestha
* Machine: RAJDEVMAC
* Time: 2/3/2020 7:46:14 PM
*/
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Rs.App.Core.Sales.Spec
{
    // https://enterprisecraftsmanship.com/posts/specification-pattern-c-implementation/
    public interface ISpecification<T> where T : class
    {
        Expression<Func<T, bool>> ToExpression();
        bool IsSatisfiedBy(T obj);
    }
}
