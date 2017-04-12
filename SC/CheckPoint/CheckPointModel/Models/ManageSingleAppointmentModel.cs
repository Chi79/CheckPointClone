using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointModel.DTOs;
using CheckPointModel.Utilities;
using CheckPointCommon.ServiceInterfaces;
using CheckPointCommon.FactoryInterfaces;
using CheckPointCommon.Enums;
using CheckPointModel.Services;
using CheckPointDataTables.Tables;

namespace CheckPointModel.Models
{
    public class ManageSingleAppointmentModel : IManageSingleAppointmentModel
    {

        private IFactory _factory;
        private ISessionService _sessionService;
        private IShowAppointments _displayService;

        private JobServiceBase _job;


        public ManageSingleAppointmentModel(IFactory factory, ISessionService sessionService, IShowAppointments displayService)
        {

            _factory = factory;
            _sessionService = sessionService;
            _displayService = displayService;

        }

        public void SetInitialSessionJobState()
        {

            SaveJobTypeToSession();
            GetAppointmentIdFromSession();

        }

        public void SaveJobTypeToSession()
        {

            _sessionService.JobType = (int)_job.Jobtype;

        }

        public void GetAppointmentIdFromSession()
        {

            _job.AppointmentId = (int)_sessionService.SessionAppointmentId;

        }

        public void PrepareUpdateAppointmentJob()
        {

            _job = _factory.CreateAppointmentJobType(DbAction.UpdateAppointment) as JobServiceBase;
            SetInitialSessionJobState();

        }

        public void PrepareAddExistingAppointmentToCourseJob()
        {

            _job = _factory.CreateAppointmentJobType(DbAction.ChangeAppointmentCourseId) as JobServiceBase;
            SetInitialSessionJobState();

        }

        public void PrepareDeleteAppointmentJob()
        {

            _job = _factory.CreateAppointmentJobType(DbAction.DeleteAppointment) as JobServiceBase;
            SetInitialSessionJobState();

        }

        public string GetJobConfirmationMessage()
        {

            return _job.ConfirmationMessage;

        }

        public object GetJobTypeFromSession()
        {

            _job = _factory.CreateAppointmentJobType((DbAction)_sessionService.JobType) as JobServiceBase;

            _job.AppointmentId = (int)_sessionService.SessionAppointmentId;
            _job.CourseId = _sessionService.SessionCourseId;

            return _job;

        }

        public void PerformJob(object appointment)
        {

            _job = GetJobTypeFromSession() as JobServiceBase;

            _job.PerformTask(appointment);

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

        public string GetUpdateErrorMessage()
        {

            var saveResult = _job.SaveChanges();
            return saveResult.ErrorMessage;

        }

        public string GetJobCompletedMessage()
        {

            return _job.CompletedMessage;

        }

        public int GetSessionAppointmentId()
        {

            return (int)_sessionService.SessionAppointmentId;

        }

        public string GetLoggedInClient()
        {

            return _sessionService.LoggedInClient;

        }

        public bool? GetAddingAppointmentToCourseStatus()
        {

            return _sessionService.NewAppointmentAddedToCourseStatus;

        }

        public void ResetAddingAppointmentToCourseStatus()
        {

            _sessionService.NewAppointmentAddedToCourseStatus = false;

        }

        public object ConvertToAppointment(object appointmentModel)
        {

            return AppointmentDTOMapper.ConvertAppointmentDTOToAppointment(appointmentModel as AppointmentDTO);

        }

        public void RefreshAllAppointmentsForClient()
        {

            _displayService.GetAllAppointmentsFor<APPOINTMENT>(_sessionService.LoggedInClient);

        }

        public object GetAppointmentForClientByAppointmentId()
        {

            return _displayService.GetSelectedAppointmentByAppointmentId(GetSessionAppointmentId());

        }

    }
}
