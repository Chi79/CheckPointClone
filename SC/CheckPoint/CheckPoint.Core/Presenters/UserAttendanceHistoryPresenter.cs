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

            //HideTimeAttendedHeader();

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

            //ShowTimeAttendedHeader();

            //ShowTimeAttendedData();

            //ShowDateAndTimeTextBox();
        }

        //private void ShowTimeAttendedData()
        //{
        //    _view.DateAndTimeTextBoxMessage = GetTimeAttendedForSelectedAttendee().ToString(); 
        //}

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

        //private void ShowTimeAttendedHeader()
        //{
        //    _view.ShowTimeAttendedHeader = true;
        //}

        //private void HideTimeAttendedHeader()
        //{
        //    _view.ShowTimeAttendedHeader = false;
        //}

        //private void ShowDateAndTimeTextBox()
        //{
        //    _view.ShowDateAndTimeTextBox = true;
        //}

        private DateTime GetTimeAttendedForSelectedAttendee()
        {
            return _model.GetTimeAttendedForSelectedAttendee();
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
