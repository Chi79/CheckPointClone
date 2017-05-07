using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
    public interface IFindCoursesModel
    {
        string GetLoggedInClient();

        string GetColumnName();

        int? GetSessionRowIndex();

        void ResetNewAppointmentAddedToCourseStatus();

        void SetSessionRowIndex(int index);

        void SetSessionCourseId(int id);

        int? GetSessionAppointmentId();

        int? GetSessionCourseId();

        void ResetSessionState();


        IEnumerable<object> GetAllPublicCourses();

        IEnumerable<object> GetEmptyList();

        IEnumerable<object> GetPublicCachedCourses();

        IEnumerable<object> GetPublicCoursesSortedByPropertyAsc();

        IEnumerable<object> GetPublicCoursesSortedByPropertyDesc();

    }
}
