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
        bool? AddingAppointmentToCourseStatus { get; set; }
        int? SessionAppointmentId { get; set; }
        int? SessionRowIndex { get; set; }
        string ColumnName { get; set; }
        int? SessionCourseId { get; set; }
        int? JobState { get; set; }
    }
}
