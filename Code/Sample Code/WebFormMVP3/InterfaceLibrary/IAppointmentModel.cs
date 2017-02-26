using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary
{
    //extremely basic Interface for the Model to implement.
    public interface IAppointmentModel<Appointment>
    {
        List<Appointment> CreateList();
        List<Appointment> GetList();
        bool ValidateDates(Appointment appointment);
        bool ValidateNullStrings(Appointment appointment);
        void ParseAppointmentDates(Appointment appointment);
        int indexcounter { get; set; }
        string navigationstatus { get; set; }
    }
}
