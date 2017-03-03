using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CheckPointCommon.ViewInterfaces;
using CheckPointPresenters.Bases;
using CheckPointPresenters.Presenters;

namespace CheckPoint.Views
{
    public partial class HomePageView : ViewBase<HomePagePresenter> ,IHomePageView
    {
        public event EventHandler<EventArgs> RedirectToLogin;
        public event EventHandler<EventArgs> RedirectToRegister;
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            if(RedirectToLogin != null)
            {
                RedirectToLogin(this, EventArgs.Empty);
            }
        }

        protected void btnGetStarted_Click(object sender, EventArgs e)
        {
            if (RedirectToRegister != null)
            {
                RedirectToRegister(this, EventArgs.Empty);
            }
        }

        public void RedirectToLoginView()
        {
            HttpContext.Current.Response.Redirect("LoginView.aspx");
        }

        public void RedirectToClientRegisterView()
        {
            HttpContext.Current.Response.Redirect("RegisterClientView.aspx");
        }
    }
}