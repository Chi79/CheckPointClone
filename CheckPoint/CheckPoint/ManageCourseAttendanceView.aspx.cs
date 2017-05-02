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
        public event EventHandler<EventArgs> RowSelected;
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

        public int SelectedRowIndex
        {
            get { return CourseGridView.SelectedRowIndex; }
            set { CourseGridView.SelectedRowIndex = value; }
        }

        public override void HookUpEvents()
        {           
            CourseGridView.RowSelected += OnCourseAppointmentRowSelected;
        }

        private void OnCourseAppointmentRowSelected(object sender, EventArgs e)
        {
            if(RowSelected != null)
            {
                RowSelected(this, EventArgs.Empty);
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