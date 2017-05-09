using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IManageAppointmentAttendanceView
    {

        IEnumerable<object> AppointmentsAppliedToSetDataSource { set; }
        IEnumerable<object> AppointmentsAppliedToHeaderSetDataSource { set; }
        IEnumerable<object> AppliedAttendeesHeaderSetDataSource { set; }
        IEnumerable<object> AppliedAttendeesSetDataSource { set; }
        int SelectedAppointmentRowIndex { get; set; }
        int SelectedAttendeeRowIndex { get; set; }
        object SelectedAppointmentRowValueDataKey { get; }
        object SelectedAttendeeRowValueDataKey { get; }
        bool ShowAttendeeGridViewHeader { get; set; }
        bool ShowAttendeeGridView { get; set; }
        bool ShowAcceptAttendanceRequestButton { set; }
        bool ShowAcceptAllAttendanceRequestsForSelectedAppointmentButton { set; }

        string MessagePanelMessage { get; set; }        
        bool MessagePanelVisible { set; }
        bool YesButtonVisible { set;}
        bool NoButtonVisible { set; }
        bool ContinueButtonVisible { set; }
 


        void RedirectToManageCourseAttendanceView();
        void BindAppointmentData();
        void BindAttendeeData();


        event EventHandler<EventArgs> AppointmentRowSelected;
        event EventHandler<EventArgs> AttendeeRowSelected;
        event EventHandler<EventArgs> AcceptAttendanceRequest;
        event EventHandler<EventArgs> RedirectToManageCourseAttendance;
        event EventHandler<EventArgs> AcceptAllAttendanceRequestsForSelectedAppointment;
        event EventHandler<EventArgs> YesButtonClicked;
        event EventHandler<EventArgs> NoButtonClicked;
        event EventHandler<EventArgs> ContinueButtonClicked;

    }
}
