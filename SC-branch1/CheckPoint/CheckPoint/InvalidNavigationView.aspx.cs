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
    public partial class InvalidNavigationView : ViewBase<InvalidNavigationPresenter> , IInvalidNavigationView
    {
        public string Message
        {
            set {NavigationMessage.Message = value; }
        }

        public void RedirectToCoursesView()
        {

            Response.Redirect("HostCoursesView.aspx");

        }

        public event EventHandler<EventArgs> BackToCoursesViewButtonClicked;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBackToCoursesView_Click(object sender, EventArgs e)
        {
            if(BackToCoursesViewButtonClicked != null)
            {
                BackToCoursesViewButtonClicked(this, EventArgs.Empty);
            }
        }
    }
}