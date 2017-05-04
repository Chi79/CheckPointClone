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
            //List<object> coursesWithAttendeeRequests = new List<object>();

            foreach (var attendee in AttendeesAppliedToCourses)
            {
                var courseToAdd = GetCourseById((int)attendee.CourseId);
                if (clientCourses.Contains(courseToAdd))
                {
                    yield return courseToAdd;
                    //return coursesWithAttendeeRequests.Add(courseToAdd);
                }
            }
            //return coursesWithAttendeeRequests;
        }
        public IEnumerable<COURSE> GetAllCoursesForClient()
        {
            var client = GetLoggedInClient();
            return _unitOfWork.COURSEs.GetAllCoursesFor(client);
        }
        public IEnumerable<ATTENDEE> GetAllAttendeesAppliedForCourses()
        {
            return _unitOfWork.ATTENDEEs.GetAllAttendeesAppliedForCourse();
        }

        public IEnumerable<object> GetClientInformationForAttendees()
        {
            var attendeesForSelectedCourse = GetAttendeesForSelectedCourse();
            List<object> attendeesAsClients = new List<object>();
            foreach (var attendee in attendeesForSelectedCourse)
            {
                var attendeeUsername = attendee.CLIENT_TAG.UserName;
                var clientToAdd = (CLIENT)GetClientByUserName(attendeeUsername);
                attendeesAsClients.Add(clientToAdd);
            }
            return attendeesAsClients;
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

        public void SetSessionRowIndex(int index)
        {
            _sessionService.SessionRowIndex = index;
        }

        public void SaveSelectedCourseIdToSession(int id)
        {
            _sessionService.SessionCourseId = id;
        }

        public void ResetSessionState()
        {
            int noRowSelected = -1;
            int noCourseSelected = -1;
            SetSessionRowIndex(noRowSelected);
            SetSessionCourseId(noCourseSelected);
        }

        public void SetSessionCourseId(int id)
        {
            _sessionService.SessionCourseId = id;
        }

        public IEnumerable<object> GetEmptyClientList()
        {
            return _clientDisplayService.GetEmptyList<CLIENT>();
        }
    }
}
