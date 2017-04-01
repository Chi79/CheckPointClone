using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CheckPointPresenters.Bases;
using CheckPointCommon.ViewInterfaces;
using CheckPointPresenters.Presenters;

namespace CheckPoint.Views
{
    public partial class HostCoursesView : ViewBase<HostCoursesPresenter> , IHostCoursesView
    {

        public string Message
        {
            set { lblMessage.Text = value; }
        }

        public IEnumerable<object> SetDataSource
        {
            set { CourseGridView.SetDataSource = value; }
        }

        public IEnumerable<object> SetDataSource2
        {
            set { CourseGridViewHeader.SetDataSource2 = value; }
        }

        public int SelectedRowIndex
        {
            get { return CourseGridView.SelectedRowIndex; }
            set { CourseGridView.SelectedRowIndex = value; }
        }

        public object SelectedRowValueDataKey
        {

            get { return CourseGridView.SelectedRowValueDataKey; }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override void HookUpEvents()
        {
            CourseGridView.RowSelected += OnRowSelected;
            CourseGridViewHeader.RowSelected += OnCourseGridViewHeader_RowSelected;
            CourseGridViewHeader.SortColumnsByPropertyDescending += OnSortColumnsByPropertyDescending;
            CourseGridViewHeader.SortColumnsByPropertyAscending += OnSortColumnsByPropertyAscending;
        }

        public void BindData()
        {
            CourseGridView.DataBind();
            CourseGridViewHeader.DataBind();
        }

        public void RedirectToCreateCourse()
        {
            Response.Redirect("CreateCourseView.aspx");
        }

        public void RedirectToManageCourse()
        {
            //TODO  Response.Redirect("ManageCourseView.aspx");
            this.Message = "bumbum!";
        }

        public void RedirectToAppointmentsView()
        {
            Response.Redirect("HostHomeView.aspx");
        }

        public event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        public event EventHandler<EventArgs> SortColumnsByPropertyDescending;
        public event EventHandler<EventArgs> RowSelected;
        public event EventHandler<EventArgs> CreateCourseButtonClicked;
        public event EventHandler<EventArgs> ManageCourseButtonClicked;
        public event EventHandler<EventArgs> ManageAttendanceButtonClicked;
        public event EventHandler<EventArgs> CreateReportButtonClicked;
        public event EventHandler<EventArgs> ViewAppointmentsButtonClicked;


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

        protected void manageattendance_Click(object sender, ImageClickEventArgs e)
        {
            if (ManageAttendanceButtonClicked != null)
            {
                ManageAttendanceButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void createreport_Click(object sender, ImageClickEventArgs e)
        {
            if (CreateReportButtonClicked != null)
            {
                CreateReportButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void managecourse_Click(object sender, ImageClickEventArgs e)
        {
            if (ManageCourseButtonClicked != null)
            {
                ManageCourseButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void createcourse_Click(object sender, ImageClickEventArgs e)
        {
            if (CreateCourseButtonClicked != null)
            {
                CreateCourseButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void ViewAppointments_Click(object sender, ImageClickEventArgs e)
        {
            if (ViewAppointmentsButtonClicked != null)
            {
                ViewAppointmentsButtonClicked(this, EventArgs.Empty);
            }
        }
    }
}