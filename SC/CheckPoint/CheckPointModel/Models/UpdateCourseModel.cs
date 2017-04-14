using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ServiceInterfaces;
using CheckPointCommon.FactoryInterfaces;
using CheckPointModel.Services;
using CheckPointCommon.Enums;
using CheckPointModel.DTOs;
using CheckPointModel.Utilities;
using CheckPointDataTables.Tables;

namespace CheckPointModel.Models
{
    public class UpdateCourseModel : IUpdateCourseModel
    {
        private IShowCourses _courseDisplayService;
        private ISessionService _sessionService;
        private IFactory _factory;

        private JobServiceBase _job;

        public UpdateCourseModel(IShowCourses courseDisplayService, ISessionService sessionService, IFactory factory)
        {

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

        private int? GetSessionCourseId()
        {

            return _sessionService.SessionCourseId;

        }

        public void SetInitialSessionJobState()
        {

            SaveJobTypeToSession();
            GetCourseIdFromSession();

        }

        public void PrepareUpdateCourseJob()
        {

            _job = _factory.CreateCourseJobType(DbAction.UpdateCourse) as JobServiceBase;

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
