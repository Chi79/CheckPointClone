using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IManageCourseAttendanceView
    {
        
        IEnumerable<object> CoursesAppliedToSetDataSource { set; }      
        IEnumerable<object> CoursesAppliedToHeaderSetDataSource { set; }
        IEnumerable<object> AppliedAttendeesHeaderSetDataSource { set; }
        IEnumerable<object> AppliedAttendeesSetDataSource { set; }
        int SelectedRowIndex { get; set; }
        object SelectedRowValueDataKey { get; }
        bool ShowAttendeeGridViewHeaderPanel { get; set; }
        bool ShowAttendeeGridViewPanel { get; set; }

        void RedirectToManageAppointmentAttendanceView();
        void BindCourseData();
        void BindAttendeeData();

        event EventHandler<EventArgs> RowSelected;
        event EventHandler<EventArgs> AcceptAttendanceRequest;
        event EventHandler<EventArgs> RedirectToManageAppointmentAttendance;
    }
        
        
}
