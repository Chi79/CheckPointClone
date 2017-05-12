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
    public partial class RegisterHostView : ViewBase<RegisterClientPresenter> , IRegisterClientView
    {
        public int ClientType { get { return 1; } }

        public string Email  { get { return txtEmail.Text; } }

        public string Firstname { get { return txtFirstName.Text; } }
    
        public string LastName { get { return txtLastName.Text; } }
   
        public string Message { get { return MessagePanel.Message; } set { MessagePanel.Message = value; } }
 
        public string Password { get { return txtPassword.Text; } }

        public string PhoneNumber { get { return txtPhoneNumber.Text; } }
  
        public string PostalCode { get { return txtPostalCode.Text; } }
   
        public string StreetAddress { get { return txtStreetAddress.Text; } }
      
        public string UserName { get { return txtUserName.Text; } }

        public bool LoginButtonVisible
        {

            set { MessagePanel.LoginButtonVisible = value; }

        }

        public bool YesButtonVisible
        {

            set { MessagePanel.YesButtonVisible = value; }

        }

        public bool NoButtonVisible
        {

            set { MessagePanel.NoButtonVisible = value; }

        }

        public bool ContinueButtonVisible
        {

            set { MessagePanel.ContinueButtonVisible = value; }

        }

        public bool RegisterButtonVisible
        {

            set { btnRegisterClient.Visible = value; }

        }

        public bool MessagePanelVisible
        {

            set { MessagePanel.MessagePanelVisible = value; }

        }

        public event EventHandler<EventArgs> RegisterNewClient;
        public event EventHandler<EventArgs> BackToHomePageClicked;
        public event EventHandler<EventArgs> GoToLoginClicked;

        public event EventHandler<EventArgs> YesButtonClicked;
        public event EventHandler<EventArgs> NoButtonClicked;
        public event EventHandler<EventArgs> ContinueButtonClicked;

        public void RedirectBackToHomePage()
        {

            Response.Redirect("HomePageView.aspx");

        }

        public void RedirectToLogin()
        {

            Response.Redirect("LoginView.aspx");

        }

        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        public override void HookUpEvents()
        {

            MessagePanel.YesButtonClicked += OnMessagePanel_YesButtonClicked;
            MessagePanel.NoButtonClicked += OnMessagePanel_NoButtonClicked;
            MessagePanel.ReloadPage += OnMessagePanel_ReloadPage;
            MessagePanel.LoginButtonClicked += OnMessagePanel_LoginButtonClicked;

        }

        private void OnMessagePanel_LoginButtonClicked(object sender, EventArgs e)
        {

            if(GoToLoginClicked != null)
            {
                GoToLoginClicked(this, EventArgs.Empty);
            }

        }

        private void OnMessagePanel_ReloadPage(object sender, EventArgs e)
        {

           if(ContinueButtonClicked != null)
            {
                ContinueButtonClicked(this, EventArgs.Empty);
            }

        }

        private void OnMessagePanel_NoButtonClicked(object sender, EventArgs e)
        {
           
            if (NoButtonClicked != null)
            {
                NoButtonClicked(this, EventArgs.Empty);
            }

        }

        private void OnMessagePanel_YesButtonClicked(object sender, EventArgs e)
        {

            if (YesButtonClicked != null)
            {
                YesButtonClicked(this, EventArgs.Empty);
            }

        }

        protected void btnRegisterClient_Click(object sender, EventArgs e)
        {

            if(RegisterNewClient != null)
            {
                RegisterNewClient(this, EventArgs.Empty);
            }

        }

        protected void btnBackToHomePage_Click(object sender, EventArgs e)
        {

            if(BackToHomePageClicked != null)
            {
                BackToHomePageClicked(this, EventArgs.Empty);
            }

        }

        protected void btnGoToLogin_Click(object sender, EventArgs e)
        {

            if(GoToLoginClicked != null)
            {
                GoToLoginClicked(this, EventArgs.Empty);
            }

        }
    }
}