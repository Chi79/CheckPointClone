using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IApplyToCourseView
    {
         void BindData();
        string Message {  set; }


        IEnumerable<object> SetDataSource { set; }


        IEnumerable<object> SetDataSource2 { set; }


        int SelectedRowIndex { set; }


        object SelectedRowValueDataKey { get; }


        event EventHandler<EventArgs> RowSelected;
        event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        event EventHandler<EventArgs> SortColumnsByPropertyDescending;

        event EventHandler<EventArgs> btnApplyToCourse_Click;
    }
}
