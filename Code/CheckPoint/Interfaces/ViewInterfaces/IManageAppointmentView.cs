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
        string CourseId { get; set; }
        string StartTime { get; set; }
        string EndTime { get; set; }
        string PostalCode { get; set; }
        string AppointmentName { get; set; }
        string Description { get; set; }
        string Address { get; set; }
        string Date { get; set; }
        string UserName { get; set; }
        string IsCancelled { get; set; }
        string IsObligatory { get; set; }

        string AppointmentNameList { get; set; }
        List<string> SetDataSource { set; }

        void BindAppointmentList();
        void RedirectAfterClickEvent();

        string Message { get; set; }

        bool ContinueButtonVisible { set; }
        bool UpdateButtonVisible { set; }
        bool AddButtonVisible { set; }

        event EventHandler<EventArgs> UpdateAppointment;
        event EventHandler<EventArgs> AddAppointment;
        event EventHandler<EventArgs> FetchData;
        event EventHandler<EventArgs> ReloadPage;

    }
}
