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
        public void RedirectToCreateAppointment()
        {
            Response.Redirect("CreateAppointmentView.aspx");
        }
        public void RedirectToManageAppointment()
        {
            Response.Redirect("ManageSingleAppointmentView.aspx");
        }

        public event EventHandler<EventArgs> RowSelected;
        public event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        public event EventHandler<EventArgs> SortColumnsByPropertyDescending;
        public event EventHandler<EventArgs> CreateAppointmentButtonClicked;
        public event EventHandler<EventArgs> ManageCoursesButtonClicked;
        public event EventHandler<EventArgs> ManageAppointmentButtonClicked;
        public event EventHandler<EventArgs> ManageAttendanceButtonClicked;
        public event EventHandler<EventArgs> CreateReportButtonClicked;

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

        protected void btnManageAppointment_Click(object sender, EventArgs e)
        {
            if (ManageAppointmentButtonClicked != null)
            {
                ManageAppointmentButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnCreateAppointment_Click(object sender, EventArgs e)
        {
            if (CreateAppointmentButtonClicked != null)
            {
                CreateAppointmentButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnViewCourses_Click(object sender, EventArgs e)
        {
            if (ManageCoursesButtonClicked != null)
            {
                ManageCoursesButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnCreateReport_Click(object sender, EventArgs e)
        {
            if (CreateReportButtonClicked != null)
            {
                CreateReportButtonClicked(this, EventArgs.Empty);
            }
        }
    }
}