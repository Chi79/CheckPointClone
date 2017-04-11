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
    public class ShowAppointments : IShowAppointments
    {

        private IUnitOfWork _uOW;
        private ICacheData _cache;

        public const string appointmentsKey = "appointmentKey";
        public const string appointmentsInCoursesKey = "appointmentInCoursesKey";
        public string client;
        public int? courseId;

        private List<APPOINTMENT> emptyList = new List<APPOINTMENT>();

        public ShowAppointments(IUnitOfWork unitOfWork, ICacheData cache)
        {

            _uOW = unitOfWork;
            _cache = cache;

        }
        public IEnumerable<T> GetAppointmentsCached<T>()
        {

            if(AppointmentsCache != null)
            {

                return AppointmentsCache as IEnumerable<T>;

            }
            else
            {

                return GetAllAppointmentsFor<T>(client);

            }
        }
        public IEnumerable<T> GetAppointmentsInCourseCached<T>()
        {

            if (AppointmentsInCourseCache != null)
            {

                return AppointmentsInCourseCache as IEnumerable<T>;

            }
            else
            {

                return GetAllAppointmentsForClientByCourseId<T>(courseId);

            }
        }
        public List<APPOINTMENT> AppointmentsCache
        {

            get { return _cache.FetchCollection<APPOINTMENT>(appointmentsKey).ToList(); }

        }

        public List<APPOINTMENT> AppointmentsInCourseCache
        {

            get { return _cache.FetchCollection<APPOINTMENT>(appointmentsInCoursesKey).ToList(); }

        }

        public IEnumerable<T> GetAllAppointmentsFor<T>(string client)
        {

            _cache.Add(appointmentsKey, _uOW.APPOINTMENTs.GetAllAppointmentsFor(client));

            var apps = AppointmentsCache;

            return apps as IEnumerable<T>;

        }

        public IEnumerable<T> GetAllAppointmentsForClientByCourseId<T>(int? courseId)
        {

            _cache.Add(appointmentsInCoursesKey, _uOW.APPOINTMENTs.GetAllAppointmentsByCourseId(courseId));

            var apps = AppointmentsInCourseCache;

            return apps as IEnumerable<T>;

        }

        public IEnumerable<T> GetEmptyList<T>()
        {

            return emptyList as IEnumerable<T>;

        }

        public IEnumerable<T> GetAppointmentsSortedByPropertyAscending<T>(string property)
        {

            var apps = GetAppointmentsCached<T>();


            var appsSorted = apps.OrderBy(a => typeof(APPOINTMENT)
                                                .GetProperty(property)
                                                .GetValue(a))
                                                .ToList();

            return appsSorted as IEnumerable<T>;

        }
        public IEnumerable<T> GetAppointmentsSortedByPropertyDescending<T>(string property)
        {

            var apps = GetAppointmentsCached<T>();

            var appsSorted = apps.OrderByDescending(a => typeof(APPOINTMENT)
                                                              .GetProperty(property)
                                                              .GetValue(a))
                                                              .ToList();

            return appsSorted as IEnumerable<T>;

        }

        public IEnumerable<T> GetAppointmentsInCourseSortedByPropertyAscending<T>(string property)
        {

            var apps = GetAppointmentsInCourseCached<T>();


            var appsSorted = apps.OrderBy(a => typeof(APPOINTMENT)
                                                .GetProperty(property)
                                                .GetValue(a))
                                                .ToList();

            return appsSorted as IEnumerable<T>;

        }
        public IEnumerable<T> GetAppointmentsInCourseSortedByPropertyDescending<T>(string property)
        {

            var apps = GetAppointmentsInCourseCached<T>();

            var appsSorted = apps.OrderByDescending(a => typeof(APPOINTMENT)
                                                              .GetProperty(property)
                                                              .GetValue(a))
                                                              .ToList();

            return appsSorted as IEnumerable<T>;

        }

        public object GetSelectedAppointmentByAppointmentId(int? AppointmentId)
        {

            var apps = GetAppointmentsCached<APPOINTMENT>() as List<APPOINTMENT>;

            return apps.FirstOrDefault(a => a.AppointmentId.Equals(AppointmentId));

        }
    }
}
