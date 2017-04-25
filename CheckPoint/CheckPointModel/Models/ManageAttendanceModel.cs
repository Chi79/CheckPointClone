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
        public ManageAttendanceModel(ISessionService sessionService, IUnitOfWork unitOfWork, IShowCourses courseDisplayService,
                                        IShowAppointments appointmentDisplayService)
        {
            _sessionService = sessionService;
            _uOW = unitOfWork;
            _courseDisplayService = courseDisplayService;
            _appointmentDisplayService = appointmentDisplayService;
        }

        public string GetLoggedInClient()
        {
            return "morten";
            //return _sessionService.LoggedInClient;
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

        public IEnumerable<object> GetAllCoursesWithAppliedAttendees()
        {
            var clientCourses = GetAllCoursesForClient();
            var AttendeesAppliedToCourses = GetAllAttendeesAppliedForCourses();
            List<object> coursesWithAttendees = new List<object>();
            foreach (var attendee in AttendeesAppliedToCourses)
            {
                coursesWithAttendees.Add(clientCourses.Where(c => c.CourseId == attendee.CourseId).Distinct());
            }
            return coursesWithAttendees;

        }

        public IEnumerable<ATTENDEE> GetAllAttendeesAppliedForCourses()
        {
            return _uOW.ATTENDEEs.GetAllAttendeesAppliedForCourse();
        }



    

       


    }
}
