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

        public UserAttendanceHistoryModel(IUnitOfWork unitOfWork, ISessionService sessionService, IShowAppointments appointmentDisplayService)
        {
            _unitOfWork = unitOfWork;
            _sessionService = sessionService;
            _appointmentDisplayService = appointmentDisplayService;
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

        public IEnumerable<object> GetAttendedAppointmentForUser()
        {
            return null;
        }

        public void SetSessionAttendeeUsername(string username)
        {
            throw new NotImplementedException();
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
            var allAttendeesForClient = _unitOfWork.ATTENDEEs.GetAllAttendedAttendeesForClient(client);

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
    }
}
