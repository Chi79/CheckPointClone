using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointModel.Services;
using CheckPointCommon.Enums;
using CheckPointCommon.ServiceInterfaces;
using CheckPointCommon.FactoryInterfaces;

namespace CheckPointModel.Factories
{

    public class JobFactory : IFactory
    {

        private IHandleAppointments _appointmentsHandler;
        private IHandleCourses _coursesHandler;


        private Dictionary<DbAction, JobServiceBase> AppointmentJobs;
        private Dictionary<DbAction, JobServiceBase> CourseJobs;


        public JobFactory(IHandleAppointments appointmentsHandler, IHandleCourses coursesHandler)
        {
            _appointmentsHandler = appointmentsHandler;
            _coursesHandler = coursesHandler;
        }

        public void LoadAppointmentDictionary(IHandleAppointments handler)
        {
            if (AppointmentJobs == null)
            {
                AppointmentJobs = new Dictionary<DbAction, JobServiceBase>();

                AppointmentJobs.Add(DbAction.CreateAppointment, new CreateAppointmentJob(handler));
                AppointmentJobs.Add(DbAction.DeleteAppointment, new DeleteAppointmentJob(handler));
                AppointmentJobs.Add(DbAction.UpdateAppointment, new UpdateAppointmentJob(handler));
                AppointmentJobs.Add(DbAction.AddNewAppointmentToCourse, new AddAppointmentToCourseJob(handler));
                AppointmentJobs.Add(DbAction.ChangeAppointmentCourseId, new ChangeAppointmentCourseIdJob(handler));
            }
        }

        public void LoadCourseDictionary(IHandleCourses handler)
        {
            if (CourseJobs == null)
            {
                CourseJobs = new Dictionary<DbAction, JobServiceBase>();

                CourseJobs.Add(DbAction.CreateCourse, new CreateCourseJob(handler));
                CourseJobs.Add(DbAction.DeleteCourse, new DeleteCourseJob(handler));
                CourseJobs.Add(DbAction.UpdateCourse, new UpdateCourseJob(handler));
            }
        }

        public object CreateAppointmentJobType(object action)
        {
            LoadAppointmentDictionary(_appointmentsHandler);
            return AppointmentJobs[(DbAction)action] as JobServiceBase;
        }

        public object CreateCourseJobType(object action)
        {
            LoadCourseDictionary(_coursesHandler);
            return CourseJobs[(DbAction)action] as JobServiceBase;
        }
    }
}
