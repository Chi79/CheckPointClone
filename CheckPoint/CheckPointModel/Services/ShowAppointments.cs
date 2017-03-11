using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ServiceInterfaces;
using CheckPointCommon.RepositoryInterfaces;
using CheckPointCommon.CacheInterfaces;
using CheckPointDataTables.Tables;
using System.Runtime.Caching;

namespace CheckPointModel.Services
{
    public class ShowAppointments : IShowAppointments
    {
        private IUnitOfWork _uOW;
        private ICacheData _cache;

        public const string key = "appointmentKey";

        public ShowAppointments(IUnitOfWork unitOfWork, ICacheData cache)
        {
            _uOW = unitOfWork;
            _cache = cache;
        }
        public IEnumerable<T> GetAppointmentsCached<T>()
        {
            return AppointmentsCache as IEnumerable<T>;
        }
        public List<APPOINTMENT> AppointmentsCache
        {
            get { return _cache.FetchCollection<APPOINTMENT>(key).ToList(); }
        }

        public IEnumerable<T> GetAllAppointmentsFor<T>(string client)
        {
            _cache.Add(key, _uOW.APPOINTMENTs.GetAllAppointmentsFor(client));

            var apps = AppointmentsCache;
            return apps as IEnumerable<T>;
        }

        public IEnumerable<T> GetAppointmentsSortedByPropertyAscending<T>(string property)
        {
            if (AppointmentsCache != null && AppointmentsCache.Count > 0)
            {
                var appsSorted = AppointmentsCache.OrderBy(a => typeof(APPOINTMENT).GetProperty(property).GetValue(a)).ToList();
                return appsSorted as IEnumerable<T>;
            }
            return null;
        }
        public IEnumerable<T> GetAppointmentsSortedByPropertyDescending<T>(string property)
        {
            if (AppointmentsCache != null && AppointmentsCache.Count > 0)
            {
                var appsSorted = AppointmentsCache.OrderByDescending(a => typeof(APPOINTMENT).GetProperty(property).GetValue(a)).ToList();
                return appsSorted as IEnumerable<T>;
            }
            return null;
        }
    }
}
