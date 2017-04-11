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

        bool GetNewAppointmentAddedToCourseStatus();

        void ResetNewAppointmentAddedToCourseStatus();

        void SetSessionAppointmentId(int id);

        int? GetSessionAppointmentId();

        void SetSessionCourseId(int id);

        int? GetSessionCourseId();

        void ResetSessionState();

        string GetColumnName();

        string GetLoggedInClient();

        IEnumerable<object> GetAllAppointmentsForClient();

        IEnumerable<object> GetAllAppointmentsForClientByCourseId();

        IEnumerable<object> GetEmptyAppointmentList();

        IEnumerable<object> GetEmptyCourseList();

        IEnumerable<object> GetCachedAppointments();

        IEnumerable<object> GetCachedCourses();

        IEnumerable<object> GetCachedAppointmentsInCourse();

        IEnumerable<object> GetAppointmentsInCourseSortedByPropertyAsc();

        IEnumerable<object> GetAppointmentsInCourseSortedByPropertyDesc();

         IEnumerable<object> GetSelectedCourse();

    }
}
