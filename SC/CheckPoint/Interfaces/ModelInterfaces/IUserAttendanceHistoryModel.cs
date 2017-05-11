using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
    public interface IUserAttendanceHistoryModel
    {
        IEnumerable<object> GetEmptyAppointmentList();

        IEnumerable<object> GetAttendedAppointmentsForUser();
        void SetSessionRowIndex(int index);
        void SetSessionAppointmentId(int id);
        int GetSessionAppointmentId();
        void SetSessionAttendeeUsername(string username);

        void ResetSessionState();
        int? GetSessionRowIndex();
    }
}
