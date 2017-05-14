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
        public const string publicAppointmentsKey = "publicAppointmentsKey";
        public const string acceptedAppointmentsKey = "acceptedAppointmentsKey";
        public const string expiredAppointmentsKey = "expiredAppointmentsKey";

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

        public IEnumerable<T> GetPublicAppointmentsCached<T>()
        {

            if (PublicAppointmentsCache != null)
            {

                return PublicAppointmentsCache as IEnumerable<T>;

            }
            else
            {

                return GetAllPublicAppointments<T>();

            }
        }

        public IEnumerable<T> GetAcceptedAppointmentsCached<T>()
        {

            if (AcceptedAppointmentsCache != null)
            {

                return AcceptedAppointmentsCache as IEnumerable<T>;

            }
            else
            {

                return GetAllAppointmentsClientIsApprovedToAttend<T>(client);

            }
        }

        public IEnumerable<T> GetExpiredAppointmentsCached<T>()
        {

            if (ExpiredAppointmentsCache != null)
            {

                return ExpiredAppointmentsCache as IEnumerable<T>;

            }
            else
            {

                return GetAllExpiredAppointmentsFor<T>(client);

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

        public List<APPOINTMENT> PublicAppointmentsCache
        {

            get { return _cache.FetchCollection<APPOINTMENT>(publicAppointmentsKey).ToList(); }

        }

        public List<APPOINTMENT> AcceptedAppointmentsCache
        {

            get { return _cache.FetchCollection<APPOINTMENT>(acceptedAppointmentsKey).ToList(); }

        }

        public List<APPOINTMENT> ExpiredAppointmentsCache
        {

            get { return _cache.FetchCollection<APPOINTMENT>(expiredAppointmentsKey).ToList(); }

        }

        public IEnumerable<T> GetAllAppointmentsFor<T>(string client)
        {

            _cache.Add(appointmentsKey, _uOW.APPOINTMENTs.GetAllAppointmentsFor(client));

            var apps = AppointmentsCache;

            return apps as IEnumerable<T>;

        }

        public IEnumerable<T> GetAllExpiredAppointmentsFor<T>(string client)
        {

            _cache.Add(appointmentsKey, _uOW.APPOINTMENTs.GetAllAppointmentsFor(client));

            var apps = AppointmentsCache;

            var expiredAppsList = apps.FindAll(a => a.Date < DateTime.Now || a.Date == DateTime.Now );

            _cache.Add(expiredAppointmentsKey, expiredAppsList);

            return expiredAppsList as IEnumerable<T>;

        }

        public IEnumerable<T> GetAllAppointmentsForClientByCourseId<T>(int? courseId)
        {

            _cache.Add(appointmentsInCoursesKey, _uOW.APPOINTMENTs.GetAllAppointmentsByCourseId(courseId));

            var apps = AppointmentsInCourseCache;

            return apps as IEnumerable<T>;

        }

        public IEnumerable<T> GetAllPublicAppointments<T>()
        {
            _cache.Add(publicAppointmentsKey, _uOW.APPOINTMENTs.GetAllPublicAppointments());

            var apps = PublicAppointmentsCache;

            return apps as IEnumerable<T>;

        }

        public IEnumerable<T> GetAllAppointmentsClientIsApprovedToAttend<T>(string client)
        {

            _cache.Add(acceptedAppointmentsKey, _uOW.APPOINTMENTs.GetAllAppointmentsClientIsApprovedToAttend(client));

            var apps = AcceptedAppointmentsCache;

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

        public IEnumerable<T> GetPublicAppointmentsSortedByPropertyAscending<T>(string property)
        {

            var apps = GetPublicAppointmentsCached<T>();


            var appsSorted = apps.OrderBy(a => typeof(APPOINTMENT)
                                                .GetProperty(property)
                                                .GetValue(a))
                                                .ToList();

            return appsSorted as IEnumerable<T>;

        }
        public IEnumerable<T> GetPublicAppointmentsSortedByPropertyDescending<T>(string property)
        {

            var apps = GetPublicAppointmentsCached<T>();

            var appsSorted = apps.OrderByDescending(a => typeof(APPOINTMENT)
                                                              .GetProperty(property)
                                                              .GetValue(a))
                                                              .ToList();

            return appsSorted as IEnumerable<T>;

        }

        public IEnumerable<T> GetAcceptedAppointmentsSortedByPropertyAscending<T>(string property)
        {

            var apps = GetAcceptedAppointmentsCached<T>();


            var appsSorted = apps.OrderBy(a => typeof(APPOINTMENT)
                                                   .GetProperty(property)
                                                   .GetValue(a))
                                                   .ToList();

            return appsSorted as IEnumerable<T>;
                      
        }
        public IEnumerable<T> GetAcceptedAppointmentsSortedByPropertyDescending<T>(string property)
        {

            var apps = GetAcceptedAppointmentsCached<T>();

            var appsSorted = apps.OrderByDescending(a => typeof(APPOINTMENT)
                                                               .GetProperty(property)
                                                               .GetValue(a))
                                                               .ToList();

            return appsSorted as IEnumerable<T>;

        }

        public IEnumerable<T> GetExpiredAppointmentsSortedByPropertyAscending<T>(string property)
        {

            var apps = GetExpiredAppointmentsCached<T>();


            var appsSorted = apps.OrderBy(a => typeof(APPOINTMENT)
                                                   .GetProperty(property)
                                                   .GetValue(a))
                                                   .ToList();

            return appsSorted as IEnumerable<T>;

        }
        public IEnumerable<T> GetExpiredAppointmentsSortedByPropertyDescending<T>(string property)
        {

            var apps = GetExpiredAppointmentsCached<T>();

            var appsSorted = apps.OrderByDescending(a => typeof(APPOINTMENT)
                                                               .GetProperty(property)
                                                               .GetValue(a))
                                                               .ToList();

            return appsSorted as IEnumerable<T>;

        }

        public object GetSelectedAppointmentByAppointmentId(int? AppointmentId)
        {

            var apps = GetAppointmentsCached<APPOINTMENT>() as List<APPOINTMENT>;

            var app = apps.FirstOrDefault(a => a.AppointmentId.Equals(AppointmentId));

            return app;

        }

        public object GetSelectedPublicAppointmentByAppointmentId(int? AppointmentId)
        {

            var apps = GetPublicAppointmentsCached<APPOINTMENT>() as List<APPOINTMENT>;

            return apps.FirstOrDefault(a => a.AppointmentId.Equals(AppointmentId));

        }

    }
}
