using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ServiceInterfaces;
using CheckPointCommon.FactoryInterfaces;
using CheckPointCommon.Enums;
using CheckPointModel.Services;
using CheckPointDataTables.Tables;


namespace CheckPointModel.Models
{
    public class CourseSelectorModel : ICourseSelectorModel
    {
        private readonly IShowAppointments _appointmentDisplayService;
        private readonly IShowCourses _courseDisplayService;
        private readonly ISessionService _sessionService;
        private readonly IFactory _factory;

        public CourseSelectorModel(IShowAppointments appointmentDisplayService, IShowCourses courseDisplayService,
                                   ISessionService sessionService, IFactory factory)
        {
            _appointmentDisplayService = appointmentDisplayService;
            _courseDisplayService = courseDisplayService;
            _sessionService = sessionService;
            _factory = factory;
        }

        public object GetSelectedAppointment()
        {
            return _appointmentDisplayService.GetSelectedAppointmentByAppointmentId(_sessionService.SessionAppointmentId);

        }

        public string GetLoggedInClient()
        {

            return _sessionService.LoggedInClient;

        }

        public string GetColumnName()
        {

            return _sessionService.ColumnName;

        }

        public int? GetSessionRowIndex()
        {

            return _sessionService.SessionRowIndex;

        }

        public int? GetSessionCourseId()
        {

           return _sessionService.SessionCourseId;

        }

        public void SetNewAppointmentAddedToCourseStatus()
        {

            _sessionService.NewAppointmentAddedToCourseStatus = true;

        }

        public void ResetNewAppointmentAddedToCourseStatus()
        {

            _sessionService.NewAppointmentAddedToCourseStatus = false;

        }

        public void ResetSessionState()
        {

            int noRowSelected = -1;
            int noCourseSelected = -1;
            SetSessionRowIndex(noRowSelected);
            SetSessionCourseId(noCourseSelected);

        }

        public void SetSessionRowIndex(int index)
        {

            _sessionService.SessionRowIndex = index;

        }

        public void SetSessionCourseId(int id)
        {

            _sessionService.SessionCourseId = id;

        }

        public void AddSelectedAppointmentToCourse(object appointment)
        {

            var job =_factory.CreateAppointmentJobType(DbAction.AddExistingAppointmentToCourse) as JobServiceBase;
            job.AppointmentId = (int)_sessionService.SessionAppointmentId;
            job.CourseId = _sessionService.SessionCourseId;
            job.PerformTask(appointment);
            job.SaveChanges();

        }

        public IEnumerable<object> GetAllCoursesForClient()
        {

            return _courseDisplayService.GetAllCoursesFor<COURSE>(GetLoggedInClient());

        }

        public IEnumerable<object> GetEmptyList()
        {

            return _courseDisplayService.GetEmptyList<COURSE>();

        }

        public IEnumerable<object> GetCachedCourses()
        {

            return _courseDisplayService.GetCoursesCached<COURSE>();

        }

        public IEnumerable<object> GetCoursesSortedByPropertyAsc()
        {

            return _courseDisplayService.GetCoursesSortedByPropertyAscending<COURSE>(GetColumnName());

        }

        public IEnumerable<object> GetCoursesSortedByPropertyDesc()
        {

            return _courseDisplayService.GetCoursesSortedByPropertyDescending<COURSE>(GetColumnName());

        }

    }
}
