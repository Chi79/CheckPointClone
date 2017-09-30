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
   
    public partial class ExpiredAppointmentsView : ViewBase<ExpiredAppointmentsPresenter> , IExpiredAppointmentsView
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


        public void RedirectToCoursesView()
        {

            Response.Redirect("HostCoursesView.aspx");

        }

        public void RedirectToViewAttendaceForAppointmentsView()
        {

            Response.Redirect("RecordedAppointmentAttendanceView.aspx");

        }


        public event EventHandler<EventArgs> RowSelected;
        public event EventHandler<EventArgs> SortColumnsByPropertyAscending;
        public event EventHandler<EventArgs> SortColumnsByPropertyDescending;
        public event EventHandler<EventArgs> ViewCoursesButtonClicked;
        public event EventHandler<EventArgs> ViewAttendancesForAppointmentButtonClicked;
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


        protected void btnViewCourses_Click(object sender, EventArgs e)
        {
            if (ViewCoursesButtonClicked != null)
            {
                ViewCoursesButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnViewAttendancesForAppointment_Click(object sender, EventArgs e)
        {

            if(ViewAttendancesForAppointmentButtonClicked != null)
            {
                ViewAttendancesForAppointmentButtonClicked(this, EventArgs.Empty);
            }

        }
    }
}