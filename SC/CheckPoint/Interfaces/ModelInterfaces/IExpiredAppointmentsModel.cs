using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
    public interface IExpiredAppointmentsModel
    {
        int? GetSessionRowIndex();

        void SetSessionRowIndex(int index);

        void SetSessionAppointmentId(int id);

        int? GetSessionAppointmentId();

        int? GetSessionCourseId();

        void ResetSessionState();

        void ResetChangesSavedStatus();

        string GetColumnName();

        string GetLoggedInClient();

        IEnumerable<object> GetAllAppointmentsForClient();

        IEnumerable<object> GetAllExpiredAppointmentsForClient();

        IEnumerable<object> GetEmptyList();

        IEnumerable<object> GetCachedAppointments();

        IEnumerable<object> GetCachedExpiredAppointments();

        IEnumerable<object> GetExpiredAppointmentsSortedByPropertyAsc();

        IEnumerable<object> GetExpiredAppointmentsSortedByPropertyDesc();

    }
}
