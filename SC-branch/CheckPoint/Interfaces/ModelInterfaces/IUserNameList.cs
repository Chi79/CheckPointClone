using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
    public interface IUserNameList<T>
    {
        IList<T> List { get; }
        void Add(string name);
      
        string print();
    }
}
