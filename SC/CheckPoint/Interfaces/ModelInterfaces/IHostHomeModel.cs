using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
    public interface IHostHomeModel
    {
        int? GetSessionRowIndex();

        void SetSessionRowIndex(int index);

        void SetSessionAppointmentId(int id);

        void ResetSessionState();

        string GetColumnName();

        string GetLoggedInClient();

        IEnumerable<object> GetAllAppointmentsForClient();

        IEnumerable<object> GetEmptyList();

        IEnumerable<object> GetCachedAppointments();

        IEnumerable<object> GetAppointmentsSortedByPropertyAsc();

        IEnumerable<object> GetAppointmentsSortedByPropertyDesc();
    }
}
