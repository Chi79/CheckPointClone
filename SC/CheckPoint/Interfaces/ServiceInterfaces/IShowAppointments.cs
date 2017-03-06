using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ServiceInterfaces
{
    public interface IShowAppointments<T, U>
    {
        IEnumerable<T> GetAllAppointmentsFor(string client); 

        IEnumerable<U> GetAppointmentsSortedByPropertyAscending(string property);

        IEnumerable<U> GetAppointmentsSortedByPropertyDescending(string property);

    }
}
