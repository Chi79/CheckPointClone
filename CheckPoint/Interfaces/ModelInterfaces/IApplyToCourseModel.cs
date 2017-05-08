using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
    public interface IApplyToCourseModel
    {
         IEnumerable<object> GetAppointmentsInCourse();

     
        IEnumerable<object> GetSelectedCourse();

        IEnumerable<object> GetEmptyCourseList();
        IEnumerable<object> GetEmptyAppointmentList();
       
        IEnumerable<object> GetAppointmentsInCourseSortedByPropertyAsc();
        IEnumerable<object> GetAppointmentsInCourseSortedByPropertyDesc();
    
        void PerformJob();
        bool UpdateDatabaseWithChanges();
        string GetJobConfirmationMessage();
        string GetJobCompletedMessage();
        string GetUpdateErrorMessage();
        void PrepareCreateMultipleAttendeesJob();
        bool AppointmentsInCourse();

    }
}
