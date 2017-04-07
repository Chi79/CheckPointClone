using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointDataTables.Tables;
using CheckPointModel.DTOs;
using CheckPointModel.Utilities;
using CheckPointCommon.ServiceInterfaces;
using CheckPointCommon.FactoryInterfaces;
using CheckPointCommon.Enums;
using CheckPointCommon.Structs;
using CheckPointModel.Services;

namespace CheckPointModel.Models
{
    public class ManageSingleAppointmentModel : IManageSingleAppointmentModel
    {
        private IFactory _factory;
        private ISessionService _sessionService;

        private JobServiceBase _job;

        public ManageSingleAppointmentModel(IFactory factory, ISessionService sessionService)
        {
            _factory = factory;
            _sessionService = sessionService;
        }

        public void SetInitialSessionJobState()
        {
            SaveJobTypeToSession();
            GetAppointmentIdFromSession();
        }

        public void SaveJobTypeToSession()
        {
            _sessionService.JobState = (int)_job.Actiontype;
        }

        public void GetAppointmentIdFromSession()
        {
            _job.ItemId = (int)_sessionService.SessionAppointmentId;
        }

        public void PrepareUpdateAppointmentJob()
        {
            _job = _factory.CreateAppointmentJobType(DbAction.UpdateAppointment) as JobServiceBase;
            SetInitialSessionJobState();

        }

        public void PrepareAddExistingAppointmentToCourseJob()
        {
            _job = _factory.CreateAppointmentJobType(DbAction.AddExistingAppointmentToCourse) as JobServiceBase;
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
            _job = _factory.CreateAppointmentJobType((DbAction)_sessionService.JobState) as JobServiceBase;

            _job.ItemId = (int)_sessionService.SessionAppointmentId;
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
            return _sessionService.AddingAppointmentToCourseStatus;
        }

        public void ResetAddingAppointmentToCourseStatus()
        {
            _sessionService.AddingAppointmentToCourseStatus = false;
        }

        public object ConvertToAppointment(object appointmentModel)
        {
            return AppointmentDTOMapper.ConvertAppointmentDTOToAppointment(appointmentModel as AppointmentDTO);
        }
    }
}
