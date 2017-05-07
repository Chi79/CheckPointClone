using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IHostCoursesView
    {

        string Message { set; }
        int SelectedRowIndex { get; set; }
        IEnumerable<object> SetDataSource { set; }
        IEnumerable<object> SetDataSource2 { set; }
        object SelectedRowValueDataKey { get; }

        bool MessagePanelVisible { set; }
        bool ContinueButtonVisible { set; }

        void BindData();
        void RedirectToCreateCourse();
        void RedirectToManageCourse();
        void RedirectToAppointmentsView();

        event EventHandler<EventArgs> RowSelected;
        event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        event EventHandler<EventArgs> SortColumnsByPropertyDescending;
        event EventHandler<EventArgs> CreateCourseButtonClicked;
        event EventHandler<EventArgs> ManageCourseButtonClicked;
        event EventHandler<EventArgs> ManageAttendanceButtonClicked;
        event EventHandler<EventArgs> CreateReportButtonClicked;
        event EventHandler<EventArgs> ViewAppointmentsButtonClicked;
        event EventHandler<EventArgs> ContinueButtonClicked;
    }
}
