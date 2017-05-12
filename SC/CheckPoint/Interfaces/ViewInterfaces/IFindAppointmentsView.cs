﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IFindAppointmentsView
    {
        string Message { set; }
        int SelectedRowIndex { get; set; }
        IEnumerable<object> SetDataSource { set; }
        IEnumerable<object> SetDataSource2 { set; }
        object SelectedRowValueDataKey { get; }

        void BindData();

        bool MessagePanelVisible { set; }

        bool ContinueButtonVisible { set; }

        void RedirectToFindCoursesView();

        void RedirectToApplyToAppointmentView();

        event EventHandler<EventArgs> RowSelected;
        event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        event EventHandler<EventArgs> SortColumnsByPropertyDescending;

        event EventHandler<EventArgs> FindCoursesButtonClicked;
        event EventHandler<EventArgs> ApplyToAttendAppointmentButtonClicked;

        event EventHandler<EventArgs> ContinueButtonClicked;

    }
}
