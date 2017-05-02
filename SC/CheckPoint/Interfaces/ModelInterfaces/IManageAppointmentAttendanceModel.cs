using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
    public interface IManageAppointmentAttendanceModel
    {
        string GetLoggedInClient();
        IEnumerable<object> GetAllAppointmentsWithAttendeeRequests();
        IEnumerable<object> GetEmptyAppointmentList();
        IEnumerable<object> GetEmptyAttendeeList();
        int? GetSessionRowIndex();
        void SetSessionRowIndex(int index);
        void ResetSessionState();
       
    }
}
