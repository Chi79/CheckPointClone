using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckPoint.Views.UserControls
{

    public partial class AppointmentCreator : System.Web.UI.UserControl
    {

        public string AppointmentName
        {
            get { return txtAppointmentName.Text; }
            set { txtAppointmentName.Text = value; }
        }

        public string Description
        {
            get { return txtAppointmentDescription.Text; }
            set { txtAppointmentDescription.Text = value; }
        }

        public string Date
        {
            get { return txtDate.Text; }
            set { txtDate.Text = value; }
        }

        public string StartTime
        {
            get { return txtStartTime.Text; }
            set { txtStartTime.Text = value; }
        }
        public string EndTime
        {
            get { return txtEndTime.Text; }
            set { txtEndTime.Text = value; }
        }

        public string PostalCode
        {
            get { return txtPostalCode.Text; }
            set { txtPostalCode.Text = value; }
        }

        public string Address
        {
            get { return txtAddress.Text; }
            set { txtAddress.Text = value; }
        }

        public string IsCancelled
        {
            get { return ddlIsCancelled.SelectedValue; }
            set { ddlIsCancelled.Text = value; }
        }

        public string IsObligatory
        {
            get { return ddlIsObligatory.SelectedValue; }
            set { ddlIsObligatory.Text = value; }
        }

        public string IsPrivate
        {
            get { return ddlIsPrivate.SelectedValue; }
            set { ddlIsPrivate.Text = value; }
        }

        public string Message
        {
            get { return lblMessage.Text; }

            set { lblMessage.Text = value; }
        }



        public bool AppointmentNameReadOnly
        {
            set { txtAppointmentName.ReadOnly = value; }
        }
        public bool DateReadOnly
        {
            set { txtDate.ReadOnly = value; }
        }
        public bool AppointmentDescriptionReadOnly
        {
            set { txtAppointmentDescription.ReadOnly = value; }
        }
        public bool StartTimeReadOnly
        {
            set { txtStartTime.ReadOnly = value; }
        }
        public bool EndDateReadOnly
        {
            set { txtEndTime.ReadOnly = value; }
        }
        public bool IsCancelledEnabled
        {
            set { ddlIsCancelled.Enabled = value; }
        }
        public bool IsObligatoryEnabled
        {
            set { ddlIsObligatory.Enabled = value; }
        }
        public bool IsPrivateEnabled
        {
            set { ddlIsPrivate.Enabled = value; }
        }
        public bool PostalCodeReadOnly
        {
            set { txtPostalCode.ReadOnly = value; }
        }
        public bool AddressReadOnly
        {
            set { txtAddress.ReadOnly = value; }
        }
        public bool EndTimeReadOnly
        {
            set { txtEndTime.ReadOnly = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}