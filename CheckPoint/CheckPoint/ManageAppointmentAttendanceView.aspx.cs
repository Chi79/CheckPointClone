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
        public IEnumerable<object> AppointmentsAppliedToHeaderSetDataSource
        {
            set { AppointmentGridViewHeader.SetDataSource2 = value; }
        }

        public IEnumerable<object> AppointmentsAppliedToSetDataSource
        {
            set { AppointmentGridView.SetDataSource = value; }
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
            get { return AppointmentGridView.SelectedRowIndex; }
            set { AppointmentGridView.SelectedRowIndex = value; }
        }

        public event EventHandler<EventArgs> AcceptAttendanceRequest;
        public event EventHandler<EventArgs> AcceptAllAttendanceRequestsForSelectedAppointment;
        public event EventHandler<EventArgs> AppointmentRowSelected;
        public event EventHandler<EventArgs> AttendeeRowSelected;
        public event EventHandler<EventArgs> RedirectToManageCourseAttendance;

        public void BindAppointmentData()
        {
            AppointmentGridViewHeader.BindData();
            AppointmentGridView.BindData();
        }

        public void BindAttendeeData()
        {
            AttendeeGridViewHeader.BindData();
            AttendeeGridView.BindData();
        }

        //public bool ShowAttendeeGridViewHeader
        //{
        //    get { return panelAttendeeHeader.Visible; }
        //    set { panelAttendeeHeader.Visible = value; }
        //}

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

        public object SelectedAppointmentRowValueDataKey
        {
            get { return AppointmentGridView.SelectedRowValueDataKey; }
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

        public int SelectedAttendeeRowIndex
        {
            get { return AttendeeGridView.SelectedRowIndex; }
            set { AttendeeGridView.SelectedRowIndex = value; }
        }

        public override void HookUpEvents()
        {
            AppointmentGridView.RowSelected += OnAppointmentRowSelected;
            AttendeeGridView.RowSelected += OnAttendeeRowSelected;          
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

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ForcePostBack()
        {
            Response.Redirect("ManageAppointmentAttendanceView.aspx");
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