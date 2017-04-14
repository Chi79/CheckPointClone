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

            get { return CourseCreator.Message; }

            set { CourseCreator.Message= value; }

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

        public bool CreateCourseButtonVisible
        {

            set { btnCreateCourse.Visible = value; } 

        }



        public void RedirectToCoursesPage()
        {

            Response.Redirect("HostCoursesView.aspx");

        }


        public event EventHandler<EventArgs> CreateNewCourse;
        public event EventHandler<EventArgs> YesButtonClicked;
        public event EventHandler<EventArgs> NoButtonClicked;
       


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
    }
}