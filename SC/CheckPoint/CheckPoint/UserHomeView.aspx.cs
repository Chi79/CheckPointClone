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
    public partial class UserHomeView : ViewBase<UserHomePresenter>, IUserHomeView
    {

        public string Message
        {

            set { lblMessage.Text = value; }

        }

        public IEnumerable<object> SetDataSource
        {

            set { AppointmentGridView.SetDataSource = value; }

        }

        public IEnumerable<object> SetDataSource2
        {
            set { AppointmentGridViewHeader.SetDataSource2 = value; }
        }

        public int SelectedRowIndex
        {

            get { return AppointmentGridView.SelectedRowIndex; }
            set { AppointmentGridView.SelectedRowIndex = value; }

        }

        public object SelectedRowValueDataKey
        {

            get { return AppointmentGridView.SelectedRowValueDataKey; }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override void HookUpEvents()
        {

            AppointmentGridView.RowSelected += OnRowSelected;
            AppointmentGridViewHeader.SortColumnsByPropertyAscending += OnSortColumnsByPropertyAscending;
            AppointmentGridViewHeader.SortColumnsByPropertyDescending += OnSortColumnsByPropertyDescending;
            AppointmentGridViewHeader.RowSelected += OnAppointmentGridViewHeader_Selected;

        }

        public void BindData()
        {

            AppointmentGridViewHeader.DataBind();

            AppointmentGridView.DataBind();

        }


        public void RedirectToFindAppointmentsView()
        {

            Response.Redirect("FindAppointmentsView.aspx");

        }

        public void RedirectToFindCoursesView()
        {

            Response.Redirect("FindCoursesView.aspx");

        }

        public void RedirectToViewCourses()
        {

            Response.Redirect("UserCoursesView.aspx");

        }

        public event EventHandler<EventArgs> RowSelected;
        public event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        public event EventHandler<EventArgs> SortColumnsByPropertyDescending; 
        public event EventHandler<EventArgs> ManageAttendanceButtonClicked;


        public event EventHandler<EventArgs> FindCoursesButtonClicked;
        public event EventHandler<EventArgs> FindAppointmentsButtonClicked;
        public event EventHandler<EventArgs> ViewCoursesButtonClicked;

        private void OnAppointmentGridViewHeader_Selected(object sender, EventArgs e)
        {
            if (RowSelected != null)
            {
                RowSelected(this, EventArgs.Empty);
            }
        }

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

        private void OnRowSelected(object sender, EventArgs e)
        {
            if (RowSelected != null)
            {
                RowSelected(this, EventArgs.Empty);
            }
        }


        protected void btnManageAttendance_Click(object sender, EventArgs e)
        {
            if (ManageAttendanceButtonClicked != null)
            {
                ManageAttendanceButtonClicked(this, EventArgs.Empty);
            }
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

        protected void btnViewCourses_Click1(object sender, EventArgs e)
        {

            if(ViewCoursesButtonClicked != null)
            {

                ViewCoursesButtonClicked(this, EventArgs.Empty);
            }

        }
    }
}