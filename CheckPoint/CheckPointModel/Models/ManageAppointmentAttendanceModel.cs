using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.RepositoryInterfaces;
using CheckPointCommon.ServiceInterfaces;
using CheckPointDataTables.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointModel.Models
{
    public class ManageAppointmentAttendanceModel : IManageAppointmentAttendanceModel
    {
        private ISessionService _sessionService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IShowAppointments _appointmentDisplayService;
        private readonly IShowClients _clientDisplayService;

        public ManageAppointmentAttendanceModel(ISessionService sessionService, IUnitOfWork unitOfWork, IShowAppointments appointmentDisplayService,
                                                IShowClients clientDisplayService)
        {
            _sessionService = sessionService;
            _unitOfWork = unitOfWork;
            _appointmentDisplayService = appointmentDisplayService;
            _clientDisplayService = clientDisplayService;
        }

        public string GetLoggedInClient()
        {
            return _sessionService.LoggedInClient;
        }

        public IEnumerable<object> GetAllAppointmentsWithAttendeeRequests()
        {
            var client = GetLoggedInClient();
            return _unitOfWork.APPOINTMENTs.GetAllAppointmentsWithAttendeeRequestsFor(client);
        }

        public IEnumerable<object> GetAllAppliedAttendeesForAppointmentById()
        {
            var selectedAppointmentId = (int)_sessionService.SessionAppointmentId;
            return _unitOfWork.ATTENDEEs.GetAllAttendeesAppliedForAppointmentById(selectedAppointmentId);
        }

        public IEnumerable<object> GetEmptyAppointmentList()
        {
            return _appointmentDisplayService.GetEmptyList<APPOINTMENT>();
        }

        public int? GetSessionRowIndex()
        {
            return _sessionService.SessionRowIndex;
        }

        public void SetSessionRowIndex(int index)
        {
            _sessionService.SessionRowIndex = index;
        }

        public void ResetSessionState()
        {
            int noRowSelected = -1;
            int noAppointmentSelected = -1;
            SetSessionRowIndex(noRowSelected);
            SetSessionAppointmentId(noAppointmentSelected);
        }
        private void SetSessionAppointmentId(int id)
        {
            _sessionService.SessionAppointmentId = id;
        }

        public IEnumerable<object> GetEmptyClientList()
        {
            return _clientDisplayService.GetEmptyList<CLIENT>();
        }
    }
}
