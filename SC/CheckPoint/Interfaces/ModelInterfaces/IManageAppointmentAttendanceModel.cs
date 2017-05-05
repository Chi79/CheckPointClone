using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
    public interface IManageAppointmentAttendanceModel
    {
        
        IEnumerable<object> GetAllAppointmentsWithAttendeeRequests();
        IEnumerable<object> GetEmptyAppointmentList();
        IEnumerable<object> GetEmptyClientList();
      
        void SetSessionRowIndex(int index);
        void SetSessionAppointmentId(int id);
        int GetSessionAppointmentId();
        void SetSessionAttendeeUsername(string username);
        
        void ResetSessionState();
        int? GetSessionRowIndex();
        string GetSessionAttendeeUsername();
        string GetLoggedInClient();
        IEnumerable<object> GetClientInformationForAttendees();
        void ChangeSelectedAttendeesStatusToApproved();
        void ChangeAllAttendeesStatusesToApproved();
    }
}
