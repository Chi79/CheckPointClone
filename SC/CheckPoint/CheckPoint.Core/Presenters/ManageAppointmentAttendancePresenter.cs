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
    public class ManageAppointmentAttendancePresenter : PresenterBase
    {
        private readonly IManageAppointmentAttendanceView _view;
        private readonly IManageAppointmentAttendanceModel _model;

        public ManageAppointmentAttendancePresenter(IManageAppointmentAttendanceView view, IManageAppointmentAttendanceModel model)
        {
            _view = view;
            _model = model;
        }
        public override void FirstTimeInit()
        {
            ResetSessionState();

            ShowAppointmentData();

            HideAttendeeHeader();
        }

        private void ResetSessionState()
        {
            _model.ResetSessionState();
        }

        private void ShowAppointmentData()
        {
            _view.AppointmentsAppliedToHeaderSetDataSource = _model.GetEmptyAppointmentList();
            _view.AppointmentsAppliedToSetDataSource = _model.GetAllAppointmentsWithAttendeeRequests();

            _view.BindAppointmentData();
        }

        public override void Load()
        {
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            _view.AcceptAttendanceRequest += OnAcceptAttendanceRequestButtonClicked;
            _view.AcceptAllAttendanceRequestsForSelectedAppointment += OnAcceptAllAttendanceRequestsForSelectedAppointmentButtonClicked;
            _view.AppointmentRowSelected += OnAppointmentGridViewRowSelected;
            _view.AttendeeRowSelected += OnAttendeeGridViewRowSelected;
            _view.RedirectToManageCourseAttendance += OnManageCourseAttendanceButtonClicked;
            _view.YesButtonClicked += OnMessagePanelYesButtonClicked;
            _view.NoButtonClicked += OnMessagePanelNoButtonClicked;
            _view.ContinueButtonClicked += OnMessagePanelContinueButtonClicked;
        }

        private void OnMessagePanelContinueButtonClicked(object sender, EventArgs e)
        {
            HideContinueButton();
            HideMessagePanel();
            
        }

        private void OnMessagePanelNoButtonClicked(object sender, EventArgs e)
        {
            HideMessagePanel();
            HideNoButton();
            HideYesButton();
        }

        private void OnMessagePanelYesButtonClicked(object sender, EventArgs e)
        {
            var appointmentIsSelected = IsAppointmentSelected();
            if (appointmentIsSelected)
            {
                ChangeAllAttendeeStatusesToApproved();
                UpdateGridViews();

                HideYesButton();
                HideNoButton();

                _view.MessagePanelMessage = "All attendee requests for appointment accepted!";

                ShowContinueButton();
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

                _view.MessagePanelMessage = "<br /> Attendee request approved for the appointment!<br /><br />";

                ShowContinueButton();
            }
            else
            {
                ShowMessagePanel();

                _view.MessagePanelMessage = "<br /> No attendee selected!<br /> <br /> Please select an attendee <br />";

                ShowContinueButton();
            }

        }

        private void UpdateGridViews()
        {
            ShowAppointmentData();
            ShowAttendeeData();
        }

        private void ChangeSelectedAttendeesStatusToApproved()
        {
            _model.ChangeSelectedAttendeesStatusToApproved();
        }

        private void ShowMessagePanel()
        {
            _view.MessagePanelVisible = true;
        }

        private void HideMessagePanel()
        {
            _view.MessagePanelVisible = false;
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

        private void ShowAcceptAttendeeButtons()
        {
            _view.AcceptAttendeesButtonVisible = true;
            _view.AcceptAllAttendeesButtonVisible = true;
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

        private void ShowAttendeeData()
        {
            _view.AppliedAttendeesHeaderSetDataSource = _model.GetEmptyClientList();
            _view.AppliedAttendeesSetDataSource = _model.GetClientInformationForAttendees();

            _view.BindAttendeeData();
        }

        private void ShowAttendeeGridView()
        {
            _view.ShowAttendeeGridViewHeader = true;
            _view.ShowAttendeeGridView = true;
            
        }

        private void ShowAttendeeHeader()
        {

            _view.ShowAttendeeHeader = true;

        }

        private void HideAttendeeHeader()
        {

            _view.ShowAttendeeHeader = false;

        }

        private void ShowAcceptAttendanceButtons()
        {
            _view.ShowAcceptAttendanceRequestButton = true;
            _view.ShowAcceptAllAttendanceRequestsForSelectedAppointmentButton = true;
        }       

        private void OnAcceptAllAttendanceRequestsForSelectedAppointmentButtonClicked(object sender, EventArgs e)
        {
            ShowMessagePanel();

            _view.MessagePanelMessage = "<br /> Are you sure you would like to approve all attendee requests for this appointment?<br /><br />";

            ShowYesButton();
            ShowNoButton();
        }

        private bool IsAppointmentSelected()
        {
            int noAppointmentSelected = -1;

            if (_model.GetSessionAppointmentId() == noAppointmentSelected)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void OnAttendeeGridViewRowSelected(object sender, EventArgs e)
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

            _model.SetSessionAttendeeUsername(attendeeUsername);
        }

        private void SaveAttendeeRowIndexToSession()
        {
            int rowSelected = _view.SelectedAttendeeRowIndex;

            _model.SetSessionRowIndex(rowSelected);
        }

        private void OnManageCourseAttendanceButtonClicked(object sender, EventArgs e)
        {
            _view.RedirectToManageCourseAttendanceView();
        }

        private void OnAppointmentGridViewRowSelected(object sender, EventArgs e)
        {

            SaveAppointmentRowIndexToSession();

            GetSelectedAppointmentIdFromGrid();

            DisplayAppliedAttendeesForSelectedAppointment();

            ShowAttendeeHeader();

            ShowAcceptAttendanceButtons();
        }

        private void GetSelectedAppointmentIdFromGrid()
        {
            int noRowSelected = -1;

            if (_model.GetSessionRowIndex() != noRowSelected)
            {
                SaveSelectedAppointmentIdToSession();

            }
        }

        private void DisplayAppliedAttendeesForSelectedAppointment()
        {
            ShowAcceptAttendanceButtons();

            ShowAttendeeGridView();
            ShowAttendeeData();
            
        }


        private void SaveSelectedAppointmentIdToSession()
        {
            var selectedAppointmentId = (int)_view.SelectedAppointmentRowValueDataKey;

            _model.SetSessionAppointmentId(selectedAppointmentId);

        }


        private void ChangeAllAttendeeStatusesToApproved()
        {
            _model.ChangeAllAttendeesStatusesToApproved();
        }

        private void SaveAppointmentRowIndexToSession()
        {
            var selectedRowIndex = _view.SelectedAppointmentRowIndex;
            _model.SetSessionRowIndex(selectedRowIndex);
        }
    }
}
