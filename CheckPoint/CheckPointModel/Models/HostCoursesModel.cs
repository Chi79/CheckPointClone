using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ServiceInterfaces;
using CheckPointDataTables.Tables;

namespace CheckPointModel.Models
{
    public class HostCoursesModel : IHostCoursesModel
    {
        private ISessionService _sessionService;
        private IShowCourses _displayService;

        public HostCoursesModel(ISessionService sessionService, IShowCourses displayService)
        {

            _sessionService = sessionService;
            _displayService = displayService;

        }

        public string GetLoggedInClient()
        {

           return _sessionService.LoggedInClient;

        }

        public string GetColumnName()
        {

            return _sessionService.ColumnName;

        }

        public int? GetSessionRowIndex()
        {

            return _sessionService.SessionRowIndex;

        }

        public void SetSessionRowIndex(int index)
        {

            _sessionService.SessionRowIndex = index;

        }

        public void SetSessionCourseId(int id)
        {

            _sessionService.SessionCourseId = id;

        }

        public int? GetSessionCourseId()
        {

            return _sessionService.SessionCourseId;

        }

        public void ResetNewAppointmentAddedToCourseStatus()
        {

            _sessionService.NewAppointmentAddedToCourseStatus = false;
        
        }

        public void ResetSessionState()
        {

            int noRowSelected = -1;
            int noCourseSelected = -1;
            SetSessionRowIndex(noRowSelected);
            SetSessionCourseId(noCourseSelected);

        }

        public IEnumerable<object> GetAllCoursesForClient()
        {

            return _displayService.GetAllCoursesFor<COURSE>(GetLoggedInClient());

        }

        public IEnumerable<object> GetEmptyList()
        {

            return _displayService.GetEmptyList<COURSE>();

        }
        public IEnumerable<object> GetCachedCourses()
        {

            return _displayService.GetCoursesCached<COURSE>();

        }
        public IEnumerable<object> GetCoursesSortedByPropertyAsc()
        {

            return _displayService.GetCoursesSortedByPropertyAscending<object>(GetColumnName());

        }
        public IEnumerable<object> GetCoursesSortedByPropertyDesc()
        {

            return _displayService.GetCoursesSortedByPropertyDescending<object>(GetColumnName());

        }
    }
}
