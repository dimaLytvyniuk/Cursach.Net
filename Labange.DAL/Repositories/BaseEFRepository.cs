using Labange.DAL.EF;
using Labange.DAL.Entities;
using Labange.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Labange.DAL.Repositories
{
    public abstract class BaseEFRepository<T> : IRepository<T> where T : class
    {
        protected readonly LabangeContext dbContext;
        protected readonly DbSet<T> dbSet;

        public BaseEFRepository(LabangeContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = this.dbContext.Set<T>();
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                Add(entity);
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void DeleteRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public virtual T Find(Func<T, bool> predicate)
        {
            return dbSet
                .FirstOrDefault(predicate);
        }

        public virtual IEnumerable<T> FindAll(Func<T, bool> predicate)
        {
            return dbSet
                .Where(predicate)
                .ToList();
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet
                .FirstOrDefaultAsync(predicate);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet
                .ToList();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet
                .ToListAsync();
        }

        public virtual void Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
