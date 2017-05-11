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

        IEnumerable<ATTENDEE> GetAllAttendeesAppliedForAppointmentById(int appointmentId);

        IEnumerable<ATTENDEE> GetAllAttendeesAppliedForCourseById(int courseId);

        object GetAttendeeByUserNameAndAppointmentId(string username, int id);

        object GetAttendeeByUserNameAndCourseId(string username, int id);
        IEnumerable<ATTENDEE> GetAllAttendedAttendeesForClient(string username);
        IEnumerable<ATTENDEE> GetAllAcceptedAttendeeRequestsForClient(string userName);

        object GetAttendeeByUserName(string username);
        IEnumerable<object> GetAttendeeByTagIdAndAppointmentId(string tagId, int id);

        IEnumerable<ATTENDEE> GetAllAttendeesAppliedForCourses();

        IEnumerable<ATTENDEE> GetAllAttendeesAppliedForAppointments();

        IEnumerable<object> GetAllAttendeesAcceptedForAppointments();

        IEnumerable<object> GetAcceptedAttendeesByUserName(string userName);

        void AddRange(IEnumerable<ATTENDEE> attendees);

        bool CheckIfAttendeeExists(ATTENDEE attendee);

        IEnumerable<object> GetAllAttendeesByUserName(string username);

    }
}
