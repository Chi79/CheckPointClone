using System;
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
        string ColumnTitle { get; set; }
        IEnumerable<object> SetDataSource { set; }

        event EventHandler<EventArgs> SortColumn;
        event EventHandler<EventArgs> RowSelected;
    }
}
