/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/13/2020 12:19:18 AM
*/
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Infra.Repository
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;
        public AbstractRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T model)
        {
            this.Set().Add(model);
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return this.Set().Where(predicate);
        }

        public T Get(Guid id)
        {
            return this.Set().Find(id);
        }

        public IEnumerable<T> GetAll()
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

        private DbSet<T> Set()
        {
            return _dbContext.Set<T>();
        }
    }
}
