﻿using System;
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
    public partial class CreateAppointmentView : ViewBase<CreateAppointmentPresenter> , ICreateAppointmentView
    {
        public string CourseId
        {
            get { return txtCourseId.Text; }
        }
        public string AppointmentName
        {
            get { return txtAppointmentName.Text; }
        }

        public string Date
        {
            get { return txtDate.Text; }
        }

        public string Description
        {
            get { return txtAppointmentDescription.Text; }
        }

        public string StartTime
        {
            get { return txtStartTime.Text; }
        }
        public string EndTime
        {
            get { return txtEndTime.Text; }
        }

        public string IsCancelled
        {
            get { return ddlIsCancelled.SelectedValue; }
        }

        public string IsObligatory
        {
            get { return ddlIsObligatory.SelectedValue; }
        }

        public string Message
        {
            get { return lblMessage.Text; }

            set { lblMessage.Text = value; }
        }

        public string PostalCode
        {
            get { return txtPostalCode.Text; }
        }

        public string Address
        {
            get { return txtAddress.Text; }
        }

        public string UserName
        {
            get { return txtUserName.Text; }
        }
        public bool ContinueButtonVisible { set { btnContinue.Visible = value; } }
        public bool CreateButtonVisible { set { btnCreateAppointment.Visible = value; } }

        public void RedirectAfterClickEvent()
        {
            Response.Redirect("CreateAppointmentView.aspx");
        }

        public event EventHandler<EventArgs> CreateNewAppointment;
        public event EventHandler<EventArgs> Continue;

        protected void Page_Load(object sender, EventArgs e)
        {
          //TODO
        }

        protected void btnCreateAppointment_Click(object sender, EventArgs e)
        {
            if(CreateNewAppointment != null)
            {
                CreateNewAppointment(this, EventArgs.Empty);
            }
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            if(Continue != null)
            {
                Continue(this, EventArgs.Empty);
            }
        }
    }
}