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

            _view.HostInfo = @"As a CheckPoint Host you can:
                            </br>+ Create courses and appointments for users to apply to.  <br/>
                                 + Manage attendance requests from users. <br/>
                                 + Track attendance history<br/> 
                               <br/>When becoming a Host, a reading terminal device will be sent to your address. Make sure you remember
                               to download and install the reading terminal software located on the download tab on your homepage.";

            _view.UserInfoHeading = "Be a User";

            _view.UserInfo = @"As a CheckPoint User you can:
                            </br>+ Search for courses and appointments made by hosts.</br>  
                                 + Apply to courses and appointments.</br>
                                 + Track your own attendance history</br>
                            <br/>When becoming a User, an RFID tag will be sent to your address. Once your tag has been registered and sent,
                            you are ready to apply to courses and appointments";
        }

        public override void Load()
        {
            WireUpEvents();
        }
    }
}
