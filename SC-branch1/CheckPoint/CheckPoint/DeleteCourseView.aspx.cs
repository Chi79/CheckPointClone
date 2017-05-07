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
    public partial class DeleteCourseView : ViewBase<DeleteCoursePresenter> , IDeleteCourseView
    {

        public string CourseName
        {

            set { CourseCreator.CourseName = value; }

        }
        public string Description
        {

            set { CourseCreator.Description = value; }

        }
        public string IsPrivate
        {

            set { CourseCreator.IsPrivate = value; }

        }
        public string IsObligatory
        {

            set { CourseCreator.IsObligatory = value; }

        }


        public string Message
        {
            get { return MessagePanel.Message; }
            set { MessagePanel.Message = value; }
        }

        public bool CourseNameReadonly
        {
            set { CourseCreator.CourseNameReadonly = value; }
        }

        public bool DescriptionReadonly
        {
            set { CourseCreator.DescriptionReadonly = value; }
        }

        public bool IsPrivateEnabled
        {
            set { CourseCreator.IsPrivateEnabled = value; }
        }

        public bool IsObligatoryEnabled
        {
            set { CourseCreator.IsObligatoryEnabled = value; }
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

        public bool DeleteCourseButtonVisible
        {
            set { btnDeleteCourse.Visible = value; }
        }

        public bool BackToCoursesPageButtonVisible
        {
            set
            {
                throw new NotImplementedException();
            }
        }

        public void RedirectToCoursesPage()
        {

            Response.Redirect("HostCoursesView.aspx");

        }

        public void RedirectToAppointmentsView()
        {

            Response.Redirect("HostHomeView.aspx");

        }

        public void RedirectToManageCourseView()
        {

            Response.Redirect("ManageCourseView.aspx");

        }

        public void RedirectAfterClick()
        {

            Response.Redirect("DeleteCourseView.aspx");

        }

        public void RedirectToInvalidNavigationView()
        {

            Response.Redirect("InvalidNavigationView.aspx");

        }

        public void RedirectToChangesSavedCoursePage()
        {

            Response.Redirect("ChangesSavedCourseView.aspx");

        }

        public event EventHandler<EventArgs> DeleteCourseButtonClicked;
        public event EventHandler<EventArgs> YesButtonClicked;
        public event EventHandler<EventArgs> NoButtonClicked;
        public event EventHandler<EventArgs> BackToCoursesPageClicked;
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
           if(ContinueButtonClicked != null)
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

        protected void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            if(DeleteCourseButtonClicked != null)
            {
                DeleteCourseButtonClicked(this, EventArgs.Empty);
            }
        }
    }
}