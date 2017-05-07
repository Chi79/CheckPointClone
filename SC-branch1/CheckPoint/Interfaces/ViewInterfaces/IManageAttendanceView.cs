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
        event EventHandler<EventArgs> ShowCourses;
        event EventHandler<EventArgs> ShowAppointments;
        event EventHandler<EventArgs> AppointmentRowSelected;
        event EventHandler<EventArgs> CourseRowSelected;

        IEnumerable<object> CoursesAppliedToSetDataSource { set; }
        IEnumerable<object> AppointmentsAppliedToSetDataSource { set; }

        IEnumerable<object> AppointmentsAppliedToHeaderSetDataSource { set; }
        IEnumerable<object> CoursesAppliedToHeaderSetDataSource { set; }

        IEnumerable<object> AppliedAttendeesHeaderSetDataSource { set; }
        IEnumerable<object> AppliedAttendeesSetDataSource { set; }

        int SelectedAppointmentRowIndex { get; set; }
        int SelectedCourseRowIndex { get; set; }

        bool ShowCourseGridViewHeader { set; }
       
        bool ShowCourseGridView { set; }

        bool ShowAppointmentGridViewHeader { set; }

        bool ShowAppointmentGridView { set; }

        void BindData();
    }
}
