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

        public AddSelectedAppointmentToCourseModel(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public int GetSessionAppointmentId()
        {

            return (int)_sessionService.SessionAppointmentId;

        }
    }
}
