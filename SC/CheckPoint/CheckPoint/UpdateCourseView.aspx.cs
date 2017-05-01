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

    public partial class UpdateCourseView : ViewBase<UpdateCoursePresenter> , IUpdateCourseView
    {

       public string Message
       {

            get { return CourseCreator.Message; }
            set { CourseCreator.Message = value; }

       }
       public string CourseName
        {

            get { return CourseCreator.CourseName; }
            set { CourseCreator.CourseName = value; }

        }
       public string Description
        {

            get { return CourseCreator.Description; }
            set { CourseCreator.Description = value; }

        }
       public string IsPrivate
        {

            get { return CourseCreator.IsPrivate; }
            set { CourseCreator.IsPrivate = value; }

        }
        public string IsObligatory
        {

            get { return CourseCreator.IsObligatory; }
            set { CourseCreator.IsObligatory = value; }

        }


        public bool YesButtonVisible
        {

            set { btnYes.Visible = value; }

        }

        public bool NoButtonVisible
        {

            set { btnNo.Visible = value; }

        }

        public bool UpdateCourseButtonVisible
        {

            set { btnUpdateCourse.Visible = value; }

        }




        public void RedirectToManageCourseView()
        {

            Response.Redirect("ManageCourseView.aspx");

        }

        public event EventHandler<EventArgs> UpdateCourseButtonClicked;
        public event EventHandler<EventArgs> YesButtonClicked;
        public event EventHandler<EventArgs> NoButtonClicked;
   

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }



        protected void btnYes_Click(object sender, EventArgs e)
        {
            if(YesButtonClicked != null)
            {
                YesButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            if(NoButtonClicked != null)
            {
                NoButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnUpdateCourse_Click1(object sender, EventArgs e)
        {
            if(UpdateCourseButtonClicked != null)
            {
                UpdateCourseButtonClicked(this, EventArgs.Empty);
            }
        }
    }
}