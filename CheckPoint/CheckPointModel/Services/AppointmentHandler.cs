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
    public class AppointmentHandler : IHandleAppointments
    {
        private readonly IUnitOfWork _uOW;

        private IEnumerable<APPOINTMENT> _appointments;
        private APPOINTMENT _appointment;

        public AppointmentHandler(IUnitOfWork unitOfWork)
        {
            _uOW = unitOfWork;
        }

        public IEnumerable<APPOINTMENT> GetAllAppointmentsForClient<APPOINTMENT>(string client)
        {
            _appointments = _uOW.APPOINTMENTs.GetAllAppointmentsFor(client);
            return _appointments as IEnumerable<APPOINTMENT>;
        }

        public IEnumerable<string> GetAllAppointmentNamesForClient(string client)
        {
            GetAllAppointmentsForClient<APPOINTMENT>(client);
            var allAppointmentNames = _appointments.Select(app => app.AppointmentName);
            return allAppointmentNames;
        }

        public object GetAppointmentToDisplay()
        {
            _appointment = _appointments.FirstOrDefault();
            return _appointment;
        }

        public object GetAppointmentByName(string appointmentName)
        {
            _appointment = _uOW.APPOINTMENTs.GetAppointmentByAppointmentName(appointmentName);
            return _appointment;
        }

        public object GetAppointmentById(int appointmentId)
        {
            _appointment = _uOW.APPOINTMENTs.GetAppointmentByAppointmentId(appointmentId);
            return _appointment;
        }


        public void Delete<T>(T appointment)
        {
            _uOW.APPOINTMENTs.Remove(appointment as APPOINTMENT);
        }


        public void Create<T>(T appointment)
        {
            //APPOINTMENT app = appointment as APPOINTMENT;
            //COURSE course = new COURSE() { Name = app.AppointmentName, Description = app.Description };
            //_uOW.COURSEs.Add(course);

            _uOW.APPOINTMENTs.Add(appointment as APPOINTMENT);
        }


        public object SaveChangesToAppointments()
        {
            return _uOW.Complete();
        }
    }
}
