using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CheckPointCommon.ViewInterfaces;
using CheckPointPresenters.Bases;
using CheckPointPresenters.Presenters;
using CheckPoint.Views;
using CheckPoint.Views.UserControls;

namespace CheckPoint.Views
{
    public partial class ApplyToCourseView : ViewBase<ApplyToCoursePresenter>, IApplyToCourseView
    {
    

        public override void HookUpEvents()
        {        
            ApplyToCourseAppGridHeader.SortColumnsByPropertyAscending += OnSortColumnsByPropertyAscending;
            ApplyToCourseAppGridHeader.SortColumnsByPropertyDescending += OnSortColumnsByPropertyDescending;

        }

 
        public string Message
        {

            set { lblMessage.Text = value; }

        }

        public IEnumerable<object> SetDataSource
        {

            set { ApplyToCourseGrid.SetDataSource = value; }

        }

        public IEnumerable<object> SetDataSource2
        {

            set { ApplyToCourseHeader.SetDataSource2 = value; }

        }

        public IEnumerable<object> SetDataSourceAppointmentHeader
        {

            set { ApplyToCourseAppGridHeader.SetDataSource2 = value; }

        }

        public IEnumerable<object> SetDataSourceAppointmentData
        {

            set { ApplyToCourseAppGrid.SetDataSource = value; }

        }

        public bool AppliedToAttendCourseMessageVisible
        {
            set
            {
                ApplicationToCourseSuccessful.Visible = value;
            }
        }

        public void BindData()
        {

            ApplyToCourseGrid.DataBind();
            ApplyToCourseHeader.DataBind();
            ApplyToCourseAppGrid.DataBind();
            ApplyToCourseAppGridHeader.DataBind();

        }


        public event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        public event EventHandler<EventArgs> SortColumnsByPropertyDescending;

        public event EventHandler<EventArgs> ApplyToCourse_Click;
        public event EventHandler<EventArgs> Cancel_Click;
        public event EventHandler<EventArgs> Yes_Click;
        public event EventHandler<EventArgs> No_Click;
        public event EventHandler<EventArgs> Continue_Click;

        private void OnSortColumnsByPropertyDescending(object sender, EventArgs e)
        {
            if (SortColumnsByPropertyDescending != null)
            {
                SortColumnsByPropertyDescending(this, EventArgs.Empty);
            }
        }

        private void OnSortColumnsByPropertyAscending(object sender, EventArgs e)
        {
            if (SortColumnsByPropertyAscending != null)
            {
                SortColumnsByPropertyAscending(this, EventArgs.Empty);
            }
        }


        public void RedirectToFindPublicCourses()
        {
            Response.Redirect("FindCoursesView.aspx");
        }

        public bool BtnYesVisible {
            set
            {
               btnYes.Visible = value;
            }
        }

        public bool BtnNoVisible
        {
            set
            {
                btnNo.Visible = value;
            }
        }

        public bool BtnCancelVisible
        {
            set
            {
                btnCancel.Visible = value;
            }
        }

        public bool BtnApplyToCourseVisible
        {
            set
            {
                btnApplyToCourse.Visible = value;
            }
        }
        public bool BtnContinueVisible
        {
            set
            {
                btnContinue.Visible = value;
            }
        }
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            if (Continue_Click != null)
            {
                Continue_Click(this, EventArgs.Empty);
            }
        }
        protected void btnApplyToCourse_Click(object sender, EventArgs e)
        {
            if (ApplyToCourse_Click != null)
            {
                ApplyToCourse_Click(this, EventArgs.Empty);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Cancel_Click != null)
            {
                Cancel_Click(this, EventArgs.Empty);
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            if (Yes_Click != null)
            {
                Yes_Click(this, EventArgs.Empty);
            }
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            if (No_Click != null)
            {
                No_Click(this, EventArgs.Empty);
            }
        }
    }
}

       
       

      
