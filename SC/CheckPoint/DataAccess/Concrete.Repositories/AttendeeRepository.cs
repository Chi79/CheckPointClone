using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointDataTables.Tables;
using CheckPointCommon.RepositoryInterfaces;
using CheckPointCommon.Enums;

namespace DataAccess.Concrete.Repositories
{
    public class AttendeeRepository : Repository<ATTENDEE>, IAttendeeRepository
    {
        public AttendeeRepository(CheckPointContext context):base(context)  // calls our base constructor Repository<User>
        {
           
        }

        public CheckPointContext CheckPointContext  // casting our context class as an entity DbContext 
        {
            get { return Context as CheckPointContext; }
        }

        public IEnumerable<ATTENDEE> GetAllAttendeesAppliedForAppointment(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ATTENDEE> GetAllAttendeesAppliedForCourse()
        {
            return CheckPointContext.ATTENDEEs.Where(a => a.CourseId != null && a.StatusId == (int)AttendeeStatus.RequestedToAttend).ToList();
        }
    }
}
