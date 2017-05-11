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

        public IEnumerable<ATTENDEE> GetAllAttendedAttendeesForClient(string tagId)
        {
            return CheckPointContext.ATTENDEEs.Where(a => a.TagId == tagId && (a.StatusId == (int)AttendeeStatus.HasAttended || a.StatusId == (int)AttendeeStatus.ObligHasAttended)).ToList();
                                                                                                
        }

        public IEnumerable<ATTENDEE> GetAllAcceptedAttendeeRequestsForClient(string userName)
        {

            return CheckPointContext.ATTENDEEs.Where(a => a.CLIENT_TAG.UserName == userName && a.StatusId == (int)AttendeeStatus.RequestApproved).ToList();
        }

        public CheckPointContext CheckPointContext  // casting our context class as an entity DbContext 
        {
            get { return Context as CheckPointContext; }
        }

        public object GetAttendeeByUserNameAndAppointmentId(string username, int id)
        {
            return CheckPointContext.ATTENDEEs.FirstOrDefault(a => a.CLIENT_TAG.UserName == username && a.AppointmentId == id);
           
        }

        public IEnumerable<object> GetAttendeesByTagIdAndAppointmentId(string tagId, int id)
        {
            return CheckPointContext.ATTENDEEs.Where(a => a.TagId == tagId && a.AppointmentId == id).ToList();
        }

        public object GetAttendeeByTagIdAndAppointmentId(string tagId, int id)
        {
            return CheckPointContext.ATTENDEEs.Where(a => a.TagId == tagId && a.AppointmentId == id);
        }

        public object GetAttendeeByUserNameAndCourseId(string username, int id)
        {
            return CheckPointContext.ATTENDEEs.FirstOrDefault(a => a.CLIENT_TAG.UserName == username && a.CourseId == id);
            
        }

        public IEnumerable<object> GetAllAttendeesAcceptedForAppointments()
        {
            return CheckPointContext.ATTENDEEs.Where(a => a.StatusId == (int)AttendeeStatus.RequestApproved).ToList();
        }

        public object GetAttendeeByUserName(string username)
        {
            return CheckPointContext.ATTENDEEs.FirstOrDefault(a => a.CLIENT_TAG.UserName == username);
        }

        public IEnumerable<object> GetAllAttendeesByUserName(string username)
        {
            return CheckPointContext.ATTENDEEs.Where(a => a.CLIENT_TAG.UserName == username).ToList();
        }

        public IEnumerable<object> GetAcceptedAttendeesByUserName(string username)
        {
            return CheckPointContext.ATTENDEEs.Where(a => a.CLIENT_TAG.UserName == username && a.StatusId == (int)AttendeeStatus.RequestApproved).ToList();
        }


        public IEnumerable<ATTENDEE> GetAllAttendeesAppliedForAppointmentById(int appointmentId)
        {
            return CheckPointContext.ATTENDEEs.Where(a => a.AppointmentId == appointmentId &&
                                                a.StatusId == (int)AttendeeStatus.RequestedToAttend).ToList();
        }

        public IEnumerable<ATTENDEE> GetAllAttendeesAppliedForCourseById(int courseId)
        {
            return CheckPointContext.ATTENDEEs.Where(a => a.CourseId == courseId &&
                                                a.StatusId == (int)AttendeeStatus.RequestedToAttend).ToList();
        }

        public IEnumerable<ATTENDEE> GetAllAttendeesAppliedForCourses()
        {
            return CheckPointContext.ATTENDEEs.Where(a => a.CourseId != null && 
                                                a.StatusId == (int)AttendeeStatus.RequestedToAttend).Distinct().ToList();
        }

        public IEnumerable<ATTENDEE> GetAllAttendeesAppliedForAppointments()
        {
            return CheckPointContext.ATTENDEEs.Where(a => a.CourseId == null &&
                                        a.StatusId == (int)AttendeeStatus.RequestedToAttend).Distinct().ToList();
        }

        public void AddRange(IEnumerable<ATTENDEE> attendees)
        {

            CheckPointContext.ATTENDEEs.AddRange(attendees);
                            
        }

        public bool CheckIfAttendeeExists(ATTENDEE attendee)
        {
            bool attendeeExists = CheckPointContext.ATTENDEEs.Where(a => a.AppointmentId == attendee.AppointmentId &&
                                                                    a.TagId == attendee.TagId).Any();

            return attendeeExists;
        }
    }
}
