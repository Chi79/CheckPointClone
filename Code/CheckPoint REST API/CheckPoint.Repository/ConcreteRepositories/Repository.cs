using CheckPoint.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Repository.ConcreteRepositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
            Context.Configuration.LazyLoadingEnabled = false;
        }

        public TEntity Get(string id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public RepositoryActionResult<TEntity> Insert(TEntity entity)
        {
            try
            {
                Context.Set<TEntity>().Add(entity);
                var result = Context.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<TEntity>(entity, RepositoryActionStatus.Created);
                }
                else
                {
                    return new RepositoryActionResult<TEntity>(entity, RepositoryActionStatus.NothingModified, null);
                }
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<TEntity>(null, RepositoryActionStatus.Error, ex);
            }
        }

        


    }
}
