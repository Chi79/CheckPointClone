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

            HideAttendeeHeader();
        }

        private void ResetSessionState()
        {
            _model.ResetSessionState();
        }

        private void ShowCourseData()
        {
            _view.CoursesAppliedToHeaderSetDataSource = _model.GetEmptyCourseList();
            var stuff = _model.GetAllCoursesWithAttendeeRequests();
            _view.CoursesAppliedToSetDataSource = stuff;

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
            _view.YesButtonClicked += OnMessagePanelYesButtonClicked;
            _view.NoButtonClicked += OnMessagePanelNoButtonClicked;
            _view.ContinueButtonClicked += OnMessagePanelContinueButtonClicked;
        }

        private bool CheckIsCourseSelected()
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
            var isCourseSelected = CheckIsCourseSelected();
            if (isCourseSelected)
            {
                ShowMessagePanel();

                _view.MessagePanelMessage = "<br /> Are you sure you would like to approve all attendee requests for this course?<br /><br />";
                
                ShowYesButton();
                ShowNoButton();
       
            }
            else
            {
                ShowMessagePanel();

                _view.MessagePanelMessage = "<br /> No course has been selected! <br /><br />";

                ShowContinueButton();

            }

            
        }

        private void OnMessagePanelContinueButtonClicked(object sender, EventArgs e)
        {
            HideMessagePanel();
            HideContinueButton();
        }

        private void OnMessagePanelNoButtonClicked(object sender, EventArgs e)
        {
            HideMessagePanel();
            HideNoButton();
            HideYesButton();
        }

        private void OnMessagePanelYesButtonClicked(object sender, EventArgs e)
        {           
                ChangeAllAttendeesStatusesToApproved();
                UpdateGridViews();

                HideYesButton();
                HideNoButton();

                _view.MessagePanelMessage = "All attendee requests for course accepted!";

                ShowContinueButton();
            
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

            ShowAttendeeHeader();

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

        private void ShowMessagePanel()
        {
            _view.MessagePanelVisible = true;
        }

        private void HideMessagePanel()
        {
            _view.MessagePanelVisible = false;
        }

        private void ShowAttendeeHeader()
        {

            _view.ShowAttendeeHeader = true;

        }

        private void HideAttendeeHeader()
        {

            _view.ShowAttendeeHeader = false;

        }

        private void ShowYesButton()
        {
            _view.YesButtonVisible = true;
        }

        private void HideYesButton()
        {
            _view.YesButtonVisible = false;
        }
        private void ShowNoButton()
        {
            _view.NoButtonVisible = true;
        }

        private void HideNoButton()
        {
            _view.NoButtonVisible = false;
        }
        private void ShowContinueButton()
        {
            _view.ContinueButtonVisible = true;
        }

        private void HideContinueButton()
        {
            _view.ContinueButtonVisible = false;
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
        private bool CheckIsAttendeeSelected()
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
            var isAttendeeSelected = CheckIsAttendeeSelected();
            if (isAttendeeSelected)
            {
                ChangeSelectedAttendeesStatusToApproved();
                UpdateGridViews();

                ShowMessagePanel();

                _view.MessagePanelMessage = "<br /> Attendee request approved for the course!<br /><br />";

                ShowContinueButton();
            }
            else
            {
                ShowMessagePanel();

                _view.MessagePanelMessage = "<br /> No attendee selected!<br /> <br / Please select an attendee<br />";

                ShowContinueButton();
            }

        }

        private void ChangeSelectedAttendeesStatusToApproved()
        {
            _model.ChangeSelectedAttendeesStatusToApproved();
        }


    }
}
