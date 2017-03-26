using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface ILoginView
    {
        string Username { get; }
        string Password { get; }
        string Message { set; }

        string LoggedInClient { get; set; }
        bool AddAppointmentToCourseStatus { set; }

        void RedirectToUserHomePage();
        void RedirectToHostHomePage();
        event EventHandler<EventArgs> Login;
    }
}
