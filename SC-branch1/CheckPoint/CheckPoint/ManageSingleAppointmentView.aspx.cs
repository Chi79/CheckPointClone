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

            get { return AppointmentCreator.AppointmentName; }
            set { AppointmentCreator.AppointmentName = value; }

        }

        public string Description
        {

            get { return AppointmentCreator.Description; }
            set { AppointmentCreator.Description = value; }

        }

        public string Date
        {

            get { return AppointmentCreator.Date; }
            set { AppointmentCreator.Date = value; }

        }

        public string StartTime
        {

            get { return AppointmentCreator.StartTime; }
            set { AppointmentCreator.StartTime = value; }

        }

        public string EndTime
        {

            get { return AppointmentCreator.EndTime; }
            set { AppointmentCreator.EndTime = value; }

        }

        public string PostalCode
        {

            get { return AppointmentCreator.PostalCode; }
            set { AppointmentCreator.PostalCode = value; }

        }

        public string Address
        {

            get { return AppointmentCreator.Address; }
            set { AppointmentCreator.Address = value; }

        }

        public string IsCancelled
        {

            get { return AppointmentCreator.IsCancelled; }
            set { AppointmentCreator.IsCancelled = value; }

        }

        public string IsObligatory
        {

            get { return AppointmentCreator.IsObligatory; }
            set { AppointmentCreator.IsObligatory = value; }

        }

        public string IsPrivate
        {

            get { return AppointmentCreator.IsPrivate; }
            set { AppointmentCreator.IsPrivate = value; }

        }

        public string Message
        {

            get { return MessagePanel.Message; }
            set { MessagePanel.Message = value; }

        }



        public bool AppointmentNameReadOnly
        {

            set { AppointmentCreator.AppointmentNameReadOnly = value; }

        }
        public bool DateReadOnly
        {

            set { AppointmentCreator.DateReadOnly = value; }

        }
        public bool AppointmentDescriptionReadOnly
        {

            set { AppointmentCreator.AppointmentDescriptionReadOnly = value; }

        }
        public bool StartTimeReadOnly
        {

            set { AppointmentCreator.StartTimeReadOnly = value; }

        }

        public bool EndDateReadOnly
        {

            set { AppointmentCreator.EndDateReadOnly = value; }

        }

        public bool IsCancelledEnabled
        {

            set { AppointmentCreator.IsCancelledEnabled = value; }

        }

        public bool IsObligatoryEnabled
        {

            set { AppointmentCreator.IsObligatoryEnabled = value; }

        }
        public bool IsPrivateEnabled
        {

            set { AppointmentCreator.IsPrivateEnabled = value; }

        }
        public bool PostalCodeReadOnly
        {

            set { AppointmentCreator.PostalCodeReadOnly = value; }

        }

        public bool AddressReadOnly
        {

            set { AppointmentCreator.AddressReadOnly = value; }

        }

        public bool EndTimeReadOnly
        {

            set { AppointmentCreator.EndTimeReadOnly = value; }

        }

        public bool ContinueButtonVisible
        {

            set { MessagePanel.ContinueButtonVisible = value; }

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

            set { MessagePanel.YesButtonVisible = value; }

        }

        public bool NoButtonVisible
        {

            set { MessagePanel.NoButtonVisible = value; }

        }

        public bool MessagePanelVisible
        {

            set { MessagePanel.MessagePanelVisible = value; }

        }
        public bool MessageVisible
        {

            set { MessagePanel.MessageVisible = value; }

        }

        public void RedirectAfterClickEvent()
        {

            Response.Redirect("ManageSingleAppointmentView.aspx");

        }

        public void RedirectAfterChangesSaved()
        {

            Response.Redirect("ChangesSavedView.aspx");

        }

        public void RedirectToHostHomePage()
        {

            Response.Redirect("HostHomeView.aspx");

        }

        public event EventHandler<EventArgs> YesButtonClicked;
        public event EventHandler<EventArgs> NoButtonClicked;
        public event EventHandler<EventArgs> UpdateAppointment;
        public event EventHandler<EventArgs> DeleteAppointment;
        public event EventHandler<EventArgs> ReloadPage;


        protected void Page_Load(object sender, EventArgs e)
        {


        }

        public override void HookUpEvents()
        {

            MessagePanel.YesButtonClicked += btnYes_Click;
            MessagePanel.NoButtonClicked += btnNo_Click;
            MessagePanel.ReloadPage += btnContinue_Click;

        }


        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (ReloadPage != null)
            {
                ReloadPage(this, EventArgs.Empty);
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {

            if (NoButtonClicked != null)
            {
                NoButtonClicked(this, EventArgs.Empty);
            }

        }

        private void btnYes_Click(object sender, EventArgs e)
        {

            if (YesButtonClicked != null)
            {
                YesButtonClicked(this, EventArgs.Empty);
            }

        }

        protected void btnCreateAppointment_Click(object sender, EventArgs e)
        {
            if (UpdateAppointment != null)
            {
                UpdateAppointment(this, EventArgs.Empty);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (DeleteAppointment != null)
            {
                DeleteAppointment(this, EventArgs.Empty);
            }
        }
    }
}