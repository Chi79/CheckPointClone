using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IExpiredAppointmentsView
    {
        string Message { set; }

        int SelectedRowIndex { get; set; }
        bool MessagePanelVisible { set; }
        bool ContinueButtonVisible { set; }


        IEnumerable<object> SetDataSource { set; }
        IEnumerable<object> SetDataSource2 { set; }
        object SelectedRowValueDataKey { get; }


        void BindData();
        void RedirectToCoursesView();

        void RedirectToViewAttendaceForAppointmentsView();


        event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        event EventHandler<EventArgs> SortColumnsByPropertyDescending;
        event EventHandler<EventArgs> RowSelected;
        event EventHandler<EventArgs> ViewCoursesButtonClicked;
        event EventHandler<EventArgs> ViewAttendancesForAppointmentButtonClicked;
        event EventHandler<EventArgs> ContinueButtonClicked;

    }
}
