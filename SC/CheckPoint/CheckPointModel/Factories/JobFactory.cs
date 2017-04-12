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


        private Dictionary<DbAction, JobServiceBase> Jobs;


        public JobFactory(IHandleAppointments appointmentsHandler, IHandleCourses coursesHandler)
        {
            _appointmentsHandler = appointmentsHandler;
            _coursesHandler = coursesHandler;
        }

        public void LoadAppointmentDictionary(IHandleAppointments handler)
        {
            if (Jobs == null)
            {
                Jobs = new Dictionary<DbAction, JobServiceBase>();

                Jobs.Add(DbAction.CreateAppointment, new CreateAppointmentJob(handler));
                Jobs.Add(DbAction.DeleteAppointment, new DeleteAppointmentJob(handler));
                Jobs.Add(DbAction.UpdateAppointment, new UpdateAppointmentJob(handler));
                Jobs.Add(DbAction.AddNewAppointmentToCourse, new AddAppointmentToCourseJob(handler));
                Jobs.Add(DbAction.ChangeAppointmentCourseId, new ChangeAppointmentCourseIdJob(handler));
            }
        }

        public void LoadCourseDictionary(IHandleCourses handler)
        {
            if (Jobs == null)
            {
                Jobs = new Dictionary<DbAction, JobServiceBase>();

                Jobs.Add(DbAction.CreateCourse, new CreateCourseJob(handler));
                Jobs.Add(DbAction.DeleteCourse, new DeleteCourseJob(handler));
                Jobs.Add(DbAction.UpdateCourse, new UpdateCourseJob(handler));
            }
        }

        public object CreateAppointmentJobType(object action)
        {
            LoadAppointmentDictionary(_appointmentsHandler);
            return Jobs[(DbAction)action] as JobServiceBase;
        }

        public object CreateCourseJobType(object action)
        {
            LoadCourseDictionary(_coursesHandler);
            return Jobs[(DbAction)action] as JobServiceBase;
        }
    }
}
