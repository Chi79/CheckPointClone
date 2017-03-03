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
    public class ShowAppointmentsInGrid : IShowAppointments<APPOINTMENT,object>
    {
        private IUnitOfWork _uOW;

        private List<APPOINTMENT> appointments;
        private IEnumerable<object> apps;

        public ShowAppointmentsInGrid(IUnitOfWork unitOfWork)
        {
            _uOW = unitOfWork;
        }
        public IEnumerable<object> GetAllAppointmentColumns()
        {
            var apps = from a in appointments
                       select new
                       {
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
            appointments = _uOW.APPOINTMENTs.GetAllAppointmentsFor(name).ToList();
            var ap = appointments as List<APPOINTMENT>;
            return ap;
        }

        public IEnumerable<object> GetAppointmentsSortedByDate()
        {
            var app = appointments.OrderBy(a => a.Date).ToList();
            apps = from a in app
                   select new
                   {
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
    }
}
