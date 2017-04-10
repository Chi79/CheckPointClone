using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointDataTables.Tables;
using CheckPointModel.DTOs;
using CheckPointCommon.ServiceInterfaces;

namespace CheckPointModel.Models
{
    public class ManageCourseModel : IManageCourseModel
    {
        private ISessionService _sessionService;
        private IShowAppointments _displayService;

        public ManageCourseModel(ISessionService sessionService, IShowAppointments displayService)
        {
            _sessionService = sessionService;
            _displayService = displayService;
        }

        public int? GetSessionRowIndex()
        {
            return _sessionService.SessionRowIndex;
        }

        public void SetSessionRowIndex(int index)
        {
            _sessionService.SessionRowIndex = index;
        }

        public void SetSessionAppointmentId(int id)
        {
            _sessionService.SessionAppointmentId = id;
        }

        public void SetSessionCourseId(int id)
        {
            _sessionService.SessionCourseId = id;
        }

        public void ResetSessionState()
        {
            SetSessionRowIndex(-1);
            SetSessionAppointmentId(-1);
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
            return _displayService.GetAllAppointmentsFor<APPOINTMENT>(GetLoggedInClient());
        }

        public IEnumerable<object> GetAllAppointmentsForClientByCourseId(int? courseId)
        {
            return _displayService.GetAllAppointmentsForClientByCourseId<APPOINTMENT>(courseId);
        }

        public IEnumerable<object> GetEmptyList()
        {
            return _displayService.GetEmptyList<APPOINTMENT>();
        }

        public IEnumerable<object> GetCachedAppointments()
        {
            return _displayService.GetAppointmentsCached<APPOINTMENT>();
        }

        public IEnumerable<object> GetCachedAppointmentsInCourse()
        {
            return _displayService.GetAppointmentsInCourseCached<APPOINTMENT>();
        }

        public IEnumerable<object> GetAppointmentsInCourseSortedByPropertyAsc()
        {
            return _displayService.GetAppointmentsInCourseSortedByPropertyAscending<object>(GetColumnName());
        }

        public IEnumerable<object> GetAppointmentsInCourseSortedByPropertyDesc()
        {
            return _displayService.GetAppointmentsInCourseSortedByPropertyDescending<object>(GetColumnName());
        }
    }
}
