﻿using System;
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
        public event EventHandler<EventArgs> RowSelected;
        public event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        public event EventHandler<EventArgs> SortColumnsByPropertyDescending;
        public event EventHandler<EventArgs> CreateAppointmentButtonClicked;
        public event EventHandler<EventArgs> ManageAppointmentButtonClicked;
        public event EventHandler<EventArgs> ManageAttendanceButtonClicked;
        public event EventHandler<EventArgs> CreateReportButtonClicked;
        public event EventHandler<EventArgs> ViewCoursesButtonClicked;
        public event EventHandler<EventArgs> AddSelectedAppointmentToCourseButtonClicked;


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
        public int? SessionAppointmentId
        {
            get { return (int)Session["AppointmentId"]; }
            set { Session["AppointmentId"] = value; }
        }

        public bool AddAppointmentToCourseStatus
        {
            get { return (bool)Session["AddingAppointmentToCourse"]; }
            set { Session["AddingAppointmentToCourse"] = value; }
        }

        public int? SessionRowIndex
        {
            get { return (int)Session["MyRowIndex"]; }
            set { Session["MyRowIndex"] = value; }
        }

        public string ColumnName
        {
            get { return Session["MySortExpression"].ToString(); }
            set { Session["MySortExpression"] = value; }
        }

        public string LoggedInClient
        {
            get { return Session["LoggedInClient"].ToString(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public override void HookUpEvents()
        {
            AppointmentGridView.RowSelected += GridView_RowSelected1;
            AppointmentGridViewHeader.SortColumnsByPropertyAscending += OnSortColumnsByPropertyAscending;
            AppointmentGridViewHeader.SortColumnsByPropertyDescending += OnSortColumnsByPropertyDescending;
            AppointmentGridViewHeader.RowSelected += OnAppointmentGridViewHeader_RowSelected;
        }

        private void OnAppointmentGridViewHeader_RowSelected(object sender, EventArgs e)
        {
            if (RowSelected != null)
            {
                RowSelected(this, EventArgs.Empty);
            }
        }

        private void OnSortColumnsByPropertyDescending(object sender, EventArgs e)
        {
            if(SortColumnsByPropertyDescending != null)
            {
                SortColumnsByPropertyDescending(this, EventArgs.Empty);
            }
        }

        private void OnSortColumnsByPropertyAscending(object sender, EventArgs e)
        {
            if(SortColumnsByPropertyAscending != null)
            {
                SortColumnsByPropertyAscending(this, EventArgs.Empty);
            }
        }

        private void GridView_RowSelected1(object sender, EventArgs e)
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

        protected void createAppointment_Click(object sender, ImageClickEventArgs e)
        {
            if (CreateAppointmentButtonClicked != null)
            {
                CreateAppointmentButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void manageAppointment_Click(object sender, ImageClickEventArgs e)
        {
            if (ManageAppointmentButtonClicked != null)
            {
                ManageAppointmentButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void manageattendance_Click(object sender, ImageClickEventArgs e)
        {
            if(ManageAttendanceButtonClicked != null)
            {
                ManageAttendanceButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void createreport_Click(object sender, ImageClickEventArgs e)
        {
            if(CreateReportButtonClicked != null)
            {
                CreateReportButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void ViewCourses_Click(object sender, ImageClickEventArgs e)
        {
            if (ViewCoursesButtonClicked != null)
            {
                ViewCoursesButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnAddSelectedAppointmentToCourse_Click(object sender, ImageClickEventArgs e)
        {
            if (AddSelectedAppointmentToCourseButtonClicked != null)
            {
                AddSelectedAppointmentToCourseButtonClicked(this, EventArgs.Empty);
            }
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
    }
}