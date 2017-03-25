using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ServiceInterfaces;

namespace CheckPointCommon.ServiceInterfaces
{
    public interface IHandleAppointments : IHandler
    {
        IEnumerable<T> GetAllAppointmentsForClient<T>(string client);

        IEnumerable<string> GetAllAppointmentNamesForClient(string client);

        object GetAppointmentToDisplay();

        object GetAppointmentByName(string appointmentName);

        object GetAppointmentById(int appointmentId);

    }
}
