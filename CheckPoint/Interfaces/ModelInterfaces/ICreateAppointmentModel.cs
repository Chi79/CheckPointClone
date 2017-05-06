using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
    public interface ICreateAppointmentModel
    {

        void PrepareAddNewAppointmentToCourseJob();

        void PrepareCreateNewAppointmentJob();

        void SaveJobTypeToSession();

        void SaveAppointmentNameToSession(string appointmentName);

        bool? GetAddingAppointmentToCourseStatus();

        object ConvertToAppointment(object entityModel);

        void GetJobItemNameFromSession();

        bool? GetChangesSavedSessionStatus();

        string GetJobConfirmationMessage();

        string GetLoggedInClient();

        object GetJobTypeFromSession();

        void PerformJob(object appointment);

        bool UpdateDatabaseWithChanges();

        string GetUpdateErrorMessage();

        string GetJobCompletedMessage();

        void ResetAddingAppointmentToCourseStatus();

    }
}
