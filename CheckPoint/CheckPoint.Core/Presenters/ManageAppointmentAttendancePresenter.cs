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
            _view.AppointmentRowSelected += OnAppointmentGridViewRowSelected;
            _view.AttendeeRowSelected += OnAttendeeGridViewRowSelected;
            _view.RedirectToManageCourseAttendance += OnManageCourseAttendanceButtonClicked;
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
            ShowAttendeeData();
        }

        private void SaveSelectedAppointmentIdToSession()
        {
            var selectedAppointmentId = (int)_view.SelectedAppointmentRowValueDataKey;

            _model.SetSessionAppointmentId(selectedAppointmentId);

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
            if (IsAttendeeSelected() == true)
            {
                var attendeeUsername = _model.GetSessionAttendeeUsername();
                //TODO: update attendee status.
            }

        }

        private void SaveAppointmentRowIndexToSession()
        {
            var selectedRowIndex = _view.SelectedAppointmentRowIndex;
            _model.SetSessionRowIndex(selectedRowIndex);
        }
    }
}
