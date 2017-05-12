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
        DateTime GetTimeAttendedForSelectedAttendee();
        IEnumerable<object> GetEmptyAttendeeList();

        void ResetSessionState();
        int? GetSessionRowIndex();
    }
}
