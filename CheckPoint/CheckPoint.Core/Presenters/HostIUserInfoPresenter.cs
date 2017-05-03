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
            _view.Message = "IMPORTANT INFORMATION : When registering a new account you have two choices. 1. Register as a Host -- or -- 2. Register as a User.";

            _view.HostInfoHeading = "What is a Host?";

            _view.HostInfo = "A 'Host' account allows you to create and manage events along with managing who can attend the events you create. If you wish to be a 'Host' please click the appropriate button below.";

            _view.UserInfoHeading = "What is a User?";

            _view.UserInfo = "A 'User' account allows you to search and discover events that have been created by a CheckPoint Host.  You can apply to attend these events and your attendence will be recorded with the help of an identification tag that will be sent to you once registration is complete.";
        }

        public override void Load()
        {
            WireUpEvents();
        }
    }
}
