using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
    public interface IRecordedAppointmentAttendanceModel
    {
        IEnumerable<object> GetAllAttendeesWhoAttendedTheAppointment();
        IEnumerable<object> GetAppointmentByAppointmentId();
        IEnumerable<object> GetEmptyAppointmentList();
        IEnumerable<object> GetEmptyClientList();
        int GetSessionAppointmentId();
        string GetLoggedInClient();
    }
}
