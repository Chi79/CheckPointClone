﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IUserHomeView
    {
        void BindData();
        string Message { set; }
        int SelectedRowIndex { get; set; }
        int? SessionRowIndex { get; set; }
        int? SessionAppointmentId { get; set; }
        string LoggedInClient { get; }
        string ColumnName { get; set; }
        IEnumerable<object> SetDataSource { set; }
        IEnumerable<object> SetDataSource2 { set; }
        object SelectedRowValueDataKey { get; }

        void RedirectToCreateAppointment();
        void RedirectToManageAppointment();

        event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        event EventHandler<EventArgs> SortColumnsByPropertyDescending;
        event EventHandler<EventArgs> RowSelected;

        event EventHandler<EventArgs> CreateAppointmentButtonClicked;
        event EventHandler<EventArgs> ManageCoursesButtonClicked;
        event EventHandler<EventArgs> ManageAppointmentButtonClicked;
        event EventHandler<EventArgs> ManageAttendanceButtonClicked;
        event EventHandler<EventArgs> CreateReportButtonClicked;
    }
}