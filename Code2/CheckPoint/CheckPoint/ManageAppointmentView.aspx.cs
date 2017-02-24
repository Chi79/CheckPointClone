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
    public partial class ManageAppointmentView : ViewBase<ManageAppointmentPresenter> , IManageAppointmentView
    {
        public string CourseId
        {
            get { return txtCourseId.Text; }
            set { txtCourseId.Text = value; }
        }
        public string AppointmentNameList
        {
            get { return ddlSelectAppointment.Text; }

            set { ddlSelectAppointment.Text = value; }
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
            get{ return lblMessage.Text; }
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
            get { return txtUserName.Text; }
            set { txtUserName.Text = value; }
        }
        public bool ContinueButtonVisible { set { btnContinue.Visible = value; } }
        public bool UpdateButtonVisible { set { btnUpdateAppointment.Visible = value; } }

        public void FillAppointmentList(List<string> list)
        {
            ddlSelectAppointment.DataSource = list;
            ddlSelectAppointment.DataBind();
        }
        public void RedirectAfterClickEvent()
        {
            Response.Redirect("ManageAppointmentView.aspx");
        }

        public event EventHandler<EventArgs> UpdateAppointment;
        public event EventHandler<EventArgs> FetchData;
        public event EventHandler<EventArgs> ReloadPage;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateAppointment_Click(object sender, EventArgs e)
        {
            if(UpdateAppointment != null)
            {
                UpdateAppointment(this, EventArgs.Empty);
            }
        }

        protected void ddlSelectAppointment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(FetchData != null)
            {
                FetchData(this, EventArgs.Empty);
            }
        }

        protected void btnFindAppoimtments_Click(object sender, EventArgs e)
        {
            if(ReloadPage != null)
            {
                ReloadPage(this, EventArgs.Empty);
            }
        }
    }
}