using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IUserAttendanceHistoryView
    {

        IEnumerable<object> AppointmentsHistorySetDataSource { set; }
        IEnumerable<object> AppointmentsHistoryHeaderSetDataSource { set; }

        IEnumerable<object> AttendanceHistorySetDataSource { set; }
        IEnumerable<object> AttendanceHistoryHeaderSetDataSource { set; }
        bool ShowAttendeeGridViewPanel { set; }
        bool ShowAttendeeHeaderPanel { set; }

        int SelectedAppointmentRowIndex { get; set; }
        object SelectedAppointmentRowValueDataKey { get; }
        bool ShowAttendeeGridView { get; set; }
        bool ShowAttendeeGridViewHeader { get; set; }

        bool ShowAttendeeHeader { set; }

        void BindAppointmentData();
        void BindAttendeeData();

        event EventHandler<EventArgs> AppointmentRowSelected;
    }
}
