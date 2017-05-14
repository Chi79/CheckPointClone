using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IRecordedAppointmentAttendanceView
    {

        IEnumerable<object> AppointmentsAppliedToSetDataSource { set; }
        IEnumerable<object> AppointmentsAppliedToHeaderSetDataSource { set; }
        IEnumerable<object> AppliedAttendeesHeaderSetDataSource { set; }
        IEnumerable<object> AppliedAttendeesSetDataSource { set; }


        void RedirectToCompletedAppointmentsView();
        void BindAppointmentData();
        void BindAttendeeData();

        event EventHandler<EventArgs> ViewCompletedAppointmentsButtonClicked;

    }
}
