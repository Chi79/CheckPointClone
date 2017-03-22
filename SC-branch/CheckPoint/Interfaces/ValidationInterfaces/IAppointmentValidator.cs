using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ValidationInterfaces
{
    public interface IAppointmentValidator<T> 
    {
        List<string> FillPropertyList(T client);
        //TODO
    }
}
