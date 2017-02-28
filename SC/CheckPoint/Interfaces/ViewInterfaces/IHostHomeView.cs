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
        IEnumerable<object> SetDataSource { set; }
        void DataBind();
        string Message { set; }
        IEnumerable<object> SetDataSource2 { set; }

        event EventHandler<EventArgs> BindGrid;
    }
}
