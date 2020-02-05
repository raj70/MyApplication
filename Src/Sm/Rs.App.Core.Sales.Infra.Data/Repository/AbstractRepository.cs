/** 
* Copyright 2020 rajen.shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: RAJDEVMAC rajen.shrestha
* Machine: RAJDEVMAC
* Time: 2/3/2020 7:49:22 PM
*/
using Microsoft.EntityFrameworkCore;
using Rs.App.Core.Sales.Infra.Repository;
using Rs.App.Core.Sales.Spec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Sales.Infra.Data.Repository
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;
        public AbstractRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async virtual Task<T> AddAsync(T model)
        {
            var entity = await this.Set().AddAsync(model);
            return entity.Entity;
        }

        public async Task<IEnumerable<T>> FindAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await Task.Run(() => this.Set().Where(predicate));
        }

        public async virtual Task<T> GetAsync(Guid id)
        {
            return await this.Set().FindAsync(id).AsTask();
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return await this.Set().ToListAsync();
        }

        public async virtual Task RemoveAsync(Guid id)
        {
            var t = await GetAsync(id);
            if (t != null)
            {
                this.Set().Remove(t);
            }
        }

        protected virtual DbSet<T> Set()
        {
            return _dbContext.Set<T>();
        }

        public T Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return Set().ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Set().Where(predicate);
        }

        public T Add(T model)
        {
             var t = Set().Add(model);
            return t.Entity;
        }

        public void Remove(Guid id)
        {
            var t = Get(id);
            if (t != null)
            {
                this.Set().Remove(t);
            }
        }
    }
}

