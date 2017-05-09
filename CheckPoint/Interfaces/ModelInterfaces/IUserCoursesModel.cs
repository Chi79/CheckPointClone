using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
    public interface IUserCoursesModel
    {
        IEnumerable<object> GetEmptyCourseList();
        int? GetSessionRowIndex();
        void SetSessionRowIndex(int index);
        void ResetSessionState();
        void SetSessionCourseId(int id);
        int GetSessionCourseId();
        string GetLoggedInClient();
        IEnumerable<object> GetAllCoursesClientIsApprovedToAttend();


    }
}
