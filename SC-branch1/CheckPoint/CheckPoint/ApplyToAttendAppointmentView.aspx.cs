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
    public partial class ApplyToAttendAppointmentView : ViewBase<ApplyToAttendAppointmentPresesnter> , IApplyToAttendAppointmentView
    {
        public string Message
        {

            set { AppointmentCreator.Message = value; }

        }

        public string StartTime
        {

            set { AppointmentCreator.StartTime = value; }

        }
        public string EndTime
        {

            set { AppointmentCreator.EndTime = value; }
        }

        public string PostalCode
        {

            set { AppointmentCreator.PostalCode = value; }

        }
        public string AppointmentName
        {

            set { AppointmentCreator.AppointmentName = value; }

        }
        public string Description
        {

            set { AppointmentCreator.Description = value; }

        }
        public string Address
        {

            set { AppointmentCreator.Address = value; }

        }
        public string Date
        {

            set { AppointmentCreator.Date = value; }

        }
        public string IsCancelled
        {

            set { AppointmentCreator.IsCancelled = value; }

        }
        public string IsObligatory
        {

            set { AppointmentCreator.IsObligatory = value; }

        }
        public string IsPrivate
        {

            set { AppointmentCreator.IsPrivate = value; }

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
  
        public void RedirectToFindAppointmentsView()
        {

            Response.Redirect("FindAppointmentsView.aspx");

        }
 
        public bool ContinueButtonVisible
        {

            set { btnContinue.Visible = value; }

        }
        public bool YesButtonVisible
        {

            set {btnYes.Visible = value; }

        }
        public bool NoButtonVisible
        {

            set {btnNo.Visible = value; }

        }
    
        public event EventHandler<EventArgs> YesButtonClicked;
        public event EventHandler<EventArgs> NoButtonClicked;
        public event EventHandler<EventArgs> ContinueButtonClicked;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            if (ContinueButtonClicked != null)
            {
                ContinueButtonClicked(this, EventArgs.Empty);
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

    }
}