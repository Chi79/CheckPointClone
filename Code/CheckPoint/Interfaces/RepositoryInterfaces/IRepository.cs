using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.RepositoryInterfaces
{
    public interface IRepository<T> where T : class   //base interface all otheres extend
    {
        T Get();
        void Add(T t);
        IEnumerable<T> GetAll();
    }
}
