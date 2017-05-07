using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.FactoryInterfaces;
using CheckPointCommon.ServiceInterfaces;
using CheckPointModel.Services;
using CheckPointCommon.Enums;
using CheckPointDataTables.Tables;



namespace CheckPointModel.Models
{

    public class ApplyToAttendAppointmentModel : IApplyToAttendAppointmentModel
    {

        private readonly IFactory _factory;
        private readonly ISessionService _sessionService;
        private readonly IShowAppointments _displayService;

        private JobServiceBase _job;
        private ATTENDEE _attendee; 


        public ApplyToAttendAppointmentModel(IFactory factory, ISessionService sessionService, IShowAppointments displayService)
        {

            _factory = factory;
            _sessionService = sessionService;
            _displayService = displayService;

        }

        public void CreateAttendee()
        {

            _job = _factory.CreateAttendeeJobType(DbAction.CreateAttendee) as JobServiceBase;
            SetInitialSessionJobState();

        }

        public void SetInitialSessionJobState()
        {

            SaveJobTypeToSession();

            CreateAttendeeFromSession();

            PerformJob();

        }

        public void SaveJobTypeToSession()
        {

            _sessionService.JobType = (int)_job.Jobtype;

        }

        public void CreateAttendeeFromSession()
        {
            _attendee = new ATTENDEE()
            {

                AppointmentId = (int)GetSessionAppointmentId(),
                TagId = GetLoggedInClientTagId(),
                StatusId = (int)AttendeeStatus.RequestedToAttend
 
            };
        }
            
        
        public int?  GetSessionAppointmentId()
        {

            return _sessionService.SessionAppointmentId;

        }

        public void SetSessionAppointmentId(int appointmentId)
        {

            _sessionService.SessionAppointmentId = appointmentId;

        }
   

        public string GetLoggedInClientTagId()
        {

            return _sessionService.ClientTagId;

        }

        public void PerformJob()
        {

            _job.PerformTask(_attendee);

        }

        public bool UpdateDatabaseWithChanges()
        {

            var saveResult = _job.SaveChanges();

            bool isSavedToDB = saveResult.Result > 0;
            if(isSavedToDB)
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

        public object GetPublicAppointmentByAppointmentId()
        {

            return _displayService.GetSelectedPublicAppointmentByAppointmentId(GetSessionAppointmentId());

        }
    }

}
