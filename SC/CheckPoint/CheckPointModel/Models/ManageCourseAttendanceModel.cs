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
    public class ManageCourseAttendanceModel : IManageCourseAttendanceModel
    {
        private ISessionService _sessionService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IShowCourses _courseDisplayService;
        private readonly IShowClients _clientDisplayService;

        public ManageCourseAttendanceModel(ISessionService sessionService, IUnitOfWork unitOfWork, IShowCourses courseDisplayService,
                                            IShowClients clientDisplayService)
        {
            _sessionService = sessionService;
            _unitOfWork = unitOfWork;
            _courseDisplayService = courseDisplayService;
            _clientDisplayService = clientDisplayService;
        }

        public string GetLoggedInClient()
        {
            return _sessionService.LoggedInClient;
        }

        public IEnumerable<object> GetAllCoursesWithAttendeeRequests()
        {
            var clientCourses = GetAllCoursesForClient();
            var AttendeesAppliedToCourses = GetAllAttendeesAppliedForCourses();
            var coursesWithAttendeeRequests = new HashSet<object>();

            foreach (var attendee in AttendeesAppliedToCourses)
            {
                var courseToAdd = (COURSE)GetCourseById((int)attendee.CourseId);
                if (clientCourses.Contains(courseToAdd) && courseToAdd.APPOINTMENTs.Count != 0)
                {
                    coursesWithAttendeeRequests.Add(courseToAdd);
                }
            }
            return coursesWithAttendeeRequests;
        }
        public IEnumerable<COURSE> GetAllCoursesForClient()
        {
            var client = GetLoggedInClient();
            return _unitOfWork.COURSEs.GetAllCoursesFor(client);
        }
        public IEnumerable<ATTENDEE> GetAllAttendeesAppliedForCourses()
        {
            return _unitOfWork.ATTENDEEs.GetAllAttendeesAppliedForCourses();
        }

        public IEnumerable<object> GetClientInformationForAttendees()
        {
            var attendeesForSelectedCourse = GetAttendeesForSelectedCourse();
            var appliedAttendeesAsClients = new HashSet<object>();

            foreach (var attendee in attendeesForSelectedCourse)
            {
                var username = attendee.CLIENT_TAG.UserName;

                var attendeeAsClient = (CLIENT)GetClientByUserName(username);

                appliedAttendeesAsClients.Add(attendeeAsClient);
            }
            return appliedAttendeesAsClients;
        }

        private IEnumerable<ATTENDEE> GetAttendeesForSelectedCourse()
        {
            var selectedCourseId = (int)_sessionService.SessionCourseId;
            return _unitOfWork.ATTENDEEs.GetAllAttendeesAppliedForCourseById(selectedCourseId);
        }      

        public object GetClientByUserName(string userName)
        {
            return _unitOfWork.CLIENTs.GetAClientByName(userName);
        }

        public object GetCourseById(int id)
        {
            return _unitOfWork.COURSEs.GetCourseByCourseId((int)id);
        }

        public IEnumerable<object> GetEmptyCourseList()
        {
            return _courseDisplayService.GetEmptyList<COURSE>();
        }

        public int? GetSessionRowIndex()
        {
            return _sessionService.SessionRowIndex;
        }

        public string GetSessionAttendeeUsername()
        {
            return _sessionService.SessionAttendeeUsername;
        }

        public void ChangeSelectedAttendeesStatusToApproved()
        {
            //this should probably be refactored at some point

            var username = GetSessionAttendeeUsername();
            var attendeesToApprove = new HashSet<ATTENDEE>();
            var tagIdForUsername = _unitOfWork.Client_TagIds.GetClientTagId(username);

            var appointmentsInCourse = GetAppointmentsInCourse();
            
            foreach (APPOINTMENT appointment in appointmentsInCourse)
            {
                var attendeeToApprove = _unitOfWork.ATTENDEEs.GetAttendeeByTagIdAndAppointmentId(tagIdForUsername, appointment.AppointmentId) as ATTENDEE;
                if(attendeeToApprove != null)
                {
                    attendeesToApprove.Add((ATTENDEE)attendeeToApprove);
                }              
            }

            foreach(ATTENDEE attendee in attendeesToApprove)
            {
                attendee.StatusId = (int)AttendeeStatus.RequestApproved;
                
            }
            _unitOfWork.Complete();
            
        }

        private IEnumerable<object> GetAllAttendeesByUsername(string username)
        {
            return _unitOfWork.ATTENDEEs.GetAllAttendeesByUserName(username);
        }


        private IEnumerable<object> GetAppointmentsForAttendee(string username)
        {
            return _unitOfWork.APPOINTMENTs.GetAllAppointmentsFor(username);
        }

        private IEnumerable<object> GetAppointmentsInCourse()
        {
            var courseId = _sessionService.SessionCourseId;

            return _unitOfWork.APPOINTMENTs.GetAllAppointmentsByCourseId(courseId);
        }

        public void ChangeAllAttendeesStatusesToApproved()
        {
            var attendeesToApprove = GetAllAttendeesToApproveForCourse();

            foreach(ATTENDEE attendee in attendeesToApprove)
            {
                attendee.StatusId = (int)AttendeeStatus.RequestApproved;
            }
            _unitOfWork.Complete();
        }

        private IEnumerable<ATTENDEE> GetAllAttendeesToApproveForCourse()
        {
            var courseId = (int)_sessionService.SessionCourseId;

            return _unitOfWork.ATTENDEEs.GetAllAttendeesAppliedForCourseById(courseId);
        }

        public ATTENDEE GetAttendeeToApproveForCourse()
        {
            var username = _sessionService.SessionAttendeeUsername;
            var courseId = (int)_sessionService.SessionCourseId;

            return _unitOfWork.ATTENDEEs.GetAttendeeByUserNameAndCourseId(username, courseId) as ATTENDEE;           
        }

        public void SetSessionRowIndex(int index)
        {
            _sessionService.SessionRowIndex = index;
        }

        public void SetAttendeeUsername(string username)
        {
            _sessionService.SessionAttendeeUsername = username;
        }

        public void ResetSessionState()
        {
            int noRowSelected = -1;
            int noCourseSelected = -1;
            string noAttendeeSelected = string.Empty;
            SetSessionRowIndex(noRowSelected);
            SetSessionCourseId(noCourseSelected);
            SetSessionAttendeeUsername(noAttendeeSelected);
        }

        private void SetSessionAttendeeUsername(string username)
        {
            _sessionService.SessionAttendeeUsername = username;
        }

        public void SetSessionCourseId(int id)
        {
            _sessionService.SessionCourseId = id;
        }

        public int GetSessionCourseId()
        {
            return (int)_sessionService.SessionCourseId;
        }

        public IEnumerable<object> GetEmptyClientList()
        {
            return _clientDisplayService.GetEmptyList<CLIENT>();
        }
    }
}
