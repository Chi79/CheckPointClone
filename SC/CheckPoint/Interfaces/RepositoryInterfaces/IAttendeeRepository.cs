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
        IEnumerable<ATTENDEE> GetAllAttendeesWhoAttendedAppointmentById(int appointmentId);

        IEnumerable<ATTENDEE> GetAllAttendeesAppliedForAppointmentById(int appointmentId);

        IEnumerable<ATTENDEE> GetAllAttendeesAppliedForCourseById(int courseId);

        IEnumerable<ATTENDEE> GetAllAttendedAttendeesForClient(string username);

        IEnumerable<ATTENDEE> GetAllAcceptedAttendeeRequestsForClient(string userName);

        IEnumerable<ATTENDEE> GetAllAttendeesAppliedForCourses();

        IEnumerable<ATTENDEE> GetAllAttendeesAppliedForAppointments();

        IEnumerable<object> GetAllAttendeesByUserName(string username);

        IEnumerable<object> GetAllAttendeesAcceptedForAppointments();

        IEnumerable<object> GetAcceptedAttendeesByUserName(string userName);

        IEnumerable<object> GetAttendeesByTagIdAndAppointmentId(string tagId, int id);

        object GetAttendeeByTagIdAndAppointmentId(string tagId, int id);

        object GetAttendeeByUserNameAndAppointmentId(string username, int id);

        object GetAttendeeByUserNameAndCourseId(string username, int id);

        object GetAttendeeByUserName(string username);

        void AddRange(IEnumerable<ATTENDEE> attendees);

        bool CheckIfAttendeeExists(ATTENDEE attendee);
    }
}
