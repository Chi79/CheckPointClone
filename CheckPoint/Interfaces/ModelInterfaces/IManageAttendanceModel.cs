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

        IEnumerable<object> GetAllCoursesWithAppliedAttendees();

        IEnumerable<object> GetEmptyCourseList();
        IEnumerable<object> GetEmptyAppointmentList();

    }
}
