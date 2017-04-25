using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointDataTables.Tables;

namespace CheckPointCommon.RepositoryInterfaces
{
    public interface IAttendeeRepository : IRepository<ATTENDEE>
    {
        IEnumerable<ATTENDEE> GetAllAttendeesAppliedForAppointment(int appointmentId);

        IEnumerable<ATTENDEE> GetAllAttendeesAppliedForCourse();

        
    }
}
