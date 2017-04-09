using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IAddSelectedAppointmentToCourseView
    {
        string Message { get; set; }

        string StartTime { get; set; }
        string EndTime { get; set; }
        string PostalCode { get; set; }
        string AppointmentName { get; set; }
        string Description { get; set; }
        string Address { get; set; }
        string Date { get; set; }
        string IsCancelled { get; set; }
        string IsObligatory { get; set; }
        string IsPrivate { get; set; }


        bool AppointmentNameReadOnly { set; }
        bool DateReadOnly { set; }
        bool AppointmentDescriptionReadOnly { set; }
        bool StartTimeReadOnly { set; }
        bool EndDateReadOnly { set; }
        bool IsCancelledEnabled { set; }
        bool IsObligatoryEnabled { set; }
        bool IsPrivateEnabled { set; }
        bool PostalCodeReadOnly { set; }
        bool AddressReadOnly { set; }
        bool EndTimeReadOnly { set; }

    }
}
