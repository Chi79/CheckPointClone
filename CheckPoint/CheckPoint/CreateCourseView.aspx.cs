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
    public partial class CreateCourseView : ViewBase<CreateCoursePresenter> , ICreateCourseView
    {

        public string CourseName
        {
            get { return txtCourseName.Text; }
        }

        public string Description
        {
            get { return txtDescription.Text; }
        }

        public string IsPrivate
        {
            get { return ddlIsPrivate.SelectedValue; }
        }

        public bool ContinueButtonVisible
        {
            set { btnContinue.Visible = value; }
        }

        public bool CreateButtonVisible
        {
            set { btnCreateCourse.Visible = value; }
        }

        public bool YesButtonVisible
        {
            set { btnYes.Visible = value; }
        }

        public bool NoButtonVisible
        {
            set { btnNo.Visible = value; }
        }
        public string Message
        {
            get { return lblMessage.Text; }

            set { lblMessage.Text = value; }
        }

        public bool CreateCourseButtonVisible
        {
            set { btnCreateCourse.Visible = value; } 
        }

        public bool BackToHomePageButtonVisible
        {
            set { btnBackToHomePage.Visible = value; }
        }

        public bool AddNewAppointmentToCourseButtonVisible
        {
            set { btnAddNewAppointmentToCourseButton.Visible = value; }
        }

        public bool AddExistingAppointmentToCourseButtonVisible
        {
            set { btnAddExistingAppointmentToCourseButton.Visible = value; } 
        }

        public void RedirectAfterClickEvent()
        {
            Response.Redirect("CreateCourseView.aspx");
        }

        public void RedirectToHomePage()
        {
            Response.Redirect("HostCoursesView.aspx");
        }

        public void RedirectToAddNewAppointmentToCourse()
        {
            Response.Redirect("CreateAppointmentView.aspx");
        }

        public void RedirectToAddExistingAppointmentToCourse()
        {
            Response.Redirect("HostHomeView.aspx");
        }


        public event EventHandler<EventArgs> CreateNewCourse;
        public event EventHandler<EventArgs> Continue;
        public event EventHandler<EventArgs> YesButtonClicked;
        public event EventHandler<EventArgs> NoButtonClicked;
        public event EventHandler<EventArgs> BackToHomePageClicked;

        public event EventHandler<EventArgs> AddNewAppontmentToCourseClicked;
        public event EventHandler<EventArgs> AddExistingAppontmentToCourseClicked;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateCourse_Click(object sender, EventArgs e)
        {
            if(CreateNewCourse != null)
            {
                CreateNewCourse(this, EventArgs.Empty);
            }
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            if(NoButtonClicked != null)
            {
                NoButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            if(YesButtonClicked != null)
            {
                YesButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            if(Continue != null)
            {
                Continue(this, EventArgs.Empty);
            }
        }

        protected void btnBackToHomePage_Click(object sender, EventArgs e)
        {
            if(BackToHomePageClicked != null)
            {
                BackToHomePageClicked(this, EventArgs.Empty);
            }
        }

        protected void AddNewAppointmentToCourseButton_Click(object sender, EventArgs e)
        {
            if(AddNewAppontmentToCourseClicked != null)
            {
                AddNewAppontmentToCourseClicked(this, EventArgs.Empty);
            }
        }

        protected void AddExistingAppointmentToCourseButton_Click(object sender, EventArgs e)
        {
            if(AddExistingAppontmentToCourseClicked != null)
            {
                AddExistingAppontmentToCourseClicked(this, EventArgs.Empty);
            }
        }
    }
}