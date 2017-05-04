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
        int SelectedCourseRowIndex { get; set; }
        int SelectedAttendeeRowIndex { get; set; }
        object SelectedCourseRowValueDataKey { get; }
        object SelectedAttendeeRowValueDataKey { get; }
        bool ShowAttendeeGridViewHeaderPanel { get; set; }
        bool ShowAttendeeGridViewPanel { get; set; }

        void RedirectToManageAppointmentAttendanceView();
        void BindCourseData();
        void BindAttendeeData();

        event EventHandler<EventArgs> CourseRowSelected;
        event EventHandler<EventArgs> AttendeeRowSelected;
        event EventHandler<EventArgs> AcceptAttendanceRequest;
        event EventHandler<EventArgs> RedirectToManageAppointmentAttendance;
    }
        
        
}
