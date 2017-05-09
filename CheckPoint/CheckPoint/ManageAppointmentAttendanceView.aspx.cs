using CheckPointCommon.ViewInterfaces;
using CheckPointPresenters.Bases;
using CheckPointPresenters.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckPoint.Views
{
    public partial class ManageAppointmentAttendanceView : ViewBase<ManageAppointmentAttendancePresenter>, IManageAppointmentAttendanceView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<object> AppointmentsAppliedToHeaderSetDataSource
        {
            set { AttendeeAppointmentGridViewHeader.SetDataSource2 = value; }
        }

        public IEnumerable<object> AppointmentsAppliedToSetDataSource
        {
            set { AttendeeAppointmentGridView.SetDataSource = value; }
        }
        public IEnumerable<object> AppliedAttendeesHeaderSetDataSource
        {
            set { AttendeeGridViewHeader.SetDataSource2 = value; }
        }

        public IEnumerable<object> AppliedAttendeesSetDataSource
        {
            set { AttendeeGridView.SetDataSource = value; }
        }

        public int SelectedAppointmentRowIndex
        {
            get { return AttendeeAppointmentGridView.SelectedRowIndex; }
            set { AttendeeAppointmentGridView.SelectedRowIndex = value; }
        }

        

        public void BindAppointmentData()
        {
            AttendeeAppointmentGridViewHeader.BindData();
            AttendeeAppointmentGridView.BindData();
        }

        public void BindAttendeeData()
        {
            AttendeeGridViewHeader.BindData();
            AttendeeGridView.BindData();
        }

        public bool ShowAttendeeGridViewHeader
        {
            get { return AttendeeGridViewHeader.Visible; }
            set { AttendeeGridViewHeader.Visible = value; }
        }

        public bool ShowAttendeeGridView
        {
            get { return panelAttendeeGridView.Visible; }
            set { panelAttendeeGridView.Visible = value; }
        }

        public bool ShowAttendeeHeader
        {
            set { AttendeeHeader.Visible = value; }
        }

        public object SelectedAppointmentRowValueDataKey
        {
            get { return AttendeeAppointmentGridView.SelectedRowValueDataKey; }
        }

        public object SelectedAttendeeRowValueDataKey
        {
            get { return AttendeeGridView.SelectedRowValueDataKey; }
        }

        public bool ShowAcceptAttendanceRequestButton
        {
            set { btnAcceptAttendanceRequest.Visible = value; }
        }

        public bool ShowAcceptAllAttendanceRequestsForSelectedAppointmentButton
        {
            set { btnAcceptAllAttendeeRequestsForSelectedAppointment.Visible = value; }
        }

        public string MessagePanelMessage
        {
            get { return messagePanelAppointments.Message; }
            set { messagePanelAppointments.Message = value; }
        }

        public bool MessagePanelVisible
        {
            set { messagePanelAppointments.MessagePanelVisible = value; }
        }

        public bool YesButtonVisible
        {
            set { messagePanelAppointments.YesButtonVisible = value; }
        }

        public bool NoButtonVisible
        {
            set { messagePanelAppointments.NoButtonVisible = value; }
        }

        public bool ContinueButtonVisible
        {
            set { messagePanelAppointments.ContinueButtonVisible = value; }
        }

        public bool AcceptAttendeesButtonVisible
        {
            set { btnAcceptAttendanceRequest.Visible = value; }
        }

        public bool AcceptAllAttendeesButtonVisible
        {
            set { btnAcceptAllAttendeeRequestsForSelectedAppointment.Visible = value;}
        }


        public int SelectedAttendeeRowIndex
        {
            get { return AttendeeGridView.SelectedRowIndex; }
            set { AttendeeGridView.SelectedRowIndex = value; }
        }

        public override void HookUpEvents()
        {
            AttendeeAppointmentGridView.RowSelected += OnAppointmentRowSelected;
            AttendeeGridView.RowSelected += OnAttendeeRowSelected;
            messagePanelAppointments.YesButtonClicked += OnYesButtonClicked;
            messagePanelAppointments.NoButtonClicked += OnNoButtonClicked;
            messagePanelAppointments.ReloadPage += OnContinueButtonClicked;

        }

        public event EventHandler<EventArgs> AcceptAttendanceRequest;
        public event EventHandler<EventArgs> AcceptAllAttendanceRequestsForSelectedAppointment;
        public event EventHandler<EventArgs> AppointmentRowSelected;
        public event EventHandler<EventArgs> AttendeeRowSelected;
        public event EventHandler<EventArgs> RedirectToManageCourseAttendance;
        public event EventHandler<EventArgs> YesButtonClicked;
        public event EventHandler<EventArgs> NoButtonClicked;
        public event EventHandler<EventArgs> ContinueButtonClicked;

        private void OnContinueButtonClicked(object sender, EventArgs e)
        {
            if(ContinueButtonClicked != null)
            {
                ContinueButtonClicked(this, EventArgs.Empty);
            }
        }

        private void OnNoButtonClicked(object sender, EventArgs e)
        {
            if(NoButtonClicked != null)
            {
                NoButtonClicked(this, EventArgs.Empty);
            }
        }

        private void OnYesButtonClicked(object sender, EventArgs e)
        {
            if(YesButtonClicked != null)
            {
                YesButtonClicked(this, EventArgs.Empty);
            }
        }

        private void OnAppointmentRowSelected(object sender, EventArgs e)
        {
            if(AppointmentRowSelected != null)
            {
                AppointmentRowSelected(this, EventArgs.Empty);
            }
        }

        private void OnAttendeeRowSelected(object sender, EventArgs e)
        {
            if(AttendeeRowSelected != null)
            {
                AttendeeRowSelected(this, EventArgs.Empty);
            }
        }

        protected void btnManageCourseAttendance_Click(object sender, EventArgs e)
        {
            if (RedirectToManageCourseAttendance != null)
            {
                RedirectToManageCourseAttendance(this, EventArgs.Empty);
            }
        }

        public void RedirectToManageCourseAttendanceView()
        {
            Response.Redirect("ManageCourseAttendanceView.aspx");
        }

        protected void btnAcceptAttendanceRequest_Click(object sender, EventArgs e)
        {
            if(AcceptAttendanceRequest != null)
            {
                AcceptAttendanceRequest(this, EventArgs.Empty);
            }
        }

        protected void btnAcceptAllAttendeeRequestsForSelectedAppointment_Click(object sender, EventArgs e)
        {
            if(AcceptAllAttendanceRequestsForSelectedAppointment != null)
            {
                AcceptAllAttendanceRequestsForSelectedAppointment(this, EventArgs.Empty);
            }
        }
    }
}