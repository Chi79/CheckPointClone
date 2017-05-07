using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IFindCoursesView
    {

        string Message { set; }
        int SelectedRowIndex { get; set; }
        IEnumerable<object> SetDataSource { set; }
        IEnumerable<object> SetDataSource2 { set; }
        object SelectedRowValueDataKey { get; }

        void BindData();

        void RedirectToFindAppointmentsView();
        void RedirectToApplyToCourseView();

        event EventHandler<EventArgs> RowSelected;
        event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        event EventHandler<EventArgs> SortColumnsByPropertyDescending;

        event EventHandler<EventArgs> FindPublicAppointmentsButtonClicked;
        event EventHandler<EventArgs> ApplyToAttendCourseButtonClicked;


    }
}
