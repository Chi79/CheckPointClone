using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.RepositoryInterfaces;
using CheckPointCommon.ServiceInterfaces;
using CheckPointDataTables.Tables;

namespace CheckPointModel.Models
{
    public class ManageAttendanceModel : IManageAttendanceModel
    {
        private ISessionService _sessionService;
        private readonly IUnitOfWork _uOW;
        private IShowCourses _courseDisplayService;
        private IShowAppointments _appointmentDisplayService;
        private IShowAttendees _attendeeDisplayService;
        public ManageAttendanceModel(ISessionService sessionService, IUnitOfWork unitOfWork, IShowCourses courseDisplayService,
                                        IShowAppointments appointmentDisplayService, IShowAttendees attendeeDisplayService)
        {
            _sessionService = sessionService;
            _uOW = unitOfWork;
            _courseDisplayService = courseDisplayService;
            _appointmentDisplayService = appointmentDisplayService;
            _attendeeDisplayService = attendeeDisplayService;
        }

        public string GetLoggedInClient()
        {           
            return _sessionService.LoggedInClient;
        }

        public IEnumerable<COURSE> GetAllCoursesForClient()
        {
            var client = GetLoggedInClient();
            return _uOW.COURSEs.GetAllCoursesFor(client);
        }

        public IEnumerable<object> GetEmptyCourseList()
        {
            return _courseDisplayService.GetEmptyList<COURSE>();
        }

        public IEnumerable<object> GetEmptyAppointmentList()
        {
            return _appointmentDisplayService.GetEmptyList<APPOINTMENT>();
        }

        public IEnumerable<object> GetEmptyAttendeeList()
        {
            return _attendeeDisplayService.GetEmptyList<ATTENDEE>();
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

        public void SetSessionCourseId(int id)
        {
            _sessionService.SessionCourseId = id;
        }

        public void ResetSessionState()
        {
            int noRowSelected = -1;
            int noAppointmentSelected = -1;
            SetSessionRowIndex(noRowSelected);
            SetSessionAppointmentId(noAppointmentSelected);
        }

        public IEnumerable<object> GetAllCoursesWithAttendeeRequests()
        {
            var clientCourses = GetAllCoursesForClient();
            var AttendeesAppliedToCourses = GetAllAttendeesAppliedForCourses();
            List<object> coursesWithAttendeeRequests = new List<object>();

            foreach (var attendee in AttendeesAppliedToCourses)
            {
                var courseToAdd = GetCourseById((int)attendee.CourseId);
                if(clientCourses.Contains(courseToAdd))
                {
                    coursesWithAttendeeRequests.Add(courseToAdd);
                }              
            }
            return coursesWithAttendeeRequests;
        }

        public object GetCourseById(int id)
        {
            return _uOW.COURSEs.GetCourseByCourseId((int)id);
        }

        public IEnumerable<object> GetAllAppointmentsWithAttendeeRequests()
        {
            var client = GetLoggedInClient();
            return _uOW.APPOINTMENTs.GetAllAppointmentsWithAttendeeRequestsFor(client);                   
        }

        public IEnumerable<ATTENDEE> GetAllAttendeesAppliedForCourses()
        {
            return _uOW.ATTENDEEs.GetAllAttendeesAppliedForCourses();
        }

     
    }
}
