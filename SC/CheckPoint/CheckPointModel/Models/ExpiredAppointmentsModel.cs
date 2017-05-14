using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ServiceInterfaces;
using CheckPointDataTables.Tables;

namespace CheckPointModel.Models
{
    public class ExpiredAppointmentsModel : IExpiredAppointmentsModel
    {

        private ISessionService _sessionService;
        private IShowAppointments _displayService;


        public ExpiredAppointmentsModel(ISessionService sessionService, IShowAppointments displayService)
        {

            _sessionService = sessionService;
            _displayService = displayService;

        }

        public int? GetSessionRowIndex()
        {

            return _sessionService.SessionRowIndex;

        }

        public void SetSessionRowIndex(int index)
        {

            _sessionService.SessionRowIndex = index;

        }

        public int? GetSessionAppointmentId()
        {

            return _sessionService.SessionAppointmentId;

        }

        public void SetSessionAppointmentId(int id)
        {

            _sessionService.SessionAppointmentId = id;

        }

        public int? GetSessionCourseId()
        {

            return _sessionService.SessionCourseId;

        }

        public void ResetSessionState()
        {

            int noRowSelected = -1;
            int noAppointmentSelected = -1;
            SetSessionRowIndex(noRowSelected);
            SetSessionAppointmentId(noAppointmentSelected);

        }

        public void ResetChangesSavedStatus()
        {

            _sessionService.SavedChangesStatus = false;

        }

        public string GetColumnName()
        {

            return _sessionService.ColumnName;

        }

        public string GetLoggedInClient()
        {

            return _sessionService.LoggedInClient;

        }

        public IEnumerable<object> GetAllAppointmentsForClient()
        {

             return _displayService.GetAllAppointmentsFor<APPOINTMENT>(GetLoggedInClient());

        }

        public IEnumerable<object> GetAllExpiredAppointmentsForClient()
        {

            return _displayService.GetAllExpiredAppointmentsFor<APPOINTMENT>(GetLoggedInClient());

        }

        public IEnumerable<object> GetEmptyList()
        {

            return _displayService.GetEmptyList<APPOINTMENT>();

        }

        public IEnumerable<object> GetCachedAppointments()
        {

            return _displayService.GetAppointmentsCached<APPOINTMENT>();

        }

        public IEnumerable<object> GetCachedExpiredAppointments()
        {

            return _displayService.GetExpiredAppointmentsCached<APPOINTMENT>();

        }

        public IEnumerable<object> GetExpiredAppointmentsSortedByPropertyAsc()
        {

            return _displayService.GetExpiredAppointmentsSortedByPropertyAscending<object>(GetColumnName());

        }

        public IEnumerable<object> GetExpiredAppointmentsSortedByPropertyDesc()
        {

            return _displayService.GetExpiredAppointmentsSortedByPropertyDescending<object>(GetColumnName());

        }


    }
}
