using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ServiceInterfaces;
using CheckPointCommon.FactoryInterfaces;
using CheckPointCommon.Enums;
using CheckPointModel.Services;
using CheckPointCommon.Structs;

namespace CheckPointModel.Models
{
    public class CourseSelectorModel : ICourseSelectorModel
    {
        private readonly IShowAppointments _appointmentDisplayService;
        private readonly IShowCourses _courseDisplayService;
        private readonly ISessionService _sessionService;
        private readonly IFactory _factory;

        public CourseSelectorModel(IShowAppointments appointmentDisplayService, IShowCourses courseDisplayService,
                                   ISessionService sessionService, IFactory factory)
        {
            _appointmentDisplayService = appointmentDisplayService;
            _courseDisplayService = courseDisplayService;
            _sessionService = sessionService;
            _factory = factory;
        }

        public object GetSelectedAppointment()
        {
            return _appointmentDisplayService.GetSelectedAppointmentByAppointmentId(_sessionService.SessionAppointmentId);

        }

        public int? GetSessionCourseId()
        {
           return _sessionService.SessionCourseId;
        }

        public void AddSelectedAppointmentToCourse(object appointment)
        {
            var job =_factory.CreateAppointmentJobType(DbAction.AddExistingAppointmentToCourse) as JobServiceBase;
            job.AppointmentId = (int)_sessionService.SessionAppointmentId;
            job.CourseId = _sessionService.SessionCourseId;
            job.PerformTask(appointment);
            job.SaveChanges();

        }

    }
}
