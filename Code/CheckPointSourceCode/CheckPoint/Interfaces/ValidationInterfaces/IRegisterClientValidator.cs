using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ValidationInterfaces
{
    public interface IRegisterClientValidator<T>: IValidator<T> where T:class
    {
        List<string> FillPropertyList(T client);
    }
}
