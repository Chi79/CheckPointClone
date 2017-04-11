using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointDataTables.Tables;
using CheckPointCommon.ServiceInterfaces;

namespace CheckPointModel.Models
{
    public class ManageCourseModel : IManageCourseModel
    {

        private ISessionService _sessionService;
        private IShowAppointments _appointmentDisplayService;
        private IShowCourses _coursesDisplayService;


        public ManageCourseModel(ISessionService sessionService, IShowAppointments appointmentDisplayService,
                                 IShowCourses coursesDisplayService)

        {

            _sessionService = sessionService;
            _appointmentDisplayService = appointmentDisplayService;
            _coursesDisplayService = coursesDisplayService;

        }

        public int? GetSessionRowIndex()
        {

            return _sessionService.SessionRowIndex;

        }

        public void SetSessionRowIndex(int index)
        {

            _sessionService.SessionRowIndex = index;

        }

        public bool GetNewAppointmentAddedToCourseStatus()
        {

            return (bool)_sessionService.NewAppointmentAddedToCourseStatus;

        }

        public void ResetNewAppointmentAddedToCourseStatus()
        {
            _sessionService.NewAppointmentAddedToCourseStatus = false;
        }

        public int? GetSessionAppointmentId()
        {

            return _sessionService.SessionAppointmentId;
        }

        public void SetSessionAppointmentId(int id)
        {

            _sessionService.SessionAppointmentId = id;

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
