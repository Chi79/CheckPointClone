using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointDataTables.Tables;
using CheckPointCommon.RepositoryInterfaces;

namespace DataAccess.Concrete.Repositories
{
    public class AttendeeRepository : Repository<ATTENDEE>, IAttendeeRepository
    {
        public AttendeeRepository(CheckPointContext context):base(context)  // calls our base constructor Repository<User>
        {
           
        }

        public IEnumerable<ATTENDEE> GetAllAttendeesAppliedForAppointment(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ATTENDEE> GetAllAttendeesAppliedForCourse()
        {
            throw new NotImplementedException();
        }
    }
}
