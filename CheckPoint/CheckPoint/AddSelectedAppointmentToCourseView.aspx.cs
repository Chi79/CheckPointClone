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
    public partial class AddSelectedAppointmentToCourseView : ViewBase<AddSelectedAppointmentToCoursePresenter> , IAddSelectedAppointmentToCourseView
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
            get { return AppointmentCreator.Message; }
            set { AppointmentCreator.Message = value; }
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

        public bool YesButtonVisible
        {
            set { btnYes.Visible = value; }
        }

        public bool NoButtonVisible
        {
            set { btnNo.Visible = value; }
        }

        public void RedirectBackToHostHomeView()
        {

            Response.Redirect("HostHomeView.aspx");

        }

        public void RedirectToCourseSelectorView()
        {

            Response.Redirect("CourseSelectorView.aspx");

        }

        public event EventHandler<EventArgs> YesButtonClicked;
        public event EventHandler<EventArgs> NoButtonClicked;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "GET")
            {
                //if true is not a postback
            }
            if (Request.HttpMethod == "POST")
            {
                //if true is a postback
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