using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ServiceInterfaces;

namespace CheckPointModel.Models
{
    public class AddSelectedAppointmentToCourseModel : IAddSelectedAppointmentToCourseModel
    {
        private ISessionService _sessionService;
        private IShowAppointments _displayService;

        public AddSelectedAppointmentToCourseModel(ISessionService sessionService, IShowAppointments displayService)
        {

            _sessionService = sessionService;
            _displayService = displayService;

        }

        public int GetSessionAppointmentId()
        {

            return (int)_sessionService.SessionAppointmentId;

        }
        public void SetSessionCourseId(int id)
        {

            _sessionService.SessionCourseId = id;

        }

        public object GetSelectedAppointmentById()
        {

            return _displayService.GetSelectedAppointmentByAppointmentId(_sessionService.SessionAppointmentId);

        }
    }
}
