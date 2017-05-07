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
    public class FindCoursesModel : IFindCoursesModel
    {
        private readonly ISessionService _sessionService;
        private readonly IShowCourses _displayService;

        public FindCoursesModel(ISessionService sessionService, IShowCourses displayService)
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

        public int? GetSessionAppointmentId()
        {

            return _sessionService.SessionAppointmentId;
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

        public IEnumerable<object> GetAllPublicCourses()
        {

            return _displayService.GetAllPublicCourses<COURSE>();

        }

        public IEnumerable<object> GetEmptyList()
        {

            return _displayService.GetEmptyList<COURSE>();

        }
        public IEnumerable<object> GetPublicCachedCourses()
        {

            return _displayService.GetPublicCoursesCached<COURSE>();

        }
        public IEnumerable<object> GetPublicCoursesSortedByPropertyAsc()
        {

            return _displayService.GetPublicCoursesSortedByPropertyAscending<object>(GetColumnName());

        }
        public IEnumerable<object> GetPublicCoursesSortedByPropertyDesc()
        {

            return _displayService.GetPublicCoursesSortedByPropertyDescending<object>(GetColumnName());

        }
    }
}
