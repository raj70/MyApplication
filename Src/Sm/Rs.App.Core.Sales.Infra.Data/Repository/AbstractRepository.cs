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

        public virtual void Add(T model)
        {
            this.Set().Add(model);
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return this.Set().Where(predicate);
        }

        public IEnumerable<T> Find(ISpecification<T> predicate)
        {
            return this.Set().Where(predicate.ToExpression());
        }

        public virtual T Get(Guid id)
        {
            return this.Set().Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.Set().ToList();
        }

        public virtual void Remove(Guid id)
        {
            var t = Get(id);
            if (t != null)
            {
                this.Set().Remove(t);
            }
        }

        public virtual void RemoveRange(IList<Guid> id)
        {
            throw new NotImplementedException();
        }

        protected virtual DbSet<T> Set()
        {
            return _dbContext.Set<T>();
        }
    }
}

