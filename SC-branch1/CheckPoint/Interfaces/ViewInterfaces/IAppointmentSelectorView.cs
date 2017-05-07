using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IAppointmentSelectorView
    {
        string Message { set; }

        int SelectedRowIndex { get; set; }


        IEnumerable<object> SetDataSource { set; }
        IEnumerable<object> SetDataSource2 { set; }
        object SelectedRowValueDataKey { get; }


        void BindData();

        void RedirectToManageCourseView();
        void RedirectToAppointmentsView();

        event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        event EventHandler<EventArgs> SortColumnsByPropertyDescending;
        event EventHandler<EventArgs> RowSelected;
        event EventHandler<EventArgs> AddSelectedAppointmentToCourseButtonClicked;

    }
}
