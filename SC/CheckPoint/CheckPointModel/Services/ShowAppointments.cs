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

        public const string key = "appointmentKey";
        public string client;

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
        public List<APPOINTMENT> AppointmentsCache
        {
            get{  return _cache.FetchCollection<APPOINTMENT>(key).ToList(); }
        }

        public IEnumerable<T> GetAllAppointmentsFor<T>(string client)
        {
            _cache.Add(key, _uOW.APPOINTMENTs.GetAllAppointmentsFor(client));

            var apps = AppointmentsCache;
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
    }
}
