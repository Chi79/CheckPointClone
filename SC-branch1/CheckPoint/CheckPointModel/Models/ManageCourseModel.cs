using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointDataTables.Tables;
using CheckPointCommon.ServiceInterfaces;
using CheckPointCommon.FactoryInterfaces;
using CheckPointCommon.Enums;
using CheckPointModel.Services;

namespace CheckPointModel.Models
{
    public class ManageCourseModel : IManageCourseModel
    {

        private ISessionService _sessionService;
        private IShowAppointments _appointmentDisplayService;
        private IShowCourses _coursesDisplayService;
        private IFactory _factory;


        public ManageCourseModel(ISessionService sessionService, IShowAppointments appointmentDisplayService,
                                 IShowCourses coursesDisplayService, IFactory factory)

        {

            _sessionService = sessionService;
            _appointmentDisplayService = appointmentDisplayService;
            _coursesDisplayService = coursesDisplayService;
            _factory = factory;
        }

        public int? GetSessionRowIndex()
        {

            return _sessionService.SessionRowIndex;

        }

        public void SetSessionRowIndex(int index)
        {

            _sessionService.SessionRowIndex = index;

        }

        public void ResetSessionRowIndex()
        {

            _sessionService.SessionRowIndex = -1;

        }

        public void ResetCourseDeletedStatus()
        {

            _sessionService.DeletedCourseStatus = false;

        }

        public bool GetNewAppointmentAddedToCourseStatus()
        {

            return (bool)_sessionService.NewAppointmentAddedToCourseStatus;

        }

        public bool GetCourseUpdatedStatus()
        {

            return (bool)_sessionService.UpdatedCourseStatus;

        }

        public void ResetUpdateCourseStatus()
        {

            _sessionService.UpdatedCourseStatus = false;

        }

        public void SetValidNavigationStatus()
        {

            _sessionService.NavigationIsValid = true;

        }

        public void ResetValidNavigationStatus()
        {

            _sessionService.NavigationIsValid = false;
        }

        public void ResetNewAppointmentAddedToCourseStatus()
        {

            _sessionService.NewAppointmentAddedToCourseStatus = false;

        }
       
        public bool GetAppointmentDeletedFromCourseStatus()
        {

            return (bool)_sessionService.AppointmentDeletedFromCourseStatus;

        }

        public void ResetAppointmentDeletedFromCourseStatus()
        {

            _sessionService.AppointmentDeletedFromCourseStatus = false;

        }

        public int? GetSessionAppointmentId()
        {

            return _sessionService.SessionAppointmentId;

        }

        public void SetSessionAppointmentId(int id)
        {

            _sessionService.SessionAppointmentId = id;

        }

        public void ResetSessionAppointmentId()
        {

            _sessionService.SessionAppointmentId = -1;

        }

        public void SetSessionCourseId(int id)
        {

            _sessionService.SessionCourseId = id;

        }

        public int? GetSessionCourseId()
        {

            return _sessionService.SessionCourseId;

        }

        public void ResetSessionState()
        {

            int noRowSelected = -1;
            int noAppointmentSelected = -1;
            SetSessionRowIndex(noRowSelected);
            SetSessionAppointmentId(noAppointmentSelected);

        }

        public string GetColumnName()
        {

            return _sessionService.ColumnName;

        }

        public string GetLoggedInClient()
        {

            return _sessionService.LoggedInClient;

        }

        public void RemoveSelectedAppointmentFromCourse()
        {

            var selectedAppointment = _appointmentDisplayService.GetSelectedAppointmentByAppointmentId(GetSessionAppointmentId()) as APPOINTMENT;
            selectedAppointment.CourseId = null;

            var job = _factory.CreateAppointmentJobType(DbAction.ChangeAppointmentCourseId) as JobServiceBase;
            job.AppointmentId = (int)_sessionService.SessionAppointmentId;
            job.CourseId = null;
            job.PerformTask(selectedAppointment);
            job.SaveChanges();

            _sessionService.AppointmentDeletedFromCourseStatus = true;

        }

        public IEnumerable<object> GetAllAppointmentsForClient()
        {

            return _appointmentDisplayService.GetAllAppointmentsFor<APPOINTMENT>(GetLoggedInClient());

        }

        public IEnumerable<object> GetAllAppointmentsForClientByCourseId()
        {

            return _appointmentDisplayService.GetAllAppointmentsForClientByCourseId<APPOINTMENT>(GetSessionCourseId());

        }

        public IEnumerable<object> GetEmptyAppointmentList()
        {

            return _appointmentDisplayService.GetEmptyList<APPOINTMENT>();

        }

        public IEnumerable<object> GetEmptyCourseList()
        {

            return _coursesDisplayService.GetEmptyList<COURSE>();

        }

        public IEnumerable<object> GetCachedAppointments()
        {

            return _appointmentDisplayService.GetAppointmentsCached<APPOINTMENT>();

        }

        public IEnumerable<object> GetCachedCourses()
        {

            return _coursesDisplayService.GetCoursesCached<COURSE>();

        }

        public IEnumerable<object> GetCachedAppointmentsInCourse()
        {

            return _appointmentDisplayService.GetAppointmentsInCourseCached<APPOINTMENT>();

        }

        public IEnumerable<object> GetAppointmentsInCourseSortedByPropertyAsc()
        {

            return _appointmentDisplayService.GetAppointmentsInCourseSortedByPropertyAscending<object>(GetColumnName());

        }

        public IEnumerable<object> GetAppointmentsInCourseSortedByPropertyDesc()
        {

            return _appointmentDisplayService.GetAppointmentsInCourseSortedByPropertyDescending<object>(GetColumnName());

        }

        public IEnumerable<object> GetSelectedCourse()
        {

            List<COURSE> selectedCourseAsList = _coursesDisplayService.GetEmptyList<COURSE>().ToList();

            var selectedCourse = _coursesDisplayService.GetSelectedCourseByCourseId(GetSessionCourseId());

            selectedCourseAsList.Add(selectedCourse as COURSE);

            return selectedCourseAsList;

        }
    }
}
