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
        }

        public string Description
        {
            get { return txtAppointmentDescription.Text; }
        }

        public string Date
        {
            get { return txtDate.Text; }
        }

        public string StartTime
        {
            get { return txtStartTime.Text; }
        }
        public string EndTime
        {
            get { return txtEndTime.Text; }
        }

        public string PostalCode
        {
            get { return txtPostalCode.Text; }
        }

        public string Address
        {
            get { return txtAddress.Text; }
        }

        public string IsCancelled
        {
            get { return ddlIsCancelled.SelectedValue; }
        }

        public string IsObligatory
        {
            get { return ddlIsObligatory.SelectedValue; }
        }

        public string IsPrivate
        {
            get { return ddlIsPrivate.SelectedValue; }
        }

        public string Message
        {
            get { return lblMessage.Text; }

            set { lblMessage.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}