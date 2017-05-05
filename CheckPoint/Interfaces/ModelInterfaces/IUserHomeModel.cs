using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
     public interface IUserHomeModel
    {
        int? GetSessionRowIndex();

        void SetSessionRowIndex(int index);

        int? GetSessionAppointmentId();

        void SetSessionAppointmentId(int id);

        void ResetSessionState();

        string GetColumnName();

        string GetLoggedInClient();

        IEnumerable<object> GetAllAppointmentsForClient();

        IEnumerable<object> GetAllAppointmentsClientIsApprovedToAttend();
        
        IEnumerable<object> GetEmptyList();

        IEnumerable<object> GetCachedAppointments();

        IEnumerable<object> GetCachedAcceptedAppointments();

        IEnumerable<object> GetAppointmentsSortedByPropertyAsc();

        IEnumerable<object> GetAppointmentsSortedByPropertyDesc();

        IEnumerable<object> GetAcceptedAppointmentsSortedByPropertyAsc();

        IEnumerable<object> GetAcceptedAppointmentsSortedByPropertyDesc();

    }
}
