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
    public partial class ManageAttendanceView : ViewBase<ManageAttendancePresenter> ,IManageAttendanceView
    {
        public IEnumerable<object> CoursesAppliedToSetDataSource
        {
            set {CourseGridView.SetDataSource = value; }
        }

        public IEnumerable<object> CoursesAppliedToHeaderSetDataSource
        {
            set { CourseGridViewHeader.SetDataSource2 = value; }
        }

        public IEnumerable<object> AppointmentsAppliedToSetDataSource
        {
            set {  AppointmentGridView.SetDataSource = value; }
        }

        public IEnumerable<object> AppointmentsAppliedToHeaderSetDataSource
        {
            set { AppointmentGridViewHeader.SetDataSource2 = value; }
        }

        public IEnumerable<object> AppliedAttendeesSetDataSource
        {
            set { AttendeeGridView.SetDataSource = value; }
        }

        public IEnumerable<object> AppliedAttendeesHeaderSetDataSource
        {
            set { AttendeeGridViewHeader.SetDataSource2 = value; }
        }

        public event EventHandler<EventArgs> AcceptAttendanceRequest;
        public event EventHandler<EventArgs> ShowCourses;
        public event EventHandler<EventArgs> ShowAppointments;
        public event EventHandler<EventArgs> AppointmentRowSelected;
        public event EventHandler<EventArgs> CourseRowSelected;



        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public override void HookUpEvents()
        {
            AppointmentGridView.RowSelected += OnAppointmentRowSelected;
            CourseGridView.RowSelected += OnCourseAppointmentRowSelected;
        }

        private void OnCourseAppointmentRowSelected(object sender, EventArgs e)
        {
            if (CourseRowSelected != null)
            {
                CourseRowSelected(this, EventArgs.Empty);
            }
        }

        private void OnAppointmentRowSelected(object sender, EventArgs e)
        {         
            if (AppointmentRowSelected != null)
            {
                AppointmentRowSelected(this, EventArgs.Empty);
            }
        }

        public bool ShowCourseGridViewHeader
        {
            set { panelCourseHeader.Visible = value; }
        }

        public bool ShowCourseGridView
        {
            set { panelCourseGrid.Visible = value; }
        }

        public bool ShowAppointmentGridViewHeader
        {
            set { panelAppointmentHeader.Visible = value; }
        }

        public bool ShowAppointmentGridView
        {
            set { panelAppointmentGrid.Visible = value; }
        }

        public int SelectedAppointmentRowIndex
        {
            get { return AppointmentGridView.SelectedRowIndex; }
            set { AppointmentGridView.SelectedRowIndex = value; }
        }

        public int SelectedCourseRowIndex
        {
            get { return CourseGridView.SelectedRowIndex; }
            set { CourseGridView.SelectedRowIndex = value; }
        }

        public void BindData()
        {
            AppointmentGridView.BindData();
            AppointmentGridViewHeader.BindData();

            CourseGridView.BindData();
            CourseGridViewHeader.BindData();

            AttendeeGridView.BindData();
            AttendeeGridViewHeader.BindData();

        }

        protected void btnAcceptAttendanceRequest_Click(object sender, EventArgs e)
        {
            if(AcceptAttendanceRequest != null)
            {
                AcceptAttendanceRequest(this, EventArgs.Empty);
            }
        }

        protected void btnShowCourses_Click(object sender, EventArgs e)
        {
            if(ShowCourses != null)
            {
                ShowCourses(this, EventArgs.Empty);
            }
        }

        protected void btnShowAppointments_Click(object sender, EventArgs e)
        {
            if(ShowAppointments != null)
            {
                ShowAppointments(this, EventArgs.Empty);
            }
        }
    }
}