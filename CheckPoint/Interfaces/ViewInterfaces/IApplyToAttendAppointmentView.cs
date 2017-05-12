using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IApplyToAttendAppointmentView
    {
        string Message { set; }
        string MediumMessage { set; }
        string StartTime { set; }
        string EndTime { set; }
        string PostalCode { set; }
        string AppointmentName { set; }
        string Description { set; }
        string Address { set; }
        string Date { set; }
        string IsCancelled { set; }
        string IsObligatory { set; }
        string IsPrivate { set; }


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

        void RedirectToFindAppointmentsView();


        bool YesButtonMediumPanelVisible { set; }
        bool NoButtonMediumPanelVisible { set; }
        bool BackToFindAppointmentsButtonVisible { set; }

        bool MessagePanelVisible { set; }
        bool MediumMessagePanelVisible { set; }

        event EventHandler<EventArgs> YesButtonClicked;
        event EventHandler<EventArgs> NoButtonClicked;
        event EventHandler<EventArgs> BackToFindAppointmentsButtonClicked;
    }
}
