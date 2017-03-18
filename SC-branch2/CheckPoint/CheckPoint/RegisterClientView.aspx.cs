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
    public partial class RegisterClientView : ViewBase<RegisterClientPresenter> , IRegisterClientView
    {
        public int ClientType { get { return ddlClientType.SelectedIndex; } }

        public string Email  { get { return txtEmail.Text; } }

        public string Firstname { get { return txtFirstName.Text; } }
    
        public string LastName { get { return txtLastName.Text; } }
   
        public string Message { get { return lblMessage.Text; } set { lblMessage.Text = value; } }
 
        public string Password { get { return txtPassword.Text; } }

        public string PhoneNumber { get { return txtPhoneNumber.Text; } }
  
        public string PostalCode { get { return txtPostalCode.Text; } }
   
        public string StreetAddress { get { return txtStreetAddress.Text; } }
      
        public string UserName { get { return txtUserName.Text; } }
        
        public event EventHandler<EventArgs> RegisterNewClient;

        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        protected void btnRegisterClient_Click(object sender, EventArgs e)
        {
            if(RegisterNewClient != null)
            {
                RegisterNewClient(this, EventArgs.Empty);
            }
        }
    }
}