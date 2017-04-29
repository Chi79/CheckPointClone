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
    public partial class FindCoursesView : ViewBase<FindCoursesPresenter> , IFindCoursesView
    {

        public string Message
        {
            set { lblMessage.Text = value; }
        }

        public IEnumerable<object> SetDataSource
        {
            set { UserCourseGridView.SetDataSource = value; }
        }

        public IEnumerable<object> SetDataSource2
        {
            set { UserCourseGridViewHeader.SetDataSource2 = value; }
        }

        public int SelectedRowIndex
        {
            get { return UserCourseGridView.SelectedRowIndex; }
            set { UserCourseGridView.SelectedRowIndex = value; }
        }

        public object SelectedRowValueDataKey
        {

            get { return UserCourseGridView.SelectedRowValueDataKey; }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override void HookUpEvents()
        {
            UserCourseGridView.RowSelected += OnRowSelected;
            UserCourseGridViewHeader.RowSelected += OnCourseGridViewHeader_RowSelected;
            UserCourseGridViewHeader.SortColumnsByPropertyDescending += OnSortColumnsByPropertyDescending;
            UserCourseGridViewHeader.SortColumnsByPropertyAscending += OnSortColumnsByPropertyAscending;
        }

        public void BindData()
        {
            UserCourseGridView.DataBind();
            UserCourseGridViewHeader.DataBind();
        }

        public void RedirectToFindAppointmentsView()
        {

            Response.Redirect("FindAppointmentsView.aspx");

        }

        public void RedirectToApplyToCourseView()
        {
            Response.Redirect("ApplyToCourseView.aspx");
        }

        public event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        public event EventHandler<EventArgs> SortColumnsByPropertyDescending;
        public event EventHandler<EventArgs> RowSelected;

        public event EventHandler<EventArgs> FindPublicAppointmentsButtonClicked;
        public event EventHandler<EventArgs> ApplyToAttendCourseButtonClicked;

        private void OnSortColumnsByPropertyAscending(object sender, EventArgs e)
        {
            if (SortColumnsByPropertyAscending != null)
            {
                SortColumnsByPropertyAscending(this, EventArgs.Empty);
            }
        }

        private void OnSortColumnsByPropertyDescending(object sender, EventArgs e)
        {
            if (SortColumnsByPropertyDescending != null)
            {
                SortColumnsByPropertyDescending(this, EventArgs.Empty);
            }
        }

        private void OnCourseGridViewHeader_RowSelected(object sender, EventArgs e)
        {
            if (RowSelected != null)
            {
                RowSelected(this, EventArgs.Empty);
            }
        }

        private void OnRowSelected(object sender, EventArgs e)
        {
            if (RowSelected != null)
            {
                RowSelected(this, EventArgs.Empty);
            }
        }


        protected void btnApplyToAttendCourse_Click(object sender, EventArgs e)
        {

            if(ApplyToAttendCourseButtonClicked != null)
            {
                ApplyToAttendCourseButtonClicked(this, EventArgs.Empty);
            }

        }

        protected void btnFindPublicAppointments_Click(object sender, EventArgs e)
        {

            if(FindPublicAppointmentsButtonClicked != null)
            {
                FindPublicAppointmentsButtonClicked(this, EventArgs.Empty);
            }

        }
    }
}