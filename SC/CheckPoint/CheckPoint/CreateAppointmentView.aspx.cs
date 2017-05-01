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
            get { return AppointmentCreator.AppointmentName; }
        }

        public string Description
        {
            get { return AppointmentCreator.Description; }
        }

        public string Date
        {
            get { return AppointmentCreator.Date; }
        }

        public string StartTime
        {
            get { return AppointmentCreator.StartTime; }
        }
        public string EndTime
        {
            get { return AppointmentCreator.EndTime; }
        }

        public string PostalCode
        {
            get { return AppointmentCreator.PostalCode; }
        }

        public string Address
        {
            get { return AppointmentCreator.Address; }
        }

        public string IsCancelled
        {
            get { return AppointmentCreator.IsCancelled; }
        }

        public string IsObligatory
        {
            get { return AppointmentCreator.IsObligatory; }
        }

        public string IsPrivate
        {
            get { return AppointmentCreator.IsPrivate; }
        }

        public string Message
        {
            get { return AppointmentCreator.Message; }

            set { AppointmentCreator.Message = value; }
        }

        public bool ContinueButtonVisible
        {
            set { btnContinue.Visible = value; }
        }

        public bool CreateButtonVisible
        {
            set { btnCreateAppointment.Visible = value; }
        }

        public bool YesButtonVisible
        {
            set { btnYes.Visible = value; }
        }

        public bool NoButtonVisible
        {
            set { btnNo.Visible = value; }
        }


        public void RedirectAfterClickEvent()
        {
            Response.Redirect("CreateAppointmentView.aspx");
        }

        public void RedirectToHomePage()
        {
            Response.Redirect("HostHomeView.aspx");
        }


        public event EventHandler<EventArgs> CreateNewAppointment;
        public event EventHandler<EventArgs> Continue;
        public event EventHandler<EventArgs> YesButtonClicked;
        public event EventHandler<EventArgs> NoButtonClicked;



        protected void Page_Load(object sender, EventArgs e)
        {
  
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

        protected void btnYes_Click(object sender, EventArgs e)
        {
            if(YesButtonClicked != null)
            {
                YesButtonClicked(this, EventArgs.Empty);
            }
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            if(NoButtonClicked != null)
            {
                NoButtonClicked(this, EventArgs.Empty);
            }
        }



    }
}