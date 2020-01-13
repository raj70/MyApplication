/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/12/2020 8:22:03 PM
* 
*/
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Rs.App.Core.Crm.Infra.Repository
{
    public interface IRepository<T> where T : class
    {
        T Get(Guid id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Add(T model);

        void Remove(Guid id);
        void RemoveRange(IList<Guid> id);
    }
}
