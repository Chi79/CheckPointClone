using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
    public interface IUpdateCourseModel
    {

        object GetSelectedCourseByCourseId();

        string GetLoggedInClient();

        void PrepareUpdateCourseJob();

        void SetInitialSessionJobState();

        string GetJobConfirmationMessage();

        object ConvertToCourse(object _dTO);

        void PerformJob(object course);

        bool UpdateDatabaseWithChanges();

        string GetJobCompletedMessage();

        string GetUpdateErrorMessage();


        void RefreshCourseCache();


    }
}
