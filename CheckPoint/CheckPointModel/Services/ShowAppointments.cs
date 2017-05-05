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

                //return GetAllAcceptedAppointments<T>();
                return null;

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

        public IEnumerable<T> GetAllPublicAppointments<T>()
        {
            _cache.Add(publicAppointmentsKey, _uOW.APPOINTMENTs.GetAllPublicAppointments());

            var apps = PublicAppointmentsCache;

            return apps as IEnumerable<T>;

        }

        //public IEnumerable<T> GetAllAcceptedAppointments<T>()
        //{
        //    _cache.Add(acceptedAppointmentsKey, _uOW.APPOINTMENTs.GetAllPublicAppointments());

        //    var apps = PublicAppointmentsCache
        //}

        public void SetAllAcceptedAppointments<T>(IEnumerable<object> acceptedAppoiontments)
        {

            _cache.Add(acceptedAppointmentsKey, acceptedAppoiontments);

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

            if(GetAcceptedAppointmentsCached<T>() != null)
            {

                var apps = GetAcceptedAppointmentsCached<T>();


                var appsSorted = apps.OrderBy(a => typeof(APPOINTMENT)
                                                    .GetProperty(property)
                                                    .GetValue(a))
                                                    .ToList();

                return appsSorted as IEnumerable<T>;
            }
            else
            {
                return null;
            }
            
            

        }
        public IEnumerable<T> GetAcceptedAppointmentsSortedByPropertyDescending<T>(string property)
        {

            if (GetAcceptedAppointmentsCached<T>() != null)
            {

                var apps = GetAcceptedAppointmentsCached<T>();

                var appsSorted = apps.OrderByDescending(a => typeof(APPOINTMENT)
                                                                  .GetProperty(property)
                                                                  .GetValue(a))
                                                                  .ToList();

                return appsSorted as IEnumerable<T>;
            }
            else
            {
                return null;
            }

        }

        public object GetSelectedAppointmentByAppointmentId(int? AppointmentId)
        {

            var apps = GetAppointmentsCached<APPOINTMENT>() as List<APPOINTMENT>;

            return apps.FirstOrDefault(a => a.AppointmentId.Equals(AppointmentId));

        }

        public object GetSelectedPublicAppointmentByAppointmentId(int? AppointmentId)
        {

            var apps = GetPublicAppointmentsCached<APPOINTMENT>() as List<APPOINTMENT>;

            return apps.FirstOrDefault(a => a.AppointmentId.Equals(AppointmentId));

        }

    }
}
