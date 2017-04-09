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
   
    public partial class HostHomeView : ViewBase<HostHomePresenter> , IHostHomeView
    {

        public string Message
        {
            set { lblMessage.Text = value; }
        }

        public IEnumerable<object> SetDataSource
        {
            set {  AppointmentGridView.SetDataSource = value; }
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
 
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public override void HookUpEvents()
        {
            AppointmentGridView.RowSelected += GridView_RowSelected;
            AppointmentGridViewHeader.SortColumnsByPropertyAscending += OnSortColumnsByPropertyAscending;
            AppointmentGridViewHeader.SortColumnsByPropertyDescending += OnSortColumnsByPropertyDescending;
            AppointmentGridViewHeader.RowSelected += OnAppointmentGridViewHeader_RowSelected;
        }

        public void BindData()
        {

            AppointmentGridView.DataBind();
            AppointmentGridViewHeader.DataBind();

        }
        public object SelectedRowValueDataKey
        {

            get { return AppointmentGridView.SelectedRowValueDataKey; }

        }

        public bool ViewCoursesButtonVisible
        {

            set { btnViewCourses.Visible = value; }

        }

        public bool CreateAppointmentButtonVisible
        {

            set { btnCreateAppointment.Visible = value; }

        }

        public bool ManageAppointmentButtonVisible
        {

            set { btnManageAppointment.Visible = value; }

        }

        public bool CreateReportButtonVisible
        {

            set { btnCreateReport.Visible = value; }

        }

        public bool ManageAttendanceButtonVisible
        {

            set { btnManageAttendance.Visible = value; }

        }

        public bool AddSelectedAppointmenButtonVisible
        {

            set { btnAddSelectedAppointmentToCourse.Visible = value; }

        }

        public void RedirectToCreateAppointment()
        {

            Response.Redirect("CreateAppointmentView.aspx");

        }

        public void RedirectToManageAppointment()
        {

            Response.Redirect("ManageSingleAppointmentView.aspx");

        }

        public void RedirectToCoursesView()
        {

            Response.Redirect("HostCoursesView.aspx");

        }

        public void RedirectToAddSelectedAppointmenToCourseView()
        {

            Response.Redirect("AddSelectedAppointmentToCourseView.aspx");

        }


        public event EventHandler<EventArgs> RowSelected;
        public event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        public event EventHandler<EventArgs> SortColumnsByPropertyDescending;
        public event EventHandler<EventArgs> CreateAppointmentButtonClicked;
        public event EventHandler<EventArgs> ManageAppointmentButtonClicked;
        public event EventHandler<EventArgs> ManageAttendanceButtonClicked;
        public event EventHandler<EventArgs> CreateReportButtonClicked;
        public event EventHandler<EventArgs> ViewCoursesButtonClicked;
        public event EventHandler<EventArgs> AddSelectedAppointmentToCourseButtonClicked;


        private void OnAppointmentGridViewHeader_RowSelected(object sender, EventArgs e)
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

        private void GridView_RowSelected(object sender, EventArgs e)
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


        protected void btnAddSelectedAppointmentToCourse_Click1(object sender, EventArgs e)
        {
            if (AddSelectedAppointmentToCourseButtonClicked != null)
            {
                AddSelectedAppointmentToCourseButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnCreateReport_Click(object sender, EventArgs e)
        {
            if (CreateReportButtonClicked != null)
            {
                CreateReportButtonClicked(this, EventArgs.Empty);
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
            if (ViewCoursesButtonClicked != null)
            {
                ViewCoursesButtonClicked(this, EventArgs.Empty);
            }
        }
    }
}