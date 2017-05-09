using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IUserCoursesView
    {
        int SelectedRowIndex { get; set; }
        IEnumerable<object> SetDataSource { set; }
        IEnumerable<object> SetDataSource2 { set; }
        object SelectedRowValueDataKey { get; }

        void BindData();

        void RedirectToFindCoursesView();
        void RedirectToFindAppointmentsView();
        void RedirectToViewAppointments();

        event EventHandler<EventArgs> RowSelected;
        event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        event EventHandler<EventArgs> SortColumnsByPropertyDescending;
        event EventHandler<EventArgs> ManageAttendanceButtonClicked;


        event EventHandler<EventArgs> FindAppointmentsButtonClicked;
        event EventHandler<EventArgs> FindCoursesButtonClicked;
        event EventHandler<EventArgs> ViewAppointmentsButtonClicked;

    }
}
