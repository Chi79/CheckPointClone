using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ServiceInterfaces
{
    public interface IHandler
    {
        void Delete<T>(T item);

        void Create<T>(T item);

        object SaveChanges();
    }
}
