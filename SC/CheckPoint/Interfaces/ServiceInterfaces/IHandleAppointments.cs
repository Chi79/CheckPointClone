using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ServiceInterfaces
{
    public interface IHandleAppointments
    {
        IEnumerable<T> GetAllAppointmentsForClient<T>(string client);

        IEnumerable<string> GetAllAppointmentNamesForClient(string client);

        object GetAppointmentToDisplay();

        object GetAppointmentByName(string appointmentName);

        void Delete<T>(T appointment);

        void Create<T>(T appointment);

        object SaveChangesToAppointments();
    }
}
