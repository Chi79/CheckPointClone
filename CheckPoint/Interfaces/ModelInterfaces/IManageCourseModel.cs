using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
    public interface IManageCourseModel
    {
        //TODO
        int? GetSessionRowIndex();

        void SetSessionRowIndex(int index);

        void SetSessionAppointmentId(int id);

        void ResetSessionState();

        string GetColumnName();

        string GetLoggedInClient();

        IEnumerable<object> GetAllAppointmentsForClient();

        IEnumerable<object> GetAllAppointmentsForClientByCourseId(int? courseId);

        IEnumerable<object> GetEmptyList();

        IEnumerable<object> GetCachedAppointments();

        IEnumerable<object> GetCachedAppointmentsInCourse();

        IEnumerable<object> GetAppointmentsInCourseSortedByPropertyAsc();

        IEnumerable<object> GetAppointmentsInCourseSortedByPropertyDesc();

    }
}
