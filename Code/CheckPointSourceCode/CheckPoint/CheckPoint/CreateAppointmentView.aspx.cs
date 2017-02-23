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
    public partial class CreateAppointmentView : ViewBase<CreateAppointmentPresenter> , ICreateAppointmentView
    {
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

        public string FromTime
        {
            get { return txtStartTime.Text; }
        }
        public string ToTime
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

        public string Private
        {
            get { return ddlIsPrivate.SelectedValue; }
        }

        public string StreetAddress
        {
            get { return txtStreetAddress.Text; }
        }

        public string UserName
        {
            get { return txtUserName.Text; }
        }

        public event EventHandler<EventArgs> CreateNewAppointment;

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
    }
}