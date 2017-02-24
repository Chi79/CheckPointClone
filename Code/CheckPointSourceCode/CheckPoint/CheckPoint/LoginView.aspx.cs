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
    public partial class LoginView : ViewBase<LoginPresenter> , ILoginView
    {
        public string Message
        {
            set { lblMessage.Text = value; }

        }
        public string Password
        {
            get { return txtPassword.Text; }
        }
        public string Username
        {
            get { return txtUserName.Text; }
        }
        public event EventHandler<EventArgs> Login;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            if (Login != null)
            {
                Login(this, EventArgs.Empty);
            }
        }
        public void RedirectToUserHomePage()
        {
            Response.Redirect("UserHomeView.aspx");
        }
        public void RedirectToHostHomePage()
        {
            //TODO Response.Redirect();
        }
    }
}