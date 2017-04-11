using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
    public interface ICourseSelectorModel
    {
        object GetSelectedAppointment();

        string GetLoggedInClient();

        void SetNewAppointmentAddedToCourseStatus();

        void ResetNewAppointmentAddedToCourseStatus();

        string GetColumnName();

        int? GetSessionCourseId();

        void AddSelectedAppointmentToCourse(object appointment);

        int? GetSessionRowIndex();

        void ResetSessionState();

        void SetSessionRowIndex(int index);

        void SetSessionCourseId(int id);

        IEnumerable<object> GetAllCoursesForClient();

        IEnumerable<object> GetEmptyList();

        IEnumerable<object> GetCachedCourses();

        IEnumerable<object> GetCoursesSortedByPropertyAsc();

        IEnumerable<object> GetCoursesSortedByPropertyDesc();
    }

}
