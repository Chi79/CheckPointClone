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

        IEnumerable<T> GetAllAppointmentsClientIsApprovedToAttend<T>(string client);

        IEnumerable<T> GetEmptyList<T>();

        IEnumerable<T> GetAppointmentsSortedByPropertyAscending<T>(string property);

        IEnumerable<T> GetAppointmentsSortedByPropertyDescending<T>(string property);

        IEnumerable<T> GetAppointmentsInCourseSortedByPropertyAscending<T>(string property);

        IEnumerable<T> GetAppointmentsInCourseSortedByPropertyDescending<T>(string property);

        IEnumerable<T> GetPublicAppointmentsSortedByPropertyAscending<T>(string property);

        IEnumerable<T> GetPublicAppointmentsSortedByPropertyDescending<T>(string property);

        IEnumerable<T> GetAcceptedAppointmentsSortedByPropertyAscending<T>(string property);

        IEnumerable<T> GetAcceptedAppointmentsSortedByPropertyDescending<T>(string property);

        IEnumerable<T> GetAppointmentsCached<T>();

        IEnumerable<T> GetAppointmentsInCourseCached<T>();

        IEnumerable<T> GetPublicAppointmentsCached<T>();

        IEnumerable<T> GetAcceptedAppointmentsCached<T>();

        IEnumerable<T> GetAllPublicAppointments<T>();


        object GetSelectedAppointmentByAppointmentId(int? AppointmentId);

        object GetSelectedPublicAppointmentByAppointmentId(int? AppointmentId);

        //void SetAllAcceptedAppointments<T>(IEnumerable<object> acceptedAppoiontments);
    }
}
