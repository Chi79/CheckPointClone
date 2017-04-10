﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IManageCourseView
    {
        string Message { set; }
        IEnumerable<object> SetDataSource { set; }
        IEnumerable<object> SetDataSource2 { set; }

        void BindData();


        IEnumerable<object> SetDataSourceAppointmentHeader { set; }
        IEnumerable<object> SetDataSourceAppointmentData { set; }
        object SelectedRowValueDataKey { get; }
        int SelectedRowIndex { get; set; }


        event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        event EventHandler<EventArgs> SortColumnsByPropertyDescending;
        event EventHandler<EventArgs> RowSelected;
    }
}
