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
    public partial class ChangesSavedCourseView : ViewBase<ChangesSavedCoursePresenter> , IChangesSavedCourseView
    {
        public string Message
        {

            set { lblMessage.Text = value; }

        }

        public string Heading
        {

            set { lblHeading.Text = value; }

        }

        public void RedirectToCoursesView()
        {

            Response.Redirect("HostCoursesView.aspx");

        }

        public event EventHandler<EventArgs> BackToCoursesViewButtonClicked;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnBackToCoursessView_Click(object sender, EventArgs e)
        {
            if (BackToCoursesViewButtonClicked != null)
            {

                BackToCoursesViewButtonClicked(this, EventArgs.Empty);

            }
        }
    }
}