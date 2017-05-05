using CheckPointCommon.Enums;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointPresenters.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointPresenters.Presenters
{
    public class ManageCourseAttendancePresenter : PresenterBase
    {
        private readonly IManageCourseAttendanceView _view;
        private readonly IManageCourseAttendanceModel _model;


        public ManageCourseAttendancePresenter(IManageCourseAttendanceView view, IManageCourseAttendanceModel model)
        {
            _view = view;
            _model = model;
        }
        public override void FirstTimeInit()
        {
            ResetSessionState();
            ShowCourseData();
        }

        private void ResetSessionState()
        {
            _model.ResetSessionState();
        }

        private void ShowCourseData()
        {
            _view.CoursesAppliedToHeaderSetDataSource = _model.GetEmptyCourseList();
            _view.CoursesAppliedToSetDataSource = _model.GetAllCoursesWithAttendeeRequests();

            _view.BindCourseData();
        }

        private void ShowAcceptAttendanceButtons()
        {
            _view.ShowAcceptAttendanceRequestButton = true;
            _view.ShowAcceptAllAttendanceRequestsForSelectedCourseButton = true;
        }

        private void ShowAttendeeData()
        {
            _view.AppliedAttendeesHeaderSetDataSource = _model.GetEmptyClientList();
            _view.AppliedAttendeesSetDataSource = _model.GetClientInformationForAttendees();

            _view.BindAttendeeData();
        }

        public override void Load()
        {
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            _view.AcceptAttendanceRequest += OnAcceptAttendanceRequestButtonClicked;
            _view.AcceptAllAttendanceRequestsForSelectedCourse += OnAcceptAllAttendanceRequestsForSelectedCourseButtonClicked;
            _view.CourseRowSelected += OnCourseGridViewRowSelected;
            _view.AttendeeRowSelected += OnAttendeeGridViewSelected;
            _view.RedirectToManageAppointmentAttendance += OnManageAppointmentAttendanceButtonClicked;
        }

        private bool IsCourseSelected()
        {
            int noCourseSelected = -1;

            if (_model.GetSessionCourseId() == noCourseSelected)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void OnAcceptAllAttendanceRequestsForSelectedCourseButtonClicked(object sender, EventArgs e)
        {
            if(IsCourseSelected() == true)
            {
                ChangeAllAttendeesStatusesToApproved();
            }
        }

        private void UpdateGridViews()
        {
            ShowAttendeeData();
            ShowCourseData();
        }

        private void ChangeAllAttendeesStatusesToApproved()
        {
            _model.ChangeAllAttendeesStatusesToApproved();
        }

        private void OnAttendeeGridViewSelected(object sender, EventArgs e)
        {          
            SaveAttendeeRowIndexToSession();

            GetSelectedAttendeeUsernameFromGrid(); 
        }

        private void GetSelectedAttendeeUsernameFromGrid()
        {
            int noRowSelected = -1;

            if (_model.GetSessionRowIndex() != noRowSelected)
            {
                SaveSelectedAttendeeUsernameToSession();

            }
        }

        private void SaveSelectedAttendeeUsernameToSession()
        {
            var attendeeUsername = (string)_view.SelectedAttendeeRowValueDataKey;

            _model.SetAttendeeUsername(attendeeUsername);
        }

        private void SaveAttendeeRowIndexToSession()
        {
            int rowSelected = _view.SelectedAttendeeRowIndex;

            _model.SetSessionRowIndex(rowSelected);
        }

        private void OnManageAppointmentAttendanceButtonClicked(object sender, EventArgs e)
        {
            _view.RedirectToManageAppointmentAttendanceView();
        }

        private void OnCourseGridViewRowSelected(object sender, EventArgs e)
        {
            SaveCourseRowIndexToSession();

            GetSelectedCourseIdFromGrid();

            DisplayAppliedAttendeesForSelectedCourse();

            ShowAcceptAttendanceButtons();

        }

        private void ShowAttendeeGridView()
        {
            _view.ShowAttendeeGridViewHeader = true;
            _view.ShowAttendeeGridView = true;
        }

        private void DisplayAppliedAttendeesForSelectedCourse()
        {
            ShowAttendeeGridView();

            ShowAttendeeData();
        }

        private void SaveCourseRowIndexToSession()
        {

            int rowSelected = _view.SelectedCourseRowIndex;

            _model.SetSessionRowIndex(rowSelected);

        }

        private void GetSelectedCourseIdFromGrid()
        {

            int noRowSelected = -1;

            if (_model.GetSessionRowIndex() != noRowSelected)
            {
                SaveSelectedCourseIdToSession();

            }

        }

        private void SaveSelectedCourseIdToSession()
        {

            int selectedCourseId = (int)_view.SelectedCourseRowValueDataKey;

            _model.SetSessionCourseId(selectedCourseId);

        }
        private bool IsAttendeeSelected()
        {
            string noAttendeeSelected = string.Empty;

            if (_model.GetSessionAttendeeUsername() == noAttendeeSelected)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void OnAcceptAttendanceRequestButtonClicked(object sender, EventArgs e)
        {        
            if(IsAttendeeSelected() == true)
            {
                ChangeSelectedAttendeesStatusToApproved();
            }

        }

        private void ChangeSelectedAttendeesStatusToApproved()
        {
            _model.ChangeSelectedAttendeesStatusToApproved();
        }


    }
}
