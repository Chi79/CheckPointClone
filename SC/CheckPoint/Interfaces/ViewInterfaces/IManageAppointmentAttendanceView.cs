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
        object SelectedAppointmentRowValueDataKey { get;}
        object SelectedAttendeeRowValueDataKey { get; }
        bool ShowAttendeeGridViewHeaderPanel { get; set; }
        bool ShowAttendeeGridViewPanel { get; set; }

        void RedirectToManageCourseAttendanceView();
        void BindAppointmentData();
        void BindAttendeeData();

        event EventHandler<EventArgs> AppointmentRowSelected;
        event EventHandler<EventArgs> AttendeeRowSelected;
        event EventHandler<EventArgs> AcceptAttendanceRequest;
        event EventHandler<EventArgs> RedirectToManageCourseAttendance;

    }
}
