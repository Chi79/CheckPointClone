using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.RepositoryInterfaces;
using System.Data.Entity;
using System.Linq.Expressions;

namespace DataAccess.Concrete.Repositories
{
    public class Repository<T> : IRepository<T> where T : class   //base class for all repositories to inherit
    {
        protected readonly DbContext Context;    //using entity framework to access dbase

        public Repository(DbContext context)
        {
            Context = context;
        }

        public T Get()
        {
            return Context.Set<T>().Find();
        }
        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }
        public void Add(T type)
        {
            Context.Set<T>().Add(type);
        }
        public void Remove(T type)
        {
            Context.Set<T>().Remove(type);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

    }
}
