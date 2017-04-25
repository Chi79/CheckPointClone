using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IManageAttendanceView
    {
        event EventHandler<EventArgs> AcceptAttendanceRequest;

        IEnumerable<object> CoursesAppliedToSetDataSource { set; }
        IEnumerable<object> AppointmentsAppliedToSetDataSource { set; }

        IEnumerable<object> AppointmentsAppliedToHeaderSetDataSource { set; }
        IEnumerable<object> CoursesAppliedToHeaderSetDataSource { set; }

        void BindData();
    }
}
