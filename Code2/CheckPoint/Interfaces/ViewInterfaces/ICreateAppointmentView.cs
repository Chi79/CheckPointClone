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
        string CourseId { get; }
        string StartTime { get; }
        string EndTime { get; }
        string PostalCode { get; }
        string AppointmentName {get;}
        string Description { get; }
        string Address { get; }
        string Date { get; }
        string UserName { get; }
        string IsCancelled { get; }
        string IsObligatory { get; }

        string Message { get;  set; }

        event EventHandler<EventArgs> CreateNewAppointment;
    }
}
