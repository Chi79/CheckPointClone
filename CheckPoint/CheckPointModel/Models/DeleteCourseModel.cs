using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ServiceInterfaces;
using CheckPointCommon.FactoryInterfaces;
using CheckPointModel.Services;
using CheckPointModel.Utilities;
using CheckPointCommon.Enums;
using CheckPointDataTables.Tables;
using CheckPointModel.DTOs;

namespace CheckPointModel.Models
{
    public class DeleteCourseModel : IDeleteCourseModel
    {
        private IShowCourses _courseDisplayService;
        private IShowAppointments _appointmentDisplayService;
        private ISessionService _sessionService;
        private IFactory _factory;

        private JobServiceBase _job;

        public DeleteCourseModel(IShowCourses courseDisplayService, IShowAppointments appointmentDisplayService,
                                 ISessionService sessionService, IFactory factory)
        {

            _appointmentDisplayService = appointmentDisplayService;
            _courseDisplayService = courseDisplayService;
            _sessionService = sessionService;
            _factory = factory;

        }

        public string GetLoggedInClient()
        {

            return _sessionService.LoggedInClient;
        }

        public object GetSelectedCourseByCourseId()
        {

            return _courseDisplayService.GetSelectedCourseByCourseId(GetSessionCourseId());

        }

        public bool GetDeleteCourseStatus()
        {

            return (bool)_sessionService.DeletedCourseStatus;

        }

        public void SetDeleteCourseStatus()
        {

            _sessionService.DeletedCourseStatus = true;

        }

        private int? GetSessionCourseId()
        {

            return _sessionService.SessionCourseId;

        }

        public void SetInitialSessionJobState()
        {

            SaveJobTypeToSession();
            GetCourseIdFromSession();

        }

        public void PrepareDeleteCourseJob()
        {
            

            _job = _factory.CreateCourseJobType(DbAction.DeleteCourse) as JobServiceBase;

            SetInitialSessionJobState();

        }

        private void SaveJobTypeToSession()
        {

            _sessionService.JobType = (int)_job.Jobtype;

        }

        private void GetCourseIdFromSession()
        {

            _job.CourseId = _sessionService.SessionCourseId;

        }

        public string GetJobCompletedMessage()
        {

            return _job.CompletedMessage;

        }

        private object GetJobTypeFromSession()
        {

            _job = _factory.CreateCourseJobType((DbAction)_sessionService.JobType) as JobServiceBase;

            _job.CourseId = (int)_sessionService.SessionCourseId;

            return _job;

        }

        public string GetJobConfirmationMessage()
        {

            return _job.ConfirmationMessage;

        }

        public object ConvertToCourse(object courseModel)
        {

            return CourseDTOMapper.ConvertCourseDTOToCourse(courseModel as CourseDTO);

        }

        public void PerformJob(object course)
        {

            _job = GetJobTypeFromSession() as JobServiceBase;

            _job.PerformTask(course);

            FindAssociatedAppointmentsFromCourse();

        }

        private void FindAssociatedAppointmentsFromCourse()
        {

            List<APPOINTMENT> appointmentsInCourse = _appointmentDisplayService.GetAllAppointmentsForClientByCourseId<APPOINTMENT>(GetSessionCourseId()).ToList();

            if(appointmentsInCourse.Count > 0)
            {

                RemoveAppointmentsFromCourse(appointmentsInCourse);

            }
          
        }

        private void RemoveAppointmentsFromCourse(List<APPOINTMENT> appointmentsInCourse)
        {

            foreach ( APPOINTMENT appointment in appointmentsInCourse)
            {

                var job = _factory.CreateAppointmentJobType(DbAction.ChangeAppointmentCourseId) as JobServiceBase;
                job.AppointmentId = appointment.AppointmentId;
                job.CourseId = null;
                job.PerformTask(appointment);
                job.SaveChanges();

            }
            
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

        public void RefreshCourseCache()
        {

            _courseDisplayService.GetAllCoursesFor<COURSE>(GetLoggedInClient());

        }

    }
}
