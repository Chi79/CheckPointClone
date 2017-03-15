﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IHostHomeView
    {
        //TODO
        void BindData();
        string Message { set; }
        int SelectedRowIndex { get; set; } 
        int? SessionRowIndex { get; set; }
        string ColumnName { get; set; }
        IEnumerable<object> SetDataSource { set; }
        IEnumerable<object> SetDataSource2 { set; }

        object SelectedRowValueDataKey { get; }

        event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        event EventHandler<EventArgs> SortColumnsByPropertyDescending;
        event EventHandler<EventArgs> RowSelected;

        event EventHandler<EventArgs> UpdateButtonClicked;
        event EventHandler<EventArgs> ManageCoursesButtonClicked;
        event EventHandler<EventArgs> ManageAppointmentsButtonClicked;
        event EventHandler<EventArgs> ManageAttendanceButtonClicked;
        event EventHandler<EventArgs> CreateReportButtonClicked;
    }
}
