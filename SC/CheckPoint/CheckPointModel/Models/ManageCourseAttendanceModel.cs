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

        public ManageCourseAttendanceModel(ISessionService sessionService, IUnitOfWork unitOfWork, IShowCourses courseDisplayService)
        {
            _sessionService = sessionService;
            _unitOfWork = unitOfWork;
            _courseDisplayService = courseDisplayService;
        }

        public string GetLoggedInClient()
        {
            return _sessionService.LoggedInClient;
        }

        public IEnumerable<object> GetAllCoursesWithAttendeeRequests()
        {
            var clientCourses = GetAllCoursesForClient();
            var AttendeesAppliedToCourses = GetAllAttendeesAppliedForCourses();
            List<object> coursesWithAttendeeRequests = new List<object>();

            foreach (var attendee in AttendeesAppliedToCourses)
            {
                var courseToAdd = GetCourseById((int)attendee.CourseId);
                if (clientCourses.Contains(courseToAdd))
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
            return _unitOfWork.ATTENDEEs.GetAllAttendeesAppliedForCourse();
        }
        public object GetCourseById(int id)
        {
            return _unitOfWork.COURSEs.GetCourseByCourseId((int)id);
        }

        public IEnumerable<object> GetAllAppointmentsWithAttendeeRequests()
        {
            throw new NotImplementedException();
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

        public void ResetSessionState()
        {
            int noRowSelected = -1;
            int noCourseSelected = -1;
            SetSessionRowIndex(noRowSelected);
            SetSessionCourseId(noCourseSelected);
        }

        private void SetSessionCourseId(int id)
        {
            _sessionService.SessionCourseId = id;
        }

        public IEnumerable<object> GetEmptyAttendeeList()
        {
            return null;
        }
    }
}
