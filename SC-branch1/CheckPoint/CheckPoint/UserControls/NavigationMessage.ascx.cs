using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckPoint.Views.UserControls
{
    public partial class NavigationMessage : System.Web.UI.UserControl
    {
        public string Message
        {
            get { return lblNavigationMessage.Text; }

            set { lblNavigationMessage.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}