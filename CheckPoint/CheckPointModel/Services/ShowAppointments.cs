using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ServiceInterfaces;
using CheckPointCommon.RepositoryInterfaces;
using CheckPointDataTables.Tables;
using System.Runtime.Caching;

namespace CheckPointModel.Services
{
    public class ShowAppointments : IShowAppointments<APPOINTMENT, object>
    {
        private IUnitOfWork _uOW;

        private List<APPOINTMENT> _appointments;

        public MemoryCache myCache = new MemoryCache("appCache");
        private const string myCacheKey = "appCache";

        public ShowAppointments(IUnitOfWork unitOfWork)
        {
            _uOW = unitOfWork;
        }
        public List<APPOINTMENT> Cache
        {
            get { return myCache[myCacheKey] as List<APPOINTMENT>; }
            set { myCache[myCacheKey] = value; }
        }

        public IEnumerable<APPOINTMENT> GetAllAppointmentsFor(string client)
        {
            //CacheItemPolicy cachePolicy = new CacheItemPolicy();
            //cachePolicy.AbsoluteExpiration = DateTime.Now.AddHours(2);
            //myCache.Add( myCacheKey, _uOW.APPOINTMENTs.GetAllAppointmentsFor(client).ToList(), cachePolicy);

            _appointments = _uOW.APPOINTMENTs.GetAllAppointmentsFor(client).ToList();
            var ap = _appointments as List<APPOINTMENT>;
            //var ap = Cache as List<APPOINTMENT>;
            return ap;
        }

        public IEnumerable<object> GetAppointmentsSortedByPropertyAscending(string property)
        {
            if (_appointments != null && _appointments.Count > 0)
            //if (Cache != null && Cache.Count > 0)
            {
                var app = _appointments.OrderBy(a => typeof(APPOINTMENT).GetProperty(property).GetValue(a)).ToList();
                //var app = Cache.OrderBy(a => typeof(APPOINTMENT).GetProperty(property).GetValue(a)).ToList();
                return app;
            }
            return null;
        }
        public IEnumerable<object> GetAppointmentsSortedByPropertyDescending(string property)
        {
            if (_appointments != null && _appointments.Count > 0)
            //if (Cache != null && Cache.Count > 0)
            {
                var app = _appointments.OrderByDescending(a => typeof(APPOINTMENT).GetProperty(property).GetValue(a)).ToList();
                //var app = Cache.OrderByDescending(a => typeof(APPOINTMENT).GetProperty(property).GetValue(a)).ToList();
                return app;
            }
            return null;
        }
    }
}
