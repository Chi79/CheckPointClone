using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ServiceInterfaces;
using CheckPointDataTables.Tables;
using CheckPointCommon.RepositoryInterfaces;
using CheckPointCommon.Enums;

namespace CheckPointModel.Models
{
    public class UserHomeModel : IUserHomeModel
    {
        private ISessionService _sessionService;
        private IShowAppointments _displayService;
        private readonly IUnitOfWork _unitOfWork;


        public UserHomeModel(ISessionService sessionService, IShowAppointments displayService, IUnitOfWork unitOfWork)
        {

            _sessionService = sessionService;
            _displayService = displayService;
            _unitOfWork = unitOfWork;

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
    

        public IEnumerable<object> GetAllAppointmentsClientIsApprovedToAttend()
        {

            var allAppointmentsApproved = _displayService.GetAllAppointmentsClientIsApprovedToAttend<APPOINTMENT>(GetLoggedInClient());

            if(allAppointmentsApproved != null)
            {

                return allAppointmentsApproved;

            }
            else
            {

                return _displayService.GetEmptyList<APPOINTMENT>();

            }
            
        }

        public IEnumerable<object> GetEmptyList()
        {

            return _displayService.GetEmptyList<APPOINTMENT>();

        }

        public IEnumerable<object> GetCachedAppointments()
        {

            return _displayService.GetAppointmentsCached<APPOINTMENT>();

        }

        public IEnumerable<object> GetCachedAcceptedAppointments()
        {

            return _displayService.GetAcceptedAppointmentsCached<APPOINTMENT>();

        }

        public IEnumerable<object> GetAppointmentsSortedByPropertyAsc()
        {

            return _displayService.GetAppointmentsSortedByPropertyAscending<object>(GetColumnName());

        }

        public IEnumerable<object> GetAppointmentsSortedByPropertyDesc()
        {

            return _displayService.GetAppointmentsSortedByPropertyDescending<object>(GetColumnName());

        }

        public IEnumerable<object> GetAcceptedAppointmentsSortedByPropertyAsc()
        {

            return _displayService.GetAcceptedAppointmentsSortedByPropertyAscending<object>(GetColumnName());

        }

        public IEnumerable<object> GetAcceptedAppointmentsSortedByPropertyDesc()
        {

            return _displayService.GetAcceptedAppointmentsSortedByPropertyDescending<object>(GetColumnName());

        }

    }
}
