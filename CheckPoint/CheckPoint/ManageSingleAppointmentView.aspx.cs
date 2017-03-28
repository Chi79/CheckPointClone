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

        public bool BackToHomePageButtonVisible
        {
            set { btnBackToHomePage.Visible = value; }
        }

        public bool AddAppointmentToCourseButtonVisible
        {
            set { btnAddThisAppointmentToTheCourse.Visible = value; }
        }

        public bool BackToCoursesButtonVisible
        {
            set { btnBackToCourses.Visible = value; }
        }

        public bool SelectAnotherAppointmentButtonVisible
        {
            set { btnSelectDifferentAppointment.Visible = value; }
        }


        public void RedirectAfterClickEvent()
        {
            Response.Redirect("ManageSingleAppointmentView.aspx");
        }

        public void RedirectToHostHomeView()
        {
            Response.Redirect("HostHomeView.aspx");
        }
        public void RedirectToViewCourses()
        {
            Response.Redirect("HostCoursesView.aspx");
        }


        public event EventHandler<EventArgs> YesButtonClicked;
        public event EventHandler<EventArgs> NoButtonClicked;
        public event EventHandler<EventArgs> AddAppointmentToCourseButtonClicked;
        public event EventHandler<EventArgs> SelectAnotherAppointmentButtonClicked;
        public event EventHandler<EventArgs> BackToCoursesButtonClicked;
        public event EventHandler<EventArgs> UpdateAppointment;
        public event EventHandler<EventArgs> DeleteAppointment;
        public event EventHandler<EventArgs> ReloadPage;
        public event EventHandler<EventArgs> BackToHomePage;

        protected void Page_Load(object sender, EventArgs e)
        {
           
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

        protected void btnAddThisAppointmentToTheCourse_Click(object sender, EventArgs e)
        {
            if(AddAppointmentToCourseButtonClicked != null)
            {
                AddAppointmentToCourseButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnSelectDifferentAppointment_Click(object sender, EventArgs e)
        {
            if(SelectAnotherAppointmentButtonClicked != null)
            {
                SelectAnotherAppointmentButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnBackToCourses_Click(object sender, EventArgs e)
        {
            if (BackToCoursesButtonClicked != null)
            {
                BackToCoursesButtonClicked(this, EventArgs.Empty);
            }
        }
    }
}