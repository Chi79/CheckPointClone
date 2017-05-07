using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckPoint.Views.UserControls
{
    public partial class MessagePanel : System.Web.UI.UserControl
    {
        public string Message
        {
            get { return lblMessage.Text; }

            set { lblMessage.Text = value; }
        }

        public bool MessagePanelVisible
        {

            set { MessageDisplayPanel.Visible = value; }

        }

        public bool MessageVisible
        {

            set { lblMessage.Visible = value; }

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

        public event EventHandler<EventArgs> YesButtonClicked;
        public event EventHandler<EventArgs> NoButtonClicked;
        public event EventHandler<EventArgs> ReloadPage;

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
    }
}