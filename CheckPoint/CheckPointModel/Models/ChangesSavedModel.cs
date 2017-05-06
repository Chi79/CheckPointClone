using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ServiceInterfaces;

namespace CheckPointModel.Models
{
    public class ChangesSavedModel : IChangesSavedModel
    {

        private readonly ISessionService _sessionService;

        public ChangesSavedModel(ISessionService sessionService)
        {

            _sessionService = sessionService;

        }

        public void SetChangesSavedStatus()
        {

            _sessionService.SavedChangesStatus = true;

        }

    }
}
