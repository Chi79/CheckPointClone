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

        int SelectedAppointmentRowIndex { get; set; }
        object SelectedAppointmentRowValueDataKey { get; }

        void BindAppointmentData();
        bool ShowTimeAttendedHeader { set; }

        string DateAndTimeTextBoxMessage { set; }

        bool ShowDateAndTimeTextBox { set; }

        event EventHandler<EventArgs> AppointmentRowSelected;
    }
}
