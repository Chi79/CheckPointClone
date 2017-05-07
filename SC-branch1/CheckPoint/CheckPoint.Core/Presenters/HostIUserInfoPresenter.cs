using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ViewInterfaces;
using CheckPointPresenters.Bases;

namespace CheckPointPresenters.Presenters
{
    public class HostIUserInfoPresenter : PresenterBase
    {

        private IHostUserInfoView _view;


        public HostIUserInfoPresenter(IHostUserInfoView view)
        {

            _view = view;

        }

        public void WireUpEvents()
        {

            _view.RegisterNewHostClicked += OnRegisterNewHostClicked;
            _view.RegisterNewUserClicked += OnRegisterNewUserClicked;
            _view.BackToHomePageClicked += OnBackToHomePageClicked;
        }

        private void OnBackToHomePageClicked(object sender, EventArgs e)
        {

            _view.RedirectBackToHomePage();

        }

        private void OnRegisterNewUserClicked(object sender, EventArgs e)
        {

            _view.RedirectToRegisterUserPage();

        }

        private void OnRegisterNewHostClicked(object sender, EventArgs e)
        {

            _view.RedirectToRegisterHostPage();

        }

        public override void FirstTimeInit()
        {

            _view.HostInfoHeading = "Be a Host";

            _view.HostInfo = "As a CheckPoint Host you can create and manage events of any kind for CheckPoint Users to attend. With our simple to use tag system it's easy to see who has attended your events. If you wish to be a Host please click the appropriate button below and lets get started...";

            _view.UserInfoHeading = "Be a User";

            _view.UserInfo = "As a User you can search for, discover and attend events that have been created by a CheckPoint Host.  With the help of a unique identification tag that will be sent to you once registration is complete - whenever you attend an event you can be sure that your attendance will be safely recorded. Just click the button below and get started... ";
        }

        public override void Load()
        {
            WireUpEvents();
        }
    }
}
