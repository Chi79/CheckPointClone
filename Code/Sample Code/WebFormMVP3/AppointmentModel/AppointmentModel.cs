using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLibrary;
using POCOClassLibrary;

namespace AppointmentModel
{
    // Extremely simple and basic Model which just creates and stores a non-persistent List on Appointments
    public class AppointmentsModel : IAppointmentModel<Appointment>  //Implements the Model Interface
    {
        private int _indexcounter;
        public int indexcounter { get { return _indexcounter; } set { _indexcounter = value; } }
        
        private string _navigationstatus;
        public string navigationstatus { get { return _navigationstatus; } set { _navigationstatus = value; } }

        private List<Appointment> ModelAppointments;
        public List<Appointment> CreateList()
        {
            if(ModelAppointments == null)
            {
                ModelAppointments = new List<Appointment>();
            }
            return ModelAppointments;
        }
        public List<Appointment> GetList()
        {
            return ModelAppointments;
        }
        public void ParseAppointmentDates(Appointment appointment)
        {
            appointment.StartDate = DateTime.Parse(appointment.StartDate).ToString();
            appointment.DueDate = DateTime.Parse(appointment.DueDate).ToString();
            appointment.CompletionDate = DateTime.Parse(appointment.CompletionDate).ToString();
        }
        public bool ValidateDates(Appointment appointmentToValidate)
        {
            DateTime Date;

            if (!DateTime.TryParse(Convert.ToString(appointmentToValidate.StartDate), out Date))
            {
                return false;
            }
            if (!DateTime.TryParse(Convert.ToString(appointmentToValidate.DueDate), out Date))
            {
                return false;
            }
            if (!DateTime.TryParse(Convert.ToString(appointmentToValidate.CompletionDate), out Date))
            {
                return false;
            }
            return true;
        }
        public bool ValidateNullStrings(Appointment appointmentToValidate)
        {
            if (string.IsNullOrWhiteSpace(appointmentToValidate.AppointmentName))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(appointmentToValidate.StartDate))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(appointmentToValidate.DueDate))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(appointmentToValidate.CompletionDate))
            {
                return false;
            }
            return true;
        }
    }
}
