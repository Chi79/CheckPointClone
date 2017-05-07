using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ServiceInterfaces;
using CheckPointCommon.RepositoryInterfaces;
using CheckPointDataTables.Tables;

namespace CheckPointModel.Services
{
    public class CourseHandler : IHandleCourses
    {
        private readonly IUnitOfWork _uOW;

        private IEnumerable<COURSE> _courses;
        private COURSE _course;

        public CourseHandler(IUnitOfWork unitOfWork)
        {
            _uOW = unitOfWork;
        }

        public IEnumerable<COURSE> GetAllCoursesForClient<COURSE>(string client)
        {
            _courses = _uOW.COURSEs.GetAllCoursesFor(client);
            return _courses as IEnumerable<COURSE>;
        }

        public IEnumerable<string> GetAllCourseNamesForClient(string client)
        {
            GetAllCoursesForClient<COURSE>(client);
            var allCourseNames = _courses.Select(course => course.Name);
            return allCourseNames;
        }

        public object GetCourseToDisplay()
        {
            _course = _courses.FirstOrDefault();
            return _course;
        }

        public object GetCourseByName(string courseName)
        {
            _course = _uOW.COURSEs.GetCourseByCourseName(courseName);
            return _course;
        }

        public object GetCourseById(int courseId)
        {
            _course = _uOW.COURSEs.GetCourseByCourseId(courseId);
            return _course;
        }


        public void Delete<T>(T course)
        {
            _uOW.COURSEs.Remove(course as COURSE);
        }


        public void Create<T>(T course)
        {

            _uOW.COURSEs.Add(course as COURSE);
        }

        public object SaveChanges()
        {
            return _uOW.Complete();
        }
    }
}
