using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IManageAppointmentAttendanceView
    {
        event EventHandler<EventArgs> RowSelected;
        event EventHandler<EventArgs> AcceptAttendanceRequest;
        event EventHandler<EventArgs> RedirectToManageCourseAttendance;

        void RedirectToManageCourseAttendanceView();

        IEnumerable<object> AppointmentsAppliedToSetDataSource { set; }
        IEnumerable<object> AppointmentsAppliedToHeaderSetDataSource { set; }
        int SelectedRowIndex { get; set; }
        void BindAppointmentData();
        void BindAttendeeData();

    }
}
