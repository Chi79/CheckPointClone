using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
    public interface IHostCoursesModel
    {
        string GetLoggedInClient();

        string GetColumnName();

        int? GetSessionRowIndex();

        void SetSessionRowIndex(int index);

        void SetSessionCourseId(int id);

        int? GetSessionCourseId();

        void ResetSessionState();


        IEnumerable<object> GetAllCoursesForClient();

        IEnumerable<object> GetEmptyList();

        IEnumerable<object> GetCachedCourses();

        IEnumerable<object> GetCoursesSortedByPropertyAsc();

        IEnumerable<object> GetCoursesSortedByPropertyDesc();
    }
}
