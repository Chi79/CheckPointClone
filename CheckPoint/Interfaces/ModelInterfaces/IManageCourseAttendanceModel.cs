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
        IEnumerable<object> GetAllAppointmentsWithAttendeeRequests();
        IEnumerable<object> GetEmptyCourseList();
        IEnumerable<object> GetEmptyAttendeeList();
        int? GetSessionRowIndex();
        void SetSessionRowIndex(int index);
        void ResetSessionState();

       
    }
}
