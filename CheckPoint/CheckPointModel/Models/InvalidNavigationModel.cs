using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ServiceInterfaces;

namespace CheckPointModel.Models
{
    public class InvalidNavigationModel : IInvalidNavigationModel
    {
        private ISessionService _sessionService;

        public InvalidNavigationModel(ISessionService sessionService)
        {

            _sessionService = sessionService;

        }

        public bool GetCourseDeletedStatus()
        {

            return (bool)_sessionService.DeletedCourseStatus;

        }

        public void  SetSessionCourseNoRowSelected()
        {

            _sessionService.SessionCourseId = -1;

        }

    }
}
