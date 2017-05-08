using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ServiceInterfaces;
using CheckPointCommon.FactoryInterfaces;
using CheckPointDataTables.Tables;
using CheckPointModel.Services;
using CheckPointCommon.Enums;

namespace CheckPointModel.Models
{
   public class ApplyToCourseModel:IApplyToCourseModel
    {
        private readonly ISessionService _sessionService;
        private readonly IFactory _factory;
        private readonly IShowAppointments _appointmentDisplayService;
        private IShowCourses _coursesDisplayService;
        

        private JobServiceBase _job;
        private ATTENDEE _attendee;
        public ApplyToCourseModel(ISessionService sessionService,IFactory factory,IShowAppointments displayService, IShowCourses coursesDisplayService)
        {
            _sessionService = sessionService;
            _appointmentDisplayService = displayService;
            _factory = factory;
            _coursesDisplayService = coursesDisplayService;
        }

        public IEnumerable<object> GetAppointmentsInCourse()
        {
            return _appointmentDisplayService.GetAllAppointmentsForClientByCourseId<APPOINTMENT>(_sessionService.SessionCourseId);
            
        }
        public object GetJobTypeFromSession()
        {

            _job = _factory.CreateAttendeeJobType((DbAction)_sessionService.JobType) as CreateMultipleAttendeesJob;
         
            return _job;

        }
        public List<ATTENDEE> CreateAttendeesFromAppointmentsInCourse()
        {
            var appointmentList = (List<APPOINTMENT>)GetAppointmentsInCourse();

            var attendeeList = new List<ATTENDEE>();

            var tagId = GetLoggedInClientTagId();

            var courseId = GetSessionCourseId();

            foreach(APPOINTMENT appointment in appointmentList)
            {
                _attendee = new ATTENDEE()
                {
                    AppointmentId = appointment.AppointmentId,
                    TagId = tagId,
                    StatusId = (int)AttendeeStatus.RequestedToAttend,
                    CourseId = courseId
                };
                attendeeList.Add(_attendee);
            }

            return attendeeList;
        }

        public bool AppointmentsInCourse()
        {
            bool appointmentsInCourse = GetAppointmentsInCourse().Any<object>();

            if(appointmentsInCourse)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PrepareCreateMultipleAttendeesJob()
        {
            _job = _factory.CreateAttendeeJobType(DbAction.CreateMultipleAttendees) as CreateMultipleAttendeesJob;

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
        public void PerformJob()
        {
            _job = GetJobTypeFromSession() as CreateMultipleAttendeesJob;
           
            
            var attendeeList = CreateAttendeesFromAppointmentsInCourse() as IEnumerable<ATTENDEE>;

            _job.PerformTask(attendeeList);
        }
        public string GetUpdateErrorMessage()
        {

            var saveResult = _job.SaveChanges();
            return saveResult.ErrorMessage;

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

 
        public string GetJobConfirmationMessage()
        {
            return _job.ConfirmationMessage;
        }
        public string GetJobCompletedMessage()
        {
            return _job.CompletedMessage;
        }
        public void SetSessionRowIndex(int index)
        {

            _sessionService.SessionRowIndex = index;

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

        public string GetLoggedInClientTagId()
        {
            return _sessionService.ClientTagId;
        }

        public int? GetSessionCourseId()
        {

            return _sessionService.SessionCourseId;

        }
        public IEnumerable<object> GetSelectedCourse()
        {

            List<COURSE> selectedCourseAsList = _coursesDisplayService.GetEmptyList<COURSE>().ToList();

            var selectedCourse = _coursesDisplayService.GetSelectedPublicCourseByCourseId(GetSessionCourseId());

            selectedCourseAsList.Add(selectedCourse as COURSE);

            return selectedCourseAsList;

        }



        public IEnumerable<object> GetEmptyAppointmentList()
        {

            return _appointmentDisplayService.GetEmptyList<APPOINTMENT>();

        }

        public IEnumerable<object> GetEmptyCourseList()
        {

            return _coursesDisplayService.GetEmptyList<COURSE>();

        }



        public IEnumerable<object> GetCachedPublicCourses()
        {

            return _coursesDisplayService.GetPublicCoursesCached<COURSE>();

        }



        public IEnumerable<object> GetAppointmentsInCourseSortedByPropertyAsc()
        {

            return _appointmentDisplayService.GetAppointmentsInCourseSortedByPropertyAscending<object>(GetColumnName());

        }

        public IEnumerable<object> GetAppointmentsInCourseSortedByPropertyDesc()
        {

            return _appointmentDisplayService.GetAppointmentsInCourseSortedByPropertyDescending<object>(GetColumnName());

        }

 
    }

}
