using CheckPoint.Repository.ConcreteRepositories;
using CheckPoint.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Repository.RepositoryInterfaces
{
    public interface IAttendeeRepository : IRepository<ATTENDEE>
    {
        IEnumerable<ATTENDEE> GetAllAttendees();

        IEnumerable<ATTENDEE> GetAllAttendeesForAppointment(int id);

        ATTENDEE GetSingleAttendee(string tagId);

        ATTENDEE GetSingleAttendeeForAppointment(int appointmentId, string tagId);

        RepositoryActionResult<ATTENDEE> UpdateAttendee(ATTENDEE attendee);

        RepositoryActionResult<ATTENDEE> DeleteAttendee(string tagId);
    }
}
