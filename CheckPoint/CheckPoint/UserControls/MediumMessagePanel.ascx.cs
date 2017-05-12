using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckPoint.Views.UserControls
{
    public partial class MediumMessagePanel : System.Web.UI.UserControl
    {
        public string Message
        {
            get { return lblMediumMessage.Text; }

            set { lblMediumMessage.Text = value; }
        }

        public bool MessagePanelVisible
        {

            set { MediumMessageDisplayPanel.Visible = value; }

        }

        public bool MessageVisible
        {

            set { lblMediumMessage.Visible = value; }

        }

        public bool YesButtonVisible
        {

            set { btnYes.Visible = value; }

        }

        public bool NoButtonVisible
        {

            set { btnNo.Visible = value; }

        }

        public bool ContinueButtonVisible
        {

            set { btnContinue.Visible = value; }

        }

        public bool LoginButtonVisible
        {

            set { btnLogin.Visible = value; }

        }

        public bool BackButtonVisible
        {

            set { btnBackToFindAppointmentsMedium.Visible = value; }

        }

        public event EventHandler<EventArgs> YesButtonClicked;
        public event EventHandler<EventArgs> NoButtonClicked;
        public event EventHandler<EventArgs> ReloadPage;
        public event EventHandler<EventArgs> LoginButtonClicked;
        public event EventHandler<EventArgs> BackButtonClicked;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        protected void btnYes_Click(object sender, EventArgs e)
        {
            if (YesButtonClicked != null)
            {
                YesButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            if (NoButtonClicked != null)
            {
                NoButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            if (ReloadPage != null)
            {
                ReloadPage(this, EventArgs.Empty);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(LoginButtonClicked != null)
            {
                LoginButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnBackToFindAppointments_Click(object sender, EventArgs e)
        {
            if(BackButtonClicked != null)
            {
                BackButtonClicked(this, EventArgs.Empty);
            }
        }
    }
}