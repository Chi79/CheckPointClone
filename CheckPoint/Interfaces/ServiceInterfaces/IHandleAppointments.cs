using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ServiceInterfaces
{
    public interface IHandleAppointments<T, U> where T:class where U : struct 
    {
        IEnumerable<T> GetAllAppointmentsForClient(string client);

        IEnumerable<string> GetAllAppointmentNamesForClient(string client);

        T GetAppointmentToDisplay();
        T GetAppointmentByName(string appointmentName);
        void Delete(T appointment);
        void Create(T appointment);
        U SaveChangesToAppointments();
    }
}
