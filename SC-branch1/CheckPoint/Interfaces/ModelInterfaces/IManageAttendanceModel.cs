using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
    public interface IManageAttendanceModel
    {
        string GetLoggedInClient();

        IEnumerable<object> GetAllCoursesWithAttendeeRequests();
        IEnumerable<object> GetAllAppointmentsWithAttendeeRequests();
        int? GetSessionRowIndex();
        void SetSessionRowIndex(int index);
        void ResetSessionState();
       



        IEnumerable<object> GetEmptyCourseList();
        IEnumerable<object> GetEmptyAppointmentList();
        IEnumerable<object> GetEmptyAttendeeList();

    }
}
