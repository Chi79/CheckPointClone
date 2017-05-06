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
    public partial class ChangesSavedView : ViewBase<ChangesSavedPresenter> , IChangesSavedView
    {
        public string Message
        {

            set { lblMessage.Text = value; }

        }

        public string Heading
        {

            set { lblHeading.Text = value; }

        }

        public void RedirectToAppointmentsView()
        {

            Response.Redirect("HostHomeView.aspx");

        }

        public event EventHandler<EventArgs> BackToAppointmentsViewButtonClicked;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBackToAppointmentsView_Click(object sender, EventArgs e)
        {
            if(BackToAppointmentsViewButtonClicked != null)
            {

                BackToAppointmentsViewButtonClicked(this, EventArgs.Empty);

            }
        }
    }
}