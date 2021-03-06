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

        public string Message
        {

            set { MessagePanel.Message = value; }

        }

        public bool MessagePanelVisible
        {

            set { MessagePanel.MessagePanelVisible = value; }

        }
        public bool ContinueButtonVisible
        {

            set { MessagePanel.ContinueButtonVisible = value; }

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
            AppointmentGridView.AppointmentRowSelected += GridView_RowSelected;
            AppointmentGridViewHeader.SortColumnsByPropertyAscending += OnSortColumnsByPropertyAscending;
            AppointmentGridViewHeader.SortColumnsByPropertyDescending += OnSortColumnsByPropertyDescending;
            AppointmentGridViewHeader.AppointmentRowSelected += OnAppointmentGridViewHeader_RowSelected;

            MessagePanel.ReloadPage += OnMessagePanel_ReloadPage;
        }

        private void OnMessagePanel_ReloadPage(object sender, EventArgs e)
        {
            if(ContinueButtonClicked != null)
            {
                ContinueButtonClicked(this, EventArgs.Empty);
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
     
        public event EventHandler<EventArgs> ViewCoursesButtonClicked;
        public event EventHandler<EventArgs> AddSelectedAppointmentToCourseButtonClicked;
        public event EventHandler<EventArgs> ContinueButtonClicked;

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