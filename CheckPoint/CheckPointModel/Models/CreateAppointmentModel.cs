using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointModel.DTOs;
using CheckPointModel.Utilities;
using CheckPointCommon.ServiceInterfaces;
using CheckPointModel.Services;
using CheckPointCommon.FactoryInterfaces;
using CheckPointCommon.Enums;

namespace CheckPointModel.Models
{


    public class CreateAppointmentModel : ICreateAppointmentModel
    {
        private IFactory _factory;
        private ISessionService _sessionService;

        private JobServiceBase _job;

        public CreateAppointmentModel(IFactory factory, ISessionService sessionService)
        {

            _factory = factory;
            _sessionService = sessionService;

        }

        public void PrepareAddNewAppointmentToCourseJob()
        {

            _job = _factory.CreateAppointmentJobType(DbAction.AddNewAppointmentToCourse) as JobServiceBase;
            SetInitialSessionJobState();

        }

        public void PrepareCreateNewAppointmentJob()
        {

            _job = _factory.CreateAppointmentJobType(DbAction.CreateAppointment) as JobServiceBase;
            SetInitialSessionJobState();

        }

        public void SetInitialSessionJobState()
        {

            SaveJobTypeToSession();
            GetJobItemNameFromSession();

        }

        public void SaveJobTypeToSession()
        {

            _sessionService.JobType = (int)_job.Jobtype;

        }

        public void SaveAppointmentNameToSession(string appointmentName)
        {

            _sessionService.SessionAppointmentName = appointmentName;

        }

        public bool? GetAddingAppointmentToCourseStatus()
        {

            return _sessionService.AddingAppointmentToCourseStatus;

        }

        public void GetJobItemNameFromSession()
        {

            _job.ItemName = _sessionService.SessionAppointmentName;

        }

        public string GetJobConfirmationMessage()
        {

            return _job.ConfirmationMessage;

        }

        public string GetLoggedInClient()
        {

            return _sessionService.LoggedInClient;

        }


        public object GetJobTypeFromSession()
        {

            _job = _factory.CreateAppointmentJobType((DbAction)_sessionService.JobType) as JobServiceBase;

            _job.CourseId = _sessionService.SessionCourseId;
            _job.ItemName = _sessionService.SessionAppointmentName; 

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


        public void ResetAddingAppointmentToCourseStatus()
        {

            _sessionService.AddingAppointmentToCourseStatus = false;

        }

        public object ConvertToAppointment(object appointmentDTO)
        {

            return AppointmentDTOMapper.ConvertAppointmentDTOToAppointment(appointmentDTO as AppointmentDTO);

        }
    }
}
