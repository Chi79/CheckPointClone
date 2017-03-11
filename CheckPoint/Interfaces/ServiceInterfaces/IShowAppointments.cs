using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ServiceInterfaces
{
    public interface IShowAppointments
    {
        IEnumerable<T> GetAllAppointmentsFor<T>(string client); 

        IEnumerable<T> GetAppointmentsSortedByPropertyAscending<T>(string property);

        IEnumerable<T> GetAppointmentsSortedByPropertyDescending<T>(string property);

        IEnumerable<T> GetAppointmentsCached<T>();
    }
}
