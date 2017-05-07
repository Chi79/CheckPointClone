using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ServiceInterfaces;
using CheckPointCommon.FactoryInterfaces;
using CheckPointDataTables.Tables;

namespace CheckPointModel.Models
{
    class ApplyToCourseModel:IApplyToCourseModel
    {
        private readonly ISessionService _sessionService;
        private readonly IFactory _factory;
        private readonly IShowAppointments _displayService;

        public ApplyToCourseModel(ISessionService sessionService,IFactory factory,IShowAppointments displayService)
        {
            _sessionService = sessionService;
            _displayService = displayService;
            _factory = factory;
        }

        public IEnumerable<object> GetAppointmentsInCourse()
        {
            return _displayService.GetAllAppointmentsForClientByCourseId<APPOINTMENT>(_sessionService.SessionCourseId);
            
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
        public string GetLoggedInClientTagId()
        {
            return _sessionService.ClientTagId;
        }
        public IEnumerable<object> GetEmptyList()
        {

            return _displayService.GetEmptyList<APPOINTMENT>();

        }
    }

}
