using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IHomePageView
    {
        event EventHandler<EventArgs> RedirectToLogin;
        event EventHandler<EventArgs> RedirectToRegister;
    }
}
