using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IHostCoursesView
    {
        void BindData();
        string Message { set; }
        int SelectedRowIndex { get; set; }
        int? SessionRowIndex { get; set; }
        int? SessionCourseId { get; set; }
        string LoggedInClient { get; }
        string ColumnName { get; set; }
        IEnumerable<object> SetDataSource { set; }
        IEnumerable<object> SetDataSource2 { set; }
        object SelectedRowValueDataKey { get; }

        void RedirectToCreateCourse();
        void RedirectToManageCourse();
        void RedirectToAppointmentsView();

        event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        event EventHandler<EventArgs> SortColumnsByPropertyDescending;
        event EventHandler<EventArgs> RowSelected;

        event EventHandler<EventArgs> CreateCourseButtonClicked;
        event EventHandler<EventArgs> ManageCourseButtonClicked;
        event EventHandler<EventArgs> ManageAttendanceButtonClicked;
        event EventHandler<EventArgs> CreateReportButtonClicked;

        event EventHandler<EventArgs> ViewAppointmentsButtonClicked;
    }
}
