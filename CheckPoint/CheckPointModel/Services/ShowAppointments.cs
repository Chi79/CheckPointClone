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
    public class ShowAppointments : IShowAppointments<APPOINTMENT, object>
    {
        private IUnitOfWork _uOW;

        private List<APPOINTMENT> _appointments;


        public ShowAppointments(IUnitOfWork unitOfWork)
        {
            _uOW = unitOfWork;
        }

        public IEnumerable<APPOINTMENT> GetAllAppointmentsFor(string client)
        {
            _appointments = _uOW.APPOINTMENTs.GetAllAppointmentsFor(client).ToList();
            var ap = _appointments as List<APPOINTMENT>;
            return ap;
        }

        public IEnumerable<object> GetAppointmentsSortedByPropertyAscending(string property)
        {
            if(_appointments != null && _appointments.Count > 0)
            {
                var app = _appointments.OrderBy(a => typeof(APPOINTMENT).GetProperty(property).GetValue(a)).ToList();
                return app;
            }
            return null;
        }
        public IEnumerable<object> GetAppointmentsSortedByPropertyDescending(string property)
        {
            if (_appointments != null && _appointments.Count > 0)
            {
                var app = _appointments.OrderByDescending(a => typeof(APPOINTMENT).GetProperty(property).GetValue(a)).ToList();
                return app;
            }
            return null;
        }
    }
}
