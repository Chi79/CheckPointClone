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
    public partial class ManageSingleAppointmentView : ViewBase<ManageSingleAppointmentPresenter>, IManageSingleAppointmentView
    {
        public string CourseId
        {
            get { return txtCourseId.Text; }
            set { txtCourseId.Text = value; }
        }

        public string SelectedAppointmentName
        {
            get { return (string)Session["SelectedAppointmentName"]; }
            set { Session["SelectedAppointmentName"] = value; }
        }
        public int AppointmentId
        {
            get { return (int)Session["AppointmentId"]; }
            set { Session["AppointmentId"] = value; }
        }

        public string AppointmentName
        {
            get { return txtAppointmentName.Text; }
            set { txtAppointmentName.Text = value; }
        }

        public string Date
        {
            get { return txtDate.Text; }
            set { txtDate.Text = value; }
        }

        public string Description
        {
            get { return txtAppointmentDescription.Text; }
            set { txtAppointmentDescription.Text = value; }
        }

        public string StartTime
        {
            get { return txtStartTime.Text; }
            set { txtStartTime.Text = value; }
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

        public string Message
        {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value; }
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

        public string EndTime
        {
            get { return txtEndTime.Text; }
            set { txtEndTime.Text = value; }
        }

        public string UserName
        {
            get { return Session["LoggedInClient"].ToString(); }
        }

        public bool ContinueButtonVisible
        {
            set { btnContinue.Visible = value; }
        }

        public bool UpdateButtonVisible
        {
            set { btnUpdateAppointment.Visible = value; }
        }

        public bool DeleteButtonVisible
        {
            set { btnDeleteAppointment.Visible = value; }
        }
        public bool YesButtonVisible
        {
            set { btnYes.Visible = value; }
        }
        public bool NoButtonVisible
        {
            set { btnNo.Visible = value; }
        }
        public int JobState
        {
            get { return (int)Session["job"]; }
            set { Session["job"] = value; }
        }

        public void RedirectAfterClickEvent()
        {
            Response.Redirect("ManageSingleAppointmentView.aspx");
        }

        public void RedirectToHostHomeView()
        {
            Response.Redirect("HostHomeView.aspx");
        }


        public event EventHandler<EventArgs> YesButtonClicked;
        public event EventHandler<EventArgs> NoButtonClicked;

        public event EventHandler<EventArgs> UpdateAppointment;
        public event EventHandler<EventArgs> DeleteAppointment;
        public event EventHandler<EventArgs> ReloadPage;
        public event EventHandler<EventArgs> BackToHomePage;

        protected void Page_Load(object sender, EventArgs e)
        {
            AppointmentId = (int)Session["AppointmentId"];
        }

        protected void btnCreateAppointment_Click(object sender, EventArgs e)
        {
            if (UpdateAppointment != null)
            {
                UpdateAppointment(this, EventArgs.Empty);
            }
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            if (ReloadPage != null)
            {
                ReloadPage(this, EventArgs.Empty);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (DeleteAppointment != null)
            {
                DeleteAppointment(this, EventArgs.Empty);
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            if (YesButtonClicked != null)
            {
                YesButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            if (NoButtonClicked != null)
            {
                NoButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnBackToHomePage_Click(object sender, EventArgs e)
        {
            if(BackToHomePage != null)
            {
                BackToHomePage(this, EventArgs.Empty);
            }
        }
    }
}