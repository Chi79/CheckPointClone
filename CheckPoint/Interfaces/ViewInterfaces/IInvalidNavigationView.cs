using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IInvalidNavigationView
    {
        string Message { set; }

        void RedirectToCoursesView();

        event EventHandler<EventArgs> BackToCoursesViewButtonClicked;
    }
}
