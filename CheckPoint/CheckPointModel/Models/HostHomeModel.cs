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
    public class HostHomeModel : IHostHomeModel
    {

        private ISessionService _sessionService;
        private IShowAppointments _displayService;


        public HostHomeModel(ISessionService sessionService, IShowAppointments displayService)
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

        public void ResetSessionState()
        {

            int noRowSelected = -1;
            int noAppointmentSelected = -1;
            SetSessionRowIndex(noRowSelected);
            SetSessionAppointmentId(noAppointmentSelected);

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

        public IEnumerable<object> GetEmptyList()
        {

            return _displayService.GetEmptyList<APPOINTMENT>();

        }

        public IEnumerable<object> GetCachedAppointments()
        {

            return _displayService.GetAppointmentsCached<APPOINTMENT>();

        }

        public IEnumerable<object> GetAppointmentsSortedByPropertyAsc()
        {

            return _displayService.GetAppointmentsSortedByPropertyAscending<object>(GetColumnName());

        }

        public IEnumerable<object> GetAppointmentsSortedByPropertyDesc()
        {

            return _displayService.GetAppointmentsSortedByPropertyDescending<object>(GetColumnName());

        }


    }
}
