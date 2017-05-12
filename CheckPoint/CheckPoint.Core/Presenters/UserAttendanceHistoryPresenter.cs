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
    public class UserAttendanceHistoryPresenter : PresenterBase
    {
        private readonly IUserAttendanceHistoryView _view;
        private readonly IUserAttendanceHistoryModel _model;

        public UserAttendanceHistoryPresenter(IUserAttendanceHistoryView view, IUserAttendanceHistoryModel model)
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

        public override void Load()
        {
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            _view.AppointmentRowSelected += OnAppointmentRowSelected;
        }

        private void OnAppointmentRowSelected(object sender, EventArgs e)
        {
            SaveAppointmentRowIndexToSession();

            GetSelectedAppointmentIdFromGrid();

            DisplayAttendanceInfoForSelectedAppointment();

            ShowAttendeeHeader();
        }

        private void DisplayAttendanceInfoForSelectedAppointment()
        {
            ShowAttendGridView();

            ShowAttendanceData();
        }

        private void ShowAttendGridView()
        {

            _view.ShowAttendeeGridViewHeader = true;
            _view.ShowAttendeeGridView = true;
    
        }

        private void ShowAttendeeHeader()
        {
            _view.ShowAttendeeHeader = true;
        }

        private void ShowAttendeePanel()
        {
            _view.ShowAttendeeGridViewPanel = true;
            _view.ShowAttendeeHeaderPanel = true;
        }

        private void HideAttendeePanel()
        {
            _view.ShowAttendeeGridViewPanel = false;
            _view.ShowAttendeeHeaderPanel = false;
        }

        private void HideAttendeeHeader()
        {

            _view.ShowAttendeeHeader = false;

        }

        private void GetSelectedAppointmentIdFromGrid()
        {
            int noRowSelected = -1;

            if (_model.GetSessionRowIndex() != noRowSelected)
            {
                SaveSelectedAppointmentIdToSession();

            }
        }

        private void SaveSelectedAppointmentIdToSession()
        {
            var selectedAppointmentId = (int)_view.SelectedAppointmentRowValueDataKey;

            _model.SetSessionAppointmentId(selectedAppointmentId);
        }

        private void SaveAppointmentRowIndexToSession()
        {
            var selectedRowIndex = _view.SelectedAppointmentRowIndex;
            _model.SetSessionRowIndex(selectedRowIndex);
        }

        private void ResetSessionState()
        {
            _model.ResetSessionState();
        }

        private void ShowAppointmentData()
        {
            _view.AppointmentsHistoryHeaderSetDataSource = GetEmptyAppointmentList();

            _view.AppointmentsHistorySetDataSource = GetAttendedAppointmentsForUser();

            _view.BindAppointmentData();
        }

        private void ShowAttendanceData()
        {
            _view.AttendanceHistoryHeaderSetDataSource = GetEmptyAttendeeList();

            _view.AttendanceHistorySetDataSource = GetAttendanceInformationForSelectedAppointment();

            _view.BindAttendeeData();
        }

        private IEnumerable<object> GetAttendanceInformationForSelectedAppointment()
        {
            return _model.GetAttendanceInformationForSelectedAppointment();
        }

        private IEnumerable<object> GetEmptyAttendeeList()
        {
            return _model.GetEmptyAttendeeList();
        }

        private IEnumerable<object> GetAttendedAppointmentsForUser()
        {
            return _model.GetAttendedAppointmentsForUser();
        }

        private IEnumerable<object> GetEmptyAppointmentList()
        {
            return _model.GetEmptyAppointmentList();
        }

        






    }

}
