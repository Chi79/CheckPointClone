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

        public int SelectedRowIndex
        {
            get { return AppointmentGridView.SelectedRowIndex; }
            set { AppointmentGridView.SelectedRowIndex = value; }
        }

        public event EventHandler<EventArgs> AcceptAttendanceRequest;
        public event EventHandler<EventArgs> RowSelected;
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

        public bool ShowAttendeeGridViewHeaderPanel
        {
            get { return panelAttendeeHeader.Visible; }
            set { panelAttendeeHeader.Visible = value; }
        }

        public bool ShowAttendeeGridViewPanel
        {
            get { return panelAttendeeGridView.Visible; }
            set { panelAttendeeGridView.Visible = value; }
        }

        public object SelectedRowValueDataKey
        {
            get { return AppointmentGridView.SelectedRowValueDataKey; }
        }

        public override void HookUpEvents()
        {
            AppointmentGridView.RowSelected += OnAppointmentRowSelected;            
        }

        private void OnAppointmentRowSelected(object sender, EventArgs e)
        {
            if(RowSelected != null)
            {
                RowSelected(this, EventArgs.Empty);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
}