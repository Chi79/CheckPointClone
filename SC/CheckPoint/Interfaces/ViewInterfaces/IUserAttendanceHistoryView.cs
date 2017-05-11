using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IUserAttendanceHistoryView
    {

        IEnumerable<object> AppointmentsHistoryToSetDataSource { set; }
        IEnumerable<object> AppointmentsHistoryToHeaderSetDataSource { set; }

        int SelectedAppointmentRowIndex { get; set; }
        object SelectedAppointmentRowValueDataKey { get; }

        void BindAppointmentData();

        event EventHandler<EventArgs> AppointmentRowSelected;
    }
}
