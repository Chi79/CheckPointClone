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

        private Dictionary<string,string> _sorterDictionary;

        public ShowAppointmentsInGrid(IUnitOfWork unitOfWork)
        {
            _uOW = unitOfWork;
        }

        public IEnumerable<APPOINTMENT> GetAllAppointmentsFor(string name)
        {
            _appointments = _uOW.APPOINTMENTs.GetAllAppointmentsFor(name).ToList();
            var ap = _appointments as List<APPOINTMENT>;
            return ap;
        }

        public IEnumerable<object> GetAppointmentsSortedByProperty(string property)
        {
            if(_appointments != null && _appointments.Count > 0)
            {
                var app = _appointments.OrderBy(a => typeof(APPOINTMENT).GetProperty(property).GetValue(a)).ToList();
                return app;
            }
            return null;
        }

        public void LoadSortMethods()
        {
            if (_sorterDictionary == null)
            {

                _sorterDictionary = new Dictionary<string,string>();

                _sorterDictionary.Add("SortByAppointmentId", "AppointmentId");
                _sorterDictionary.Add("SortByCourseId", "CourseId");
                _sorterDictionary.Add("SortByAppointmentName", "AppointmentName");
                _sorterDictionary.Add("SortByDescription", "Description");
                _sorterDictionary.Add("SortByDate", "Date");
                _sorterDictionary.Add("SortByStartTime", "StartTime");
                _sorterDictionary.Add("SortByEndTime", "EndTime");
                _sorterDictionary.Add("SortByAddress", "Address");
                _sorterDictionary.Add("SortByPostalCode", "PostalCode");
                _sorterDictionary.Add("SortByIsObligatory", "IsObligatory");
                _sorterDictionary.Add("SortByIsCancelled","IsCancelled");

            }
        }
        public IEnumerable<object> SortColumnBy(string sortExpression)
        {
            LoadSortMethods();
            var sortProperty =_sorterDictionary[sortExpression];
            return GetAppointmentsSortedByProperty(sortProperty);
        }
    }
}
