using CheckPointCommon.Enums;
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
    public class RecordedAppointmentAttendanceModel : IRecordedAppointmentAttendanceModel
    {
        private ISessionService _sessionService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IShowAppointments _appointmentDisplayService;
        private readonly IShowClients _clientDisplayService;

        public RecordedAppointmentAttendanceModel(ISessionService sessionService, IUnitOfWork unitOfWork, IShowAppointments appointmentDisplayService,
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

        public int GetSessionAppointmentId()
        {

            return (int)_sessionService.SessionAppointmentId;

        }

        private object GetClientByUserName(string username)
        {

            return _unitOfWork.CLIENTs.GetAClientByName(username);

        }

        public IEnumerable<object> GetEmptyAppointmentList()
        {

            return _appointmentDisplayService.GetEmptyList<APPOINTMENT>();

        }


        public IEnumerable<object> GetEmptyClientList()
        {

            return _clientDisplayService.GetEmptyList<CLIENT>();

        }

        public IEnumerable<object> GetAppointmentByAppointmentId()
        {

            List<APPOINTMENT> appointmentAsList = _appointmentDisplayService.GetEmptyList<APPOINTMENT>().ToList();

            int id = (int)_sessionService.SessionAppointmentId;

            APPOINTMENT app = _appointmentDisplayService.GetSelectedAppointmentByAppointmentId(id) as APPOINTMENT;

            appointmentAsList.Add(app);

            return appointmentAsList;

        }

        public IEnumerable<object> GetAllAttendeesWhoAttendedTheAppointment()
        {

            var attendeesForSelectedAppointment = GetAllAttendeesWhoAttendedSelectedAppointment().ToList();

            List<CLIENT> clientsAttended = _clientDisplayService.GetEmptyList<CLIENT>().ToList();

            foreach (ATTENDEE attendee in attendeesForSelectedAppointment)
            {
                var userName = attendee.CLIENT_TAG.UserName;

                var client = GetClientByUserName(userName) as CLIENT;

                clientsAttended.Add(client);
            }

            return clientsAttended;

        }


        private IEnumerable<ATTENDEE> GetAllAttendeesWhoAttendedSelectedAppointment()
        {
            var selectedAppointment = (int)_sessionService.SessionAppointmentId;

            return _unitOfWork.ATTENDEEs.GetAllAttendeesWhoAttendedAppointmentById(selectedAppointment);
        }

    }
}
