using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.RepositoryInterfaces;
using CheckPointDataTables.Tables;
using CheckPointCommon.Enums;

namespace DataAccess.Concrete.Repositories
{
    public class CourseRepository : Repository<COURSE> , ICourseRepository
    {
        public CourseRepository(CheckPointContext context):base(context)  // calls our base constructor Repository<User>
        {
            //TODO
        }
        public CheckPointContext CheckPointContext  // casting our context class as an entity DbContext 
        {
            get { return Context as CheckPointContext; }
        }

        public IEnumerable<COURSE> GetAllCoursesFor(string userName)
        {
            return CheckPointContext.COURSEs.Where(course => course.UserName == userName).ToList();
        }

        public IEnumerable<COURSE> GetAllPublicCourses()
        {
            return CheckPointContext.COURSEs.Where(course => course.IsPrivate == false).ToList();
        }

        public COURSE GetCourseByCourseName(string courseName)
        {
            return CheckPointContext.COURSEs.FirstOrDefault(course => course.Name == courseName);
        }
        public COURSE GetCourseByCourseId(int courseId)
        {
            return CheckPointContext.COURSEs.FirstOrDefault(course => course.CourseId == courseId);
        }

        public IEnumerable<COURSE> GetAllCoursesClientIsApprovedToAttend(string userName)
        {

            var allCoursesClientIsApprovedToAttend = new List<COURSE>();

            var allAcceptedAttendeeRequestsForClient = GetAllAcceptedAttendeeRequestsForClient(userName);

            foreach (var acceptedAttendanceRequest in allAcceptedAttendeeRequestsForClient)
            {

                int courseId = (int)acceptedAttendanceRequest.CourseId;

                var approvedCourse = GetCourseByCourseId(courseId);

                allCoursesClientIsApprovedToAttend.Add(approvedCourse);

            }

            return allCoursesClientIsApprovedToAttend;

        }

        public IEnumerable<ATTENDEE> GetAllAcceptedAttendeeRequestsForClient(string userName)
        {

            return CheckPointContext.ATTENDEEs.Where(a => a.CLIENT_TAG.UserName == userName && a.StatusId == (int)AttendeeStatus.RequestApproved).ToList();

        }

    }
}
