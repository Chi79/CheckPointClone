using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointModel.DTOs;
using CheckPointModel.Utilities;
using CheckPointCommon.FactoryInterfaces;
using CheckPointCommon.ServiceInterfaces;
using CheckPointModel.Services;
using CheckPointCommon.Enums;

namespace CheckPointModel.Models
{
    public class CreateCourseModel : ICreateCourseModel
    {
        private IFactory _factory;
        private ISessionService _sessionService;
        //private IHandleCourses _courseHandler;

        private JobServiceBase _job;

        public CreateCourseModel(IFactory factory, ISessionService sessionService/*, IHandleCourses courseHandler*/)
        {
            _factory = factory;
            _sessionService = sessionService;
            //_courseHandler = courseHandler;
        }

        public void PrepareCreateCourseJob()
        {
            _job = _factory.CreateCourseJobType(DbAction.CreateCourse) as JobServiceBase;
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

        public void SaveCourseNameToSession(string courseName)
        {

            _sessionService.SessionCourseName = courseName;

        }

        public void GetJobItemNameFromSession()
        {

            _job.ItemName = _sessionService.SessionCourseName;

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

            _job = _factory.CreateCourseJobType((DbAction)_sessionService.JobType) as JobServiceBase;

            _job.CourseId = _sessionService.SessionCourseId;
            _job.ItemName = _sessionService.SessionCourseName;

            return _job;

        }

        public void PerformJob(object course)
        {

            _job = GetJobTypeFromSession() as JobServiceBase;

            _job.PerformTask(course);

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

        public object ConvertToCourse(object courseDTO)
        {
            return CourseDTOMapper.ConvertCourseDTOToCourse(courseDTO as CourseDTO);
        }
    }
}
