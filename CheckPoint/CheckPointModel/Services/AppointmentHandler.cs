using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ServiceInterfaces;
using CheckPointCommon.RepositoryInterfaces;
using CheckPointDataTables.Tables;
using CheckPointCommon.Structs;
using CheckPointModel.DTOs;

namespace CheckPointModel.Services
{
    public class AppointmentHandler : IHandleAppointments<APPOINTMENT, SaveResult> 
    {
        private readonly IUnitOfWork _uOW;

        private IEnumerable<APPOINTMENT> _appointments;
        private APPOINTMENT _appointment;

        public AppointmentHandler(IUnitOfWork unitOfWork)
        {
            _uOW = unitOfWork;
        }

        public IEnumerable<APPOINTMENT> GetAllAppointmentsForClient(string client)
        {
            _appointments = _uOW.APPOINTMENTs.GetAllAppointmentsFor(client);
            return _appointments;
        }

        public IEnumerable<string> GetAllAppointmentNamesForClient(string client)
        {
            GetAllAppointmentsForClient(client);
            var allAppointmentNames = _appointments.Select(app => app.AppointmentName);
            return allAppointmentNames;
        }

        public APPOINTMENT GetAppointmentToDisplay()
        {
            _appointment = _appointments.FirstOrDefault();
            return _appointment;
        }

        public APPOINTMENT GetAppointmentByName(string appointmentName)
        {
            _appointment = _uOW.APPOINTMENTs.GetAppointmentByAppointmentName(appointmentName);
            return _appointment;
        }

        public void Delete(APPOINTMENT appointment)
        {
            _uOW.APPOINTMENTs.Remove(appointment);
        }

        public void Create(APPOINTMENT appointment)
        {
            _uOW.APPOINTMENTs.Add(appointment);
        }

        public SaveResult SaveChangesToAppointments()
        {
           return _uOW.Complete();
        }
    }
}
