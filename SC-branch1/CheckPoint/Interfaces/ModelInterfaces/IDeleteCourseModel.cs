using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
    public interface IDeleteCourseModel
    {

        object GetSelectedCourseByCourseId();

        string GetLoggedInClient();

        void PrepareDeleteCourseJob();

        void SetInitialSessionJobState();

        bool GetChangesSavedSessionStatus();

        bool GetDeleteCourseStatus();

        void SetDeleteCourseStatus();

        string GetJobConfirmationMessage();

        object ConvertToCourse(object _dTO);

        void PerformJob(object course);

        bool UpdateDatabaseWithChanges();

        string GetJobCompletedMessage();

        string GetUpdateErrorMessage();


        void RefreshCourseCache();

    }
}
