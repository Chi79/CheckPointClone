using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IHostUserInfoView
    {

        string HostInfoHeading { set; }
        string HostInfo { set; }

        string UserInfoHeading { set; }
        string UserInfo { set; }

        void RedirectBackToHomePage();
        void RedirectToRegisterHostPage();

        void RedirectToRegisterUserPage();

        event EventHandler<EventArgs> RegisterNewHostClicked;
        event EventHandler<EventArgs> BackToHomePageClicked;
        event EventHandler<EventArgs> RegisterNewUserClicked;
    }
}
