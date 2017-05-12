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
    public class UserAttendanceHistoryModel : IUserAttendanceHistoryModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private ISessionService _sessionService;
        private IShowAppointments _appointmentDisplayService;
        private IShowAttendees _attendeeDisplayService;

        public UserAttendanceHistoryModel(IUnitOfWork unitOfWork, ISessionService sessionService, IShowAppointments appointmentDisplayService,
                                            IShowAttendees attendeeDisplayService)
        {
            _unitOfWork = unitOfWork;
            _sessionService = sessionService;
            _appointmentDisplayService = appointmentDisplayService;
            _attendeeDisplayService = attendeeDisplayService;
        }

        public IEnumerable<object> GetEmptyAppointmentList()
        {
            return _appointmentDisplayService.GetEmptyList<APPOINTMENT>() as IEnumerable<object>;
        }

        public void SetSessionRowIndex(int index)
        {
            _sessionService.SessionRowIndex = index;
        }

        public void SetSessionAppointmentId(int id)
        {
            _sessionService.SessionAppointmentId = id;
        }

        public int GetSessionAppointmentId()
        {
            return (int)_sessionService.SessionAppointmentId;
        }

        public void ResetSessionState()
        {
            int noRowSelected = -1;
            int noCourseSelected = -1;
            SetSessionRowIndex(noRowSelected);
            SetSessionAppointmentId(noCourseSelected);
        }

        public int? GetSessionRowIndex()
        {
            return (int)_sessionService.SessionRowIndex;
        }

        public IEnumerable<object> GetAttendedAppointmentsForUser()
        {
            var allAttendedAppointments = new List<APPOINTMENT>();

            var client = GetLoggedInClient();
            var clientTagId = _unitOfWork.Client_TagIds.GetClientTagId(client);
            var allAttendeesForClient = _unitOfWork.ATTENDEEs.GetAllAttendedAttendeesForClient(clientTagId);

            foreach (ATTENDEE attendee in allAttendeesForClient)
            {
                var appointmentId = attendee.AppointmentId;
                var attendedAppointmentToAdd = _unitOfWork.APPOINTMENTs.GetAppointmentByAppointmentId(appointmentId);

                allAttendedAppointments.Add(attendedAppointmentToAdd);
            }
            return allAttendedAppointments;


        }

        public string GetLoggedInClient()
        {
            return _sessionService.LoggedInClient;
        }

        public DateTime GetTimeAttendedForSelectedAttendee()
        {
            var clientTagId = GetClientTagId();
            var selectedAppointmentId = GetSessionAppointmentId();

            var attendee = (ATTENDEE)_unitOfWork.ATTENDEEs.GetAttendeeByTagIdAndAppointmentId(clientTagId, selectedAppointmentId);

            return (DateTime)attendee.TimeAttended;

        }

        public IEnumerable<object> GetEmptyAttendeeList()
        {
            return _appointmentDisplayService.GetEmptyList<ATTENDEE>();
        }

        public string GetClientTagId()
        {
            var client = GetLoggedInClient();
            return _unitOfWork.Client_TagIds.GetClientTagId(client);
        }
    }
}
