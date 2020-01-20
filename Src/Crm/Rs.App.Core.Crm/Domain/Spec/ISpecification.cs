/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/20/2020 8:16:23 PM
* 
* [%clrversion%]
*/
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Rs.App.Core.Crm.Domain.Spec
{
    public interface ISpecification<T> where T : class
    {
        Expression<Func<T, bool>> SpecExpression();
    }
}
