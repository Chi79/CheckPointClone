using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.FactoryInterfaces
{
    public interface IFactory
    {

        object CreateAppointmentJobType(object action);

        object CreateCourseJobType(object action);

        object CreateAttendeeJobType(object action);

       
    }
}
