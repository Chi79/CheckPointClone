using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ServiceInterfaces;
using CheckPointDataTables.Tables;
using CheckPointModel.Services;
using CheckPointCommon.FactoryInterfaces;
using CheckPointCommon.Enums;

namespace CheckPointModel.Models
{
    public class AppointmentSelectorModel : IAppointmentSelectorModel
    {

        private ISessionService _sessionService;
        private IShowAppointments _displayService;
        private IFactory _factory;


        public AppointmentSelectorModel(ISessionService sessionService, IShowAppointments displayService, IFactory factory)
        {

            _sessionService = sessionService;
            _displayService = displayService;
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

        public int? GetSessionAppointmentId()
        {

            return _sessionService.SessionAppointmentId;

        }

        public bool? GetValidNavigationStatus()
        {

            return _sessionService.NavigationIsValid;

        }

        public void SetSessionAppointmentId(int id)
        {

            _sessionService.SessionAppointmentId = id;

        }

        public int? GetSessionCourseId()
        {

            return _sessionService.SessionCourseId;

        }

        public void ResetSessionState()
        {

            int noRowSelected = -1;

            SetSessionRowIndex(noRowSelected);

        }

        public void SetNewAppointmentAddedToCourseStatus()
        {

            _sessionService.NewAppointmentAddedToCourseStatus = true;

        }

        public string GetColumnName()
        {

            return _sessionService.ColumnName;

        }

        public string GetLoggedInClient()
        {

            return _sessionService.LoggedInClient;

        }

        private object GetSelectedAppointment()
        {

            return _displayService.GetSelectedAppointmentByAppointmentId(GetSessionAppointmentId());

        }

        public IEnumerable<object> GetAllAppointmentsForClient()
        {

            return _displayService.GetAllAppointmentsFor<APPOINTMENT>(GetLoggedInClient());

        }

        public IEnumerable<object> GetEmptyList()
        {

            return _displayService.GetEmptyList<APPOINTMENT>();

        }

        public IEnumerable<object> GetCachedAppointments()
        {

            return _displayService.GetAppointmentsCached<APPOINTMENT>();

        }

        public IEnumerable<object> GetAppointmentsSortedByPropertyAsc()
        {

            return _displayService.GetAppointmentsSortedByPropertyAscending<object>(GetColumnName());

        }

        public IEnumerable<object> GetAppointmentsSortedByPropertyDesc()
        {

            return _displayService.GetAppointmentsSortedByPropertyDescending<object>(GetColumnName());

        }

        public void AddSelectedAppointmentToCourse()
        {

            var selectedAppointment = GetSelectedAppointment() as APPOINTMENT;

            var job = _factory.CreateAppointmentJobType(DbAction.ChangeAppointmentCourseId) as JobServiceBase;
            job.AppointmentId = (int)_sessionService.SessionAppointmentId;
            job.CourseId = _sessionService.SessionCourseId;
            job.PerformTask(selectedAppointment);
            job.SaveChanges();

            _sessionService.NewAppointmentAddedToCourseStatus = true;

        }

    }
}
