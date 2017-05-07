using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IChangesSavedCourseView
    {
        string Message { set; }

        string Heading { set; }

        void RedirectToCoursesView();

        event EventHandler<EventArgs> BackToCoursesViewButtonClicked;
    }
}
