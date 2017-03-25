using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ServiceInterfaces;
using CheckPointCommon.RepositoryInterfaces;
using CheckPointCommon.CacheInterfaces;
using CheckPointDataTables.Tables;

namespace CheckPointModel.Services
{
    public class ShowCourses : IShowCourses
    {
        private IUnitOfWork _uOW;
        private ICacheData _cache;

        public const string key = "courseKey";
        public string client;

        private List<COURSE> emptyList = new List<COURSE>();

        public ShowCourses(IUnitOfWork unitOfWork, ICacheData cache)
        {
            _uOW = unitOfWork;
            _cache = cache;
        }
        public IEnumerable<T> GetCoursesCached<T>()
        {
            if (CoursesCache != null)
            {
                return CoursesCache as IEnumerable<T>;
            }
            else
            {
                return GetAllCoursesFor<T>(client);
            }
        }
        public List<COURSE> CoursesCache
        {
            get { return _cache.FetchCollection<COURSE>(key).ToList(); }
        }

        public IEnumerable<T> GetAllCoursesFor<T>(string client)
        {
            _cache.Add(key, _uOW.COURSEs.GetAllCoursesFor(client));

            var courses = CoursesCache;

            return courses as IEnumerable<T>;
        }

        public IEnumerable<T> GetEmptyList<T>()
        {
            return emptyList as IEnumerable<T>;
        }

        public IEnumerable<T> GetCoursesSortedByPropertyAscending<T>(string property)
        {
            var courses = GetCoursesCached<T>();


            var coursesSorted = courses.OrderBy(course => typeof(COURSE)
                                                .GetProperty(property)
                                                .GetValue(course))
                                                .ToList();

            return coursesSorted as IEnumerable<T>;

        }
        public IEnumerable<T> GetCoursesSortedByPropertyDescending<T>(string property)
        {
            var courses = GetCoursesCached<T>();

            var coursesSorted = courses.OrderByDescending(course => typeof(COURSE)
                                                              .GetProperty(property)
                                                              .GetValue(course))
                                                              .ToList();

            return coursesSorted as IEnumerable<T>;
        }

        public object GetSelectedCourseByCourseId(int courseId)
        {
            var courses = GetCoursesCached<COURSE>() as List<COURSE>;

            return courses.FirstOrDefault(course => course.CourseId.Equals(courseId));
        }
    }
}
