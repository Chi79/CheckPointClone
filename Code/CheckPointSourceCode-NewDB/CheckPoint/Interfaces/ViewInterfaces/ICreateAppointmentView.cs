using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface ICreateAppointmentView
    {
        //TODO
        string FromTime { get; }
        string ToTime { get; }
        string PostalCode { get; }
        string AppointmentName {get;}
        string Description { get; }
        string StreetAddress { get; }
        string Date { get; }
        string UserName { get; }
        string Private { get; }
        string IsCancelled { get; }
        string IsObligatory { get; }

        string Message { get;  set; }

        event EventHandler<EventArgs> CreateNewAppointment;
    }
}
