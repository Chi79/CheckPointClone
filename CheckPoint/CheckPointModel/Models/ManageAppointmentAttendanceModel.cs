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
        public void SetSessionAppointmentId(int id)
        {
            _sessionService.SessionAppointmentId = id;
        }

        public void SetSessionAttendeeUsername(string username)
        {
            _sessionService.SessionAttendeeUsername = username;
        }

        public IEnumerable<object> GetEmptyClientList()
        {
            return _clientDisplayService.GetEmptyList<CLIENT>();
        }

        public string GetSessionAttendeUsername()
        {
            return _sessionService.SessionAttendeeUsername;
        }

        public IEnumerable<object> GetClientInformationForAttendees()
        {

            var attendeesForSelectedAppointment = GetAttendeesForSelectedAppointment();
            List<object> appliedAttendeesAsClients = new List<object>();

            foreach (var attendee in attendeesForSelectedAppointment)
            {
                var username = attendee.CLIENT_TAG.UserName;
                var attendeeAsClient = (CLIENT)GetClientByUserName(username);
                appliedAttendeesAsClients.Add(attendeeAsClient);
            }
            return appliedAttendeesAsClients;
        }

        private IEnumerable<ATTENDEE> GetAttendeesForSelectedAppointment()
        {
            var selectedAppointment = (int)_sessionService.SessionAppointmentId;

            return _unitOfWork.ATTENDEEs.GetAllAttendeesAppliedForAppointmentById(selectedAppointment);
        }

        private object GetClientByUserName(string username)
        {
            return _unitOfWork.CLIENTs.GetAClientByName(username);
        }


        public string GetSessionAttendeeUsername()
        {
            return _sessionService.SessionAttendeeUsername;
        }
    }
}
