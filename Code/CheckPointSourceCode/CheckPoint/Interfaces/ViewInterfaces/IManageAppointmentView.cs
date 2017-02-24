using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IManageAppointmentView
    {
        //TODO
        string FromTime { get; set; }
        string ToTime { get; set; }
        string PostalCode { get; set; }
        string AppointmentName { get; set; }
        string Description { get; set; }
        string StreetAddress { get; set; }
        string Date { get; set; }
        string UserName { get; set; }
        string Private { get; set; }
        string IsCancelled { get; set; }
        string IsObligatory { get; set; }

        string AppointmentNameList { get; set; }

        void FillAppointmentList(List<string> list);
        void RedirectAfterClickEvent();

        string Message { get; set; }

        bool ContinueButtonVisible { set; }
        bool UpdateButtonVisible { set; }

        event EventHandler<EventArgs> UpdateAppointment;
        event EventHandler<EventArgs> FetchData;
        event EventHandler<EventArgs> ReloadPage;

    }
}
