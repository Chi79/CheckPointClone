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

        void ResetSessionRowIndex();

        bool GetNewAppointmentAddedToCourseStatus();

        void ResetNewAppointmentAddedToCourseStatus();

        bool GetAppointmentDeletedFromCourseStatus();

        void ResetAppointmentDeltedFromCourseStatus();

        void SetSessionAppointmentId(int id);

        void ResetSessionAppointmentId();

        int? GetSessionAppointmentId();

        void SetSessionCourseId(int id);

        int? GetSessionCourseId();

        void ResetSessionState();

        string GetColumnName();

        string GetLoggedInClient();

        void RemoveSelectedAppointmentFromCourse();

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
