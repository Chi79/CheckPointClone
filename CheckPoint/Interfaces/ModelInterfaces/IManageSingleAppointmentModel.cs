using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
    public interface IManageSingleAppointmentModel
    {

        object ConvertToAppointment(object entityModel);

        void PrepareUpdateAppointmentJob();

        void PrepareDeleteAppointmentJob();

        void PrepareAddExistingAppointmentToCourseJob();

        string GetJobConfirmationMessage();

        object GetJobTypeFromSession();

        void SetInitialSessionJobState();

        void PerformJob(object appointment);

        bool UpdateDatabaseWithChanges();

        string GetUpdateErrorMessage();

        string GetJobCompletedMessage();

        int GetSessionAppointmentId();

        bool? GetAddingAppointmentToCourseStatus();

        void ResetAddingAppointmentToCourseStatus();

        string GetLoggedInClient();

        void RefreshAllAppointmentsForClient();

        object GetAppointmentForClientByAppointmentId();
    }
}
