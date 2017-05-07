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

            get { return CourseCreator.CourseName; }

        }

        public string Description
        {

            get { return CourseCreator.Description; }

        }

        public string IsPrivate
        {

            get { return CourseCreator.IsPrivate; }

        }

        public string IsObligatory
        {

            get { return CourseCreator.IsObligatory; }

        }

        public string Message
        {

            get { return MessagePanel.Message; }

            set { MessagePanel.Message= value; }

        }


        public bool CreateButtonVisible
        {

            set { btnCreateCourse.Visible = value; }

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

        public bool MessagePanelVisible
        {

            set { MessagePanel.MessagePanelVisible = value; }

        }

        public bool CreateCourseButtonVisible
        {

            set { btnCreateCourse.Visible = value; } 

        }

        public void RedirectToHostCoursesPage()
        {

            Response.Redirect("HostCoursesView.aspx");

        }

        public void RedirectToChangesSavedCoursePage()
        {

            Response.Redirect("ChangesSavedCourseView.aspx");

        }


        public event EventHandler<EventArgs> CreateNewCourse;
        public event EventHandler<EventArgs> YesButtonClicked;
        public event EventHandler<EventArgs> NoButtonClicked;
        public event EventHandler<EventArgs> ContinueButtonClicked;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override void HookUpEvents()
        {

            MessagePanel.YesButtonClicked += OnMessagePanel_YesButtonClicked;
            MessagePanel.NoButtonClicked += OnMessagePanel_NoButtonClicked;
            MessagePanel.ReloadPage += OnMessagePanel_ReloadPage;
        }

        private void OnMessagePanel_ReloadPage(object sender, EventArgs e)
        {
            if (ContinueButtonClicked != null)
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

        protected void btnCreateCourse_Click(object sender, EventArgs e)
        {
            if(CreateNewCourse != null)
            {
                CreateNewCourse(this, EventArgs.Empty);
            }
        }
    }
}