/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/21/2020 4:49:55 PM
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Pm.Spec
{
    // https://enterprisecraftsmanship.com/posts/specification-pattern-c-implementation/
    public interface ISpecification<T> where T : class
    {
        Expression<Func<T, bool>> ToExpression();
        bool IsSatisfiedBy(T obj);
    }
}

