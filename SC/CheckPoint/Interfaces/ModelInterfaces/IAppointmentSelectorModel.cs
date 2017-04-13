using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
    public interface IAppointmentSelectorModel
    {

        int? GetSessionRowIndex();

        void SetSessionRowIndex(int index);

        void SetSessionAppointmentId(int id);

        int? GetSessionAppointmentId();

        int? GetSessionCourseId();

        void ResetSessionState();

        string GetColumnName();

        string GetLoggedInClient();

        void AddSelectedAppointmentToCourse();

        void SetNewAppointmentAddedToCourseStatus();

        bool? GetValidNavigationStatus();

        IEnumerable<object> GetAllAppointmentsForClient();

        IEnumerable<object> GetEmptyList();

        IEnumerable<object> GetCachedAppointments();

        IEnumerable<object> GetAppointmentsSortedByPropertyAsc();

        IEnumerable<object> GetAppointmentsSortedByPropertyDesc();

    }
}
