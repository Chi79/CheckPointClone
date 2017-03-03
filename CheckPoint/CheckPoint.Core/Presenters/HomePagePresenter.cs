using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointPresenters.Bases;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;

namespace CheckPointPresenters.Presenters
{
    public class HomePagePresenter : PresenterBase
    {
        private readonly IHomePageView _homePageView;

        public HomePagePresenter(IHomePageView homepageView)
        {
            _homePageView = homepageView;
            _homePageView.RedirectToLogin += _homePageView_OnLoginButtonClicked;
            _homePageView.RedirectToRegister += _homePageView_OnRegisterButtonClicked;
        }

        private void _homePageView_OnRegisterButtonClicked(object sender, EventArgs e)
        {
            _homePageView.RedirectToClientRegisterView();           
        }

        private void _homePageView_OnLoginButtonClicked(object sender, EventArgs e)
        {
            _homePageView.RedirectToLoginView();           
        }
    }
}
