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
    public partial class ManageCourseAttendanceView : ViewBase<ManageCourseAttendancePresenter>, IManageCourseAttendanceView
    {
        public event EventHandler<EventArgs> CourseRowSelected;
        public event EventHandler<EventArgs> AttendeeRowSelected;
        public event EventHandler<EventArgs> AcceptAttendanceRequest;
        public event EventHandler<EventArgs> RedirectToManageAppointmentAttendance;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IEnumerable<object> CoursesAppliedToSetDataSource
        {
            set { CourseGridView.SetDataSource = value;  }
        }

        public IEnumerable<object> CoursesAppliedToHeaderSetDataSource
        {
            set { CourseGridViewHeader.SetDataSource2 = value; }
        }

        public IEnumerable<object> AppliedAttendeesHeaderSetDataSource
        {
            set { AttendeeGridViewHeader.SetDataSource2 = value; }
        }

        public IEnumerable<object> AppliedAttendeesSetDataSource
        {
            set { AttendeeGridView.SetDataSource = value; }
        }

        public int SelectedCourseRowIndex
        {
            get { return CourseGridView.SelectedRowIndex; }
            set { CourseGridView.SelectedRowIndex = value; }
        }

        public int SelectedAttendeeRowIndex
        {
            get { return AttendeeGridView.SelectedRowIndex; }
            set { AttendeeGridView.SelectedRowIndex = value; }
        }

        public object SelectedCourseRowValueDataKey
        {
            get { return CourseGridView.SelectedRowValueDataKey; }
        }

        public object SelectedAttendeeRowValueDataKey
        {
            get { return AttendeeGridView.SelectedRowValueDataKey; }
        }

        public void ForcePostBack()
        {
            Response.Redirect("ManageCourseAttendanceView.aspx");
        }

        public override void HookUpEvents()
        {           
            CourseGridView.RowSelected += OnCourseRowSelected;
            AttendeeGridView.RowSelected += OnAttendeeRowSelected;
        }

        private void OnCourseRowSelected(object sender, EventArgs e)
        {
            if(CourseRowSelected != null)
            {
                CourseRowSelected(this, EventArgs.Empty);
            }
        }

        private void OnAttendeeRowSelected(object sender, EventArgs e)
        {
            if(AttendeeRowSelected != null)
            {
                AttendeeRowSelected(this, EventArgs.Empty);
            }
        }

        protected void btnAcceptAttendanceRequest_Click(object sender, EventArgs e)
        {
            if(AcceptAttendanceRequest != null)
            {
                AcceptAttendanceRequest(this, EventArgs.Empty);
            }
        }

        public void BindCourseData()
        {
            CourseGridViewHeader.BindData();
            CourseGridView.BindData();
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

        protected void btnManageAppointmentAttendance_Click(object sender, EventArgs e)
        {
            if (RedirectToManageAppointmentAttendance != null)
            {
                RedirectToManageAppointmentAttendance(this, EventArgs.Empty);
            }
        }

        public void RedirectToManageAppointmentAttendanceView()
        {
            Response.Redirect("ManageAppointmentAttendanceView.aspx");
        }
    }
}