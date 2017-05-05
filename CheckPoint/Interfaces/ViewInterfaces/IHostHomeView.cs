using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IHostHomeView
    {
        string Message { set; }

        int SelectedRowIndex { get; set; }
        bool ViewCoursesButtonVisible { set; }
        bool CreateAppointmentButtonVisible { set; }
        bool ManageAppointmentButtonVisible { set; }
        bool CreateReportButtonVisible { set; }
        bool AddSelectedAppointmenButtonVisible { set; }


        IEnumerable<object> SetDataSource { set; }
        IEnumerable<object> SetDataSource2 { set; }
        object SelectedRowValueDataKey { get; }


        void BindData();
        void RedirectToCreateAppointment();
        void RedirectToManageAppointment();
        void RedirectToCoursesView();
        void RedirectToAddSelectedAppointmenToCourseView();


        event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        event EventHandler<EventArgs> SortColumnsByPropertyDescending;
        event EventHandler<EventArgs> RowSelected;
        event EventHandler<EventArgs> CreateAppointmentButtonClicked;
        event EventHandler<EventArgs> ManageAppointmentButtonClicked;
        event EventHandler<EventArgs> ManageAttendanceButtonClicked;
        event EventHandler<EventArgs> CreateReportButtonClicked;
        event EventHandler<EventArgs> ViewCoursesButtonClicked;
        event EventHandler<EventArgs> AddSelectedAppointmentToCourseButtonClicked;

    }
}
