using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.RepositoryInterfaces;
using CheckPointCommon.ServiceInterfaces;
using CheckPointDataTables.Tables;

namespace CheckPointModel.Models
{
    public class UserCoursesModel : IUserCoursesModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISessionService _sessionService;
        private IShowCourses _courseDisplayService;

        public UserCoursesModel(IUnitOfWork unitOfWork, ISessionService sessionService, IShowCourses courseDisplayService)
        {
            _unitOfWork = unitOfWork;
            _sessionService = sessionService;
            _courseDisplayService = courseDisplayService;
        }
        public IEnumerable<object> GetEmptyCourseList()
        {
            return _courseDisplayService.GetEmptyList<COURSE>();
        }

        public string GetLoggedInClient()
        {
            return _sessionService.LoggedInClient;
        }

        public int? GetSessionRowIndex()
        {
            return _sessionService.SessionRowIndex;
        }

        public void ResetSessionState()
        {
            int noRowSelected = -1;
            int noCourseSelected = -1;
            SetSessionRowIndex(noRowSelected);
            SetSessionCourseId(noCourseSelected);
        }

        public void SetSessionCourseId(int id)
        {
            _sessionService.SessionCourseId = id;
        }

        public int GetSessionCourseId()
        {
            return (int)_sessionService.SessionCourseId;
        }

        public void SetSessionRowIndex(int index)
        {
            _sessionService.SessionRowIndex = index;
        }

        public IEnumerable<object> GetAllCoursesClientIsApprovedToAttend()
        {

            var clientUsername = GetLoggedInClient();

            var allCoursesApproved = _unitOfWork.COURSEs.GetAllCoursesClientIsApprovedToAttend(clientUsername);

            if (allCoursesApproved != null)
            {

                return allCoursesApproved;

            }
            else
            {

                return _courseDisplayService.GetEmptyList<COURSE>();

            }

        }
    }

}
