using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
    public interface ICreateCourseModel
    {
        void PrepareCreateCourseJob();

        void SaveJobTypeToSession();

        void SaveCourseNameToSession(string courseName);

        void GetJobItemNameFromSession();

        string GetJobConfirmationMessage();

        bool? GetChangesSavedSessionStatus();


        string GetLoggedInClient();

        void PerformJob(object course);

        bool UpdateDatabaseWithChanges();

        string GetJobCompletedMessage();

        string GetUpdateErrorMessage();

        object ConvertToCourse(object entityModel);
    }
}
