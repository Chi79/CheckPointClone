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
        string GetSessionAttendeeUsername();
        void SetSessionCourseId(int id);
        int GetSessionCourseId();
        void SetAttendeeUsername(string username);
        void SetSessionRowIndex(int index);
        void ResetSessionState();
        IEnumerable<object> GetClientInformationForAttendees();
        void ChangeSelectedAttendeesStatusToApproved();
        void ChangeAllAttendeesStatusesToApproved();



    }
}
