using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ModelInterfaces
{
    public interface IApplyToAttendAppointmentModel
    {
        void CreateAttendee();
        string GetLoggedInClientTagId();
        void PerformJob();
        bool UpdateDatabaseWithChanges();
        string GetJobCompletedMessage();
        string GetUpdateErrorMessage();

        object GetPublicAppointmentByAppointmentId();

    }
}
