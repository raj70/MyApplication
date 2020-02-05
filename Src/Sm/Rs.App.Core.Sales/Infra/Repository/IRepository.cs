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
using System.Threading.Tasks;

namespace Rs.App.Core.Sales.Infra.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(Guid id);
        T Get(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T model);
        T Add(T model);
        Task RemoveAsync(Guid id);
        void Remove(Guid id);
    }
}
