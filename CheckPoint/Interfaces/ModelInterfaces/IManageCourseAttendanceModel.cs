using CheckPointDataTables.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
    public interface IManageCourseAttendanceModel
    {
        string GetLoggedInClient();

        IEnumerable<object> GetAllCoursesWithAttendeeRequests();
        IEnumerable<object> GetEmptyCourseList();
        IEnumerable<object> GetEmptyClientList();
        int? GetSessionRowIndex();
        void SetSessionCourseId(int id);
        void SetSessionRowIndex(int index);
        void ResetSessionState();
        IEnumerable<object> GetClientInformationForAttendees();



    }
}
