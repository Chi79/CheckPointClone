using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
    public interface IManageAppointmentModel<U,T> where U: class where T: class
    {
        //TODO
        U ConvertToAppointment(T entityModel);
    }
}
