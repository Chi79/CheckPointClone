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
        int SelectedRowIndex { get; set; }
        object SelectedRowValueDataKey { get;}
        bool ShowAttendeeGridViewHeaderPanel { get; set; }
        bool ShowAttendeeGridViewPanel { get; set; }

        void RedirectToManageCourseAttendanceView();
        void BindAppointmentData();
        void BindAttendeeData();

        event EventHandler<EventArgs> RowSelected;
        event EventHandler<EventArgs> AcceptAttendanceRequest;
        event EventHandler<EventArgs> RedirectToManageCourseAttendance;

    }
}
