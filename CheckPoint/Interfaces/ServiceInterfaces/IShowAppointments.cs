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

        IEnumerable<T> GetAllAppointmentsForClientByCourseId<T>(int? courseId);
        IEnumerable<T> GetEmptyList<T>();

        IEnumerable<T> GetAppointmentsSortedByPropertyAscending<T>(string property);

        IEnumerable<T> GetAppointmentsSortedByPropertyDescending<T>(string property);

        IEnumerable<T> GetAppointmentsInCourseSortedByPropertyAscending<T>(string property);

        IEnumerable<T> GetAppointmentsInCourseSortedByPropertyDescending<T>(string property);

        IEnumerable<T> GetAppointmentsCached<T>();
        IEnumerable<T> GetAppointmentsInCourseCached<T>();

        object GetSelectedAppointmentByAppointmentId(int AppointmentId);
    }
}
