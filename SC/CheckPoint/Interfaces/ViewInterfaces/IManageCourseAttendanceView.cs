using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IManageCourseAttendanceView
    {
        event EventHandler<EventArgs> RowSelected;
        event EventHandler<EventArgs> AcceptAttendanceRequest;
        event EventHandler<EventArgs> RedirectToManageAppointmentAttendance;

        void RedirectToManageAppointmentAttendanceView();
        IEnumerable<object> CoursesAppliedToSetDataSource { set; }      
        IEnumerable<object> CoursesAppliedToHeaderSetDataSource { set; }
        int SelectedRowIndex { get; set; }
        void BindCourseData();
        void BindAttendeeData();
    }
}
