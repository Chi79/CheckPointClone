using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelViewPresenter.Core.Presentation.StartPage;
using ModelViewPresenter.Core.Presentation;

namespace ModelViewPresenterIOC
{
    public partial class Default : ViewPageBase<StartPagePresenter> , IStartPageView
    {
        public string Heading
        {
            get { return txtHeading.Text; }
            set { txtHeading.Text = value; }
        }
        public string Message
        {
            get { return txtMessage.Text; }
            set { txtMessage.Text = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}