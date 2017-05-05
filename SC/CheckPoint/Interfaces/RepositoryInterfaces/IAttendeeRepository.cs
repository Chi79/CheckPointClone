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
        IEnumerable<ATTENDEE> GetAllAttendeesAppliedForCourses();
        IEnumerable<ATTENDEE> GetAllAttendeesAppliedForAppointments();



    }
}
