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
        public event EventHandler<EventArgs> AcceptAllAttendanceRequestsForSelectedCourse;
        public event EventHandler<EventArgs> RedirectToManageAppointmentAttendance;
        public event EventHandler<EventArgs> YesButtonClicked;
        public event EventHandler<EventArgs> NoButtonClicked;
        public event EventHandler<EventArgs> ContinueButtonClicked;

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

        public bool ShowAcceptAttendanceRequestButton
        {
            set { btnAcceptAttendanceRequest.Visible = value; }
        }

        public override void HookUpEvents()
        {           
            CourseGridView.RowSelected += OnCourseRowSelected;
            AttendeeGridView.RowSelected += OnAttendeeRowSelected;
            MessagePanel.YesButtonClicked += OnYesButtonClicked;
            MessagePanel.NoButtonClicked += OnNoButtonClicked;
            MessagePanel.ReloadPage += OnContinueButtonClicked;
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

        private void OnContinueButtonClicked(object sender, EventArgs e)
        {
            if (ContinueButtonClicked != null)
            {
                ContinueButtonClicked(this, EventArgs.Empty);
            }
        }

        private void OnNoButtonClicked(object sender, EventArgs e)
        {
            if (NoButtonClicked != null)
            {
                NoButtonClicked(this, EventArgs.Empty);
            }
        }

        private void OnYesButtonClicked(object sender, EventArgs e)
        {
            if (YesButtonClicked != null)
            {
                YesButtonClicked(this, EventArgs.Empty);
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

        public bool ShowAttendeeGridViewHeader
        {
            get { return panelAttendeeHeader.Visible; }
            set { panelAttendeeHeader.Visible = value; }
        }

        public bool ShowAttendeeGridView
        {
            get { return panelAttendeeGridView.Visible; }
            set { panelAttendeeGridView.Visible = value; }
        }

        public bool ShowAcceptAllAttendanceRequestsForSelectedCourseButton
        {
            set{ btnAcceptAllAttendeeRequestsForSelectedCourse.Visible = value; }
        }

        public string MessagePanelMessage
        {
            get { return MessagePanel.Message; }

            set { MessagePanel.Message = value; }
        }

        public bool MessagePanelVisible
        {
            set { MessagePanel.MessagePanelVisible = value; }
        }

        public bool YesButtonVisible
        {
            set { MessagePanel.YesButtonVisible = value; }
        }

        public bool NoButtonVisible
        {
            set { MessagePanel.NoButtonVisible = value; }
        }

        public bool ContinueButtonVisible
        {
            set { MessagePanel.ContinueButtonVisible = value; }
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

        protected void btnAcceptAllAttendeeRequestsForSelectedCourse_Click(object sender, EventArgs e)
        {
            if(AcceptAllAttendanceRequestsForSelectedCourse != null)
            {
                AcceptAllAttendanceRequestsForSelectedCourse(this, EventArgs.Empty);
            }
        }
    }
}