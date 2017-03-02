using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.FactoryInterfaces
{
    public interface IFactory<T, U> /*where T:class where U:struct*/
    {
        T Create(U action);
    }
}
