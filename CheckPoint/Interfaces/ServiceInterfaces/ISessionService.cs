using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ServiceInterfaces
{
    public interface ISessionService
    {
        string LoggedInClient { get; set; }
        string ClientTagId { get; set; }
        bool? SavedChangesStatus { get; set; }
        bool? NewAppointmentAddedToCourseStatus { get; set; }
        bool? AppointmentDeletedFromCourseStatus { get; set; }
        bool? UpdatedCourseStatus { get; set; }
        bool? DeletedCourseStatus { get; set; }
        int? SessionAppointmentId { get; set; }
        int? SessionRowIndex { get; set; }
        string ColumnName { get; set; }
        int? SessionCourseId { get; set; }
        int? JobType { get; set; }
        string SessionAppointmentName { get; set; }
        string SessionCourseName { get; set; }
        bool? NavigationIsValid { get; set; }
        string SessionAttendeeUsername { get; set; }
        bool? AppliedToCourseStatus { get; set; }
    }
}
