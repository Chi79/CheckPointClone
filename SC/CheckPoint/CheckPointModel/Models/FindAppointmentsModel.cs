using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ServiceInterfaces;
using CheckPointDataTables.Tables;
using CheckPointCommon.RepositoryInterfaces;
using CheckPointCommon.FactoryInterfaces;
using CheckPointCommon.Enums;
using CheckPointModel.Services;
using CheckPointModel.Utilities;
using CheckPointCommon.DTOInterfaces;

namespace CheckPointModel.Models
{
    public class FindAppointmentsModel : IFindAppointmentsModel
    {

        private readonly ISessionService _sessionService;
        private readonly IShowAppointments _displayService;
        private IFactory _factory;

        
        private JobServiceBase _job;
        public FindAppointmentsModel(ISessionService sessionService,IFactory factory, IShowAppointments displayService)
        {
            _factory = factory;// add to ioc?
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

        public IEnumerable<object> GetAllPublicAppointments()
        {

            return _displayService.GetAllPublicAppointments<APPOINTMENT>();

        }

        public IEnumerable<object> GetEmptyList()
        {

            return _displayService.GetEmptyList<APPOINTMENT>();

        }

        public IEnumerable<object> GetCachedAppointments()
        {

            return _displayService.GetPublicAppointmentsCached<APPOINTMENT>();

        }

        public IEnumerable<object> GetAppointmentsSortedByPropertyAsc()
        {

            return _displayService.GetPublicAppointmentsSortedByPropertyAscending<object>(GetColumnName());

        }

        public IEnumerable<object> GetAppointmentsSortedByPropertyDesc()
        {

            return _displayService.GetPublicAppointmentsSortedByPropertyDescending<object>(GetColumnName());

        }
        public string GetClientTagId()
        {
            return _sessionService.ClientTagId;
        }

        public void PrepareCreateAttendee()
        {
            _job = _factory.CreateAttendeeJobType(DbAction.CreateAttendee) as JobServiceBase;
            SetInitialSessionJobState();
           
        }

        public void SetInitialSessionJobState()
        {
            SaveJobTypeToSession();        
        }
        public void SaveJobTypeToSession()
        {
            _sessionService.JobType = (int)_job.Jobtype;
        }
        public object ConvertToAttendee(object dTO)
        {
            return AttendeeDTOMapper.ConvertAttendeeDTOToAttendee(dTO as IAttendeeDTO);
        }
        public void PerformJob(object attendee)
        {

            _job.PerformTask(attendee);

        }
        public bool UpdateDatabaseWithChanges()
        {

            var saveResult = _job.SaveChanges();

            bool IsSavedToDb = saveResult.Result > 0;
            if (IsSavedToDb)
            {
                return true;

            }
            else
            {
                return false;
            }

        }
       public string GetJobCompletedMessage()
        {
            return _job.CompletedMessage;
        }
        public string GetUpdateErrorMessage()
        {

            var saveResult = _job.SaveChanges();
            return saveResult.ErrorMessage;

        }
    }

}
