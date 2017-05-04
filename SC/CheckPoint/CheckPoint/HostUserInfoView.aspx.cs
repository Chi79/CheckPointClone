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
    public partial class HostUserInfoView : ViewBase<HostIUserInfoPresenter> , IHostUserInfoView
    {
        public string HostInfoHeading {  set { lblHostInfoHeading.Text = value; } }
        public string HostInfo { set { lblHostInfo.Text = value; } }
        public string UserInfoHeading { set { lblUserInfoHeading.Text = value; } }
        public string UserInfo { set { lblUserInfo.Text = value; } }


        public event EventHandler<EventArgs> RegisterNewHostClicked;
        public event EventHandler<EventArgs> BackToHomePageClicked;
        public event EventHandler<EventArgs> RegisterNewUserClicked;

        public void RedirectBackToHomePage()
        {
            Response.Redirect("HomePageView.aspx");
        }

        public void RedirectToRegisterHostPage()
        {
            Response.Redirect("RegisterHostView.aspx");
        }

        public void RedirectToRegisterUserPage()
        {
            Response.Redirect("RegisterUserView.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnBackToHomePage_Click(object sender, EventArgs e)
        {
            if (BackToHomePageClicked != null)
            {
                BackToHomePageClicked(this, EventArgs.Empty);
            }
        }


        protected void btnRegisterUser_Click(object sender, EventArgs e)
        {
            if (RegisterNewUserClicked != null)
            {
                RegisterNewUserClicked(this, EventArgs.Empty);
            }
        }

        protected void btnRegisterHost_Click(object sender, EventArgs e)
        {
            if (RegisterNewHostClicked != null)
            {
                RegisterNewHostClicked(this, EventArgs.Empty);
            }
        }
    }
}