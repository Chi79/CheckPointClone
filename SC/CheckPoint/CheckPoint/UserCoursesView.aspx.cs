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
    public partial class UserCoursesView : ViewBase<UserCoursesPresenter> , IUserCoursesView
    {
        public int SelectedRowIndex
        {
            get { return CourseGridView.SelectedRowIndex; }
            set { CourseGridView.SelectedRowIndex = value; }
        }

        public IEnumerable<object> SetDataSource
        {
            set { CourseGridView.SetDataSource = value; }
        }

        public IEnumerable<object> SetDataSource2
        {
            set { CourseGridViewHeader.SetDataSource2 = value; }
        }

        public object SelectedRowValueDataKey
        {
            get { return CourseGridView.SelectedRowValueDataKey; }

        }

        public override void HookUpEvents()
        {

            CourseGridView.RowSelected += OnRowSelected;
            CourseGridViewHeader.SortColumnsByPropertyAscending += OnSortColumnsByPropertyAscending;
            CourseGridViewHeader.SortColumnsByPropertyDescending += OnSortColumnsByPropertyDescending;
            CourseGridViewHeader.RowSelected += OnAppointmentGridViewHeader_Selected;

        }

        private void OnSortColumnsByPropertyAscending(object sender, EventArgs e)
        {
            if(SortColumnsByPropertyAscending != null)
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

        private void OnAppointmentGridViewHeader_Selected(object sender, EventArgs e)
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

        public event EventHandler<EventArgs> RowSelected;
        public event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        public event EventHandler<EventArgs> SortColumnsByPropertyDescending;
        public event EventHandler<EventArgs> ManageAttendanceButtonClicked;
        public event EventHandler<EventArgs> FindAppointmentsButtonClicked;
        public event EventHandler<EventArgs> FindCoursesButtonClicked;
        public event EventHandler<EventArgs> ViewAppointmentsButtonClicked;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnViewAppointments_Click(object sender, EventArgs e)
        {
            if(ViewAppointmentsButtonClicked != null)
            {
                ViewAppointmentsButtonClicked(this, EventArgs.Empty);
            }
        }

        public void BindData()
        {
            CourseGridViewHeader.BindData();
            CourseGridView.BindData();
        }

        public void RedirectToFindCoursesView()
        {
            Response.Redirect("FindCoursesView.aspx");
        }

        public void RedirectToFindAppointmentsView()
        {
            Response.Redirect("FindAppointmentsView.aspx");
        }

        public void RedirectToViewAppointments()
        {
            Response.Redirect("UserHomeView.aspx");
        }

        protected void btnFindAppointments_Click(object sender, EventArgs e)
        {
            if(FindAppointmentsButtonClicked != null)
            {
                FindAppointmentsButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnFindCourses_Click(object sender, EventArgs e)
        {
            if(FindCoursesButtonClicked != null)
            {
                FindCoursesButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnManageAttendance_Click(object sender, EventArgs e)
        {
            if(ManageAttendanceButtonClicked != null)
            {
                ManageAttendanceButtonClicked(this, EventArgs.Empty);
            }
        }
    }
}