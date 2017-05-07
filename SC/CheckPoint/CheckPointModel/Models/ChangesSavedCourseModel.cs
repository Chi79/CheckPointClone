using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ServiceInterfaces;

namespace CheckPointModel.Models
{
    public class ChangesSavedCourseModel : IChangesSavedCourseModel
    {

        private readonly ISessionService _sessionService;

        public ChangesSavedCourseModel(ISessionService sessionService)
        {

            _sessionService = sessionService;

        }

        public void SetChangesSavedStatus()
        {

            _sessionService.SavedChangesStatus = true;

        }

    }
}
