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
    public class ShowAppointmentsInGrid : IShowAppointments<APPOINTMENT, object>
    {
        private IUnitOfWork _uOW;

        private List<APPOINTMENT> _appointments;
        private IEnumerable<object> _apps;

        private Dictionary<string ,Func<IEnumerable<object>>> _sorterDictionary; 

        public ShowAppointmentsInGrid(IUnitOfWork unitOfWork)
        {
            _uOW = unitOfWork;
        }

        public IEnumerable<object> GetAllAppointmentColumns()
        {
            var apps = from a in _appointments
                       select new
                       {
                           a.AppointmentId,
                           a.CourseId,
                           a.AppointmentName,
                           a.Description,
                           a.Date,
                           a.StartTime,
                           a.EndTime,
                           a.Address,
                           a.PostalCode,
                           a.IsObligatory,
                           a.IsCancelled
                       };
            return apps;
        }

        public IEnumerable<APPOINTMENT> GetAllAppointmentsFor(string name)
        {
            _appointments = _uOW.APPOINTMENTs.GetAllAppointmentsFor(name).ToList();
            var ap = _appointments as List<APPOINTMENT>;
            return ap;
        }

        public IEnumerable<object> GetAppointmentsSortedByAppointmentId()
        {
            var app = _appointments.OrderBy(a => a.AppointmentId).ToList();
            return app;
        }
        public IEnumerable<object> GetAppointmentsSortedByCourseId()
        {
            var app = _appointments.OrderBy(a => a.CourseId).ToList();
            return app;
        }
        public IEnumerable<object> GetAppointmentsSortedByAppointmentName()
        {
            var app = _appointments.OrderBy(a => a.AppointmentName).ToList();
            return app;
        }

        public IEnumerable<object> GetAppointmentsSortedByDescription()
        {
            var app = _appointments.OrderBy(a => a.Description).ToList();
            return app;
        }

        public IEnumerable<object> GetAppointmentsSortedByDate()
        {
            var app = _appointments.OrderBy(a => a.Date).ToList();
            return app;
        }

        public IEnumerable<object> GetAppointmentsSortedByStartTime()
        {
            var app = _appointments.OrderBy(a => a.StartTime).ToList();
            return app;
        }

        public IEnumerable<object> GetAppointmentsSortedByEndTime()
        {
            var app = _appointments.OrderBy(a => a.EndTime).ToList();
            return app;
        }

        public IEnumerable<object> GetAppointmentsSortedByAddress()
        {
            var app = _appointments.OrderBy(a => a.Address).ToList();
            return app;
        }
        public IEnumerable<object> GetAppointmentsSortedByPostalCode()
        {
            var app = _appointments.OrderBy(a => a.PostalCode).ToList();
            return app;
        }
        public IEnumerable<object> GetAppointmentsSortedByIsObligatory()
        {
            var app = _appointments.OrderByDescending(a => a.IsObligatory).ToList();
            return app;
        }
        public IEnumerable<object> GetAppointmentsSortedByIsCancelled()
        {
            var app = _appointments.OrderByDescending(a => a.IsCancelled).ToList();
            return app;
        }
        public void LoadSortMethods()
        {
            if (_sorterDictionary == null)
            {

                _sorterDictionary = new Dictionary<string,Func<IEnumerable<object>>>();

                _sorterDictionary.Add("SortByAppointmentId", GetAppointmentsSortedByAppointmentId);
                _sorterDictionary.Add("SortByCourseId", GetAppointmentsSortedByCourseId);
                _sorterDictionary.Add("SortByAppointmentName", GetAppointmentsSortedByAppointmentName);
                _sorterDictionary.Add("SortByDescription", GetAppointmentsSortedByDescription);
                _sorterDictionary.Add("SortByDate", GetAppointmentsSortedByDate);
                _sorterDictionary.Add("SortByStartTime", GetAppointmentsSortedByStartTime);
                _sorterDictionary.Add("SortByEndTime", GetAppointmentsSortedByEndTime);
                _sorterDictionary.Add("SortByAddress", GetAppointmentsSortedByAddress);
                _sorterDictionary.Add("SortByPostalCode", GetAppointmentsSortedByPostalCode);
                _sorterDictionary.Add("SortByIsObligatory", GetAppointmentsSortedByIsObligatory);
                _sorterDictionary.Add("SortByIsCancelled", GetAppointmentsSortedByIsCancelled);

            }
        }
        public IEnumerable<object> GetSortMethod(string sortExpression)
        {
            LoadSortMethods();
            var sortProperty =_sorterDictionary[sortExpression];
            return sortProperty.Invoke();
        }
    }
}
