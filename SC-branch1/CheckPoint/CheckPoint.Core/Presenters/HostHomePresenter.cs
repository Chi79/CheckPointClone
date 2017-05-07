using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointPresenters.Bases;


namespace CheckPointPresenters.Presenters
{
    public class HostHomePresenter : PresenterBase
    {

        private readonly IHostHomeView _view;
        private readonly IHostHomeModel _model;


        public HostHomePresenter(IHostHomeView hostHomeView, IHostHomeModel hostHomeModel)
        {

            _view = hostHomeView;
            _model = hostHomeModel;

        }

        private void OnAddSelectedAppointmentToCourseButtonClicked(object sender, EventArgs e)
        {

            bool RowSelected = CheckRowIsSelected();

            if(RowSelected)
            {

                _view.RedirectToAddSelectedAppointmenToCourseView();

            }
            else
            {
                ShowMessagePanel();

                _view.Message = "No appointment has been selected! Please click a row to select an appointment.";

                ContinueButtonShow();

            }  
        }

        private void OnViewCoursesButtonClicked(object sender, EventArgs e)
        {

            _view.RedirectToCoursesView();

        }

        private void OnCreateReportButtonClicked(object sender, EventArgs e)
        {

            _view.Message = "Fabio Goose";

        }

        private void OnManageAttendanceButtonClicked(object sender, EventArgs e)
        {

            _view.Message = "Fabio Goose";

        }

        private void OnManageAppointmentButtonClicked(object sender, EventArgs e)
        {

            bool RowSelected = CheckRowIsSelected();

            if (RowSelected)
            {

                ResetChangesSavedSessionStatus();

                _view.RedirectToManageAppointment();  

            }
            else
            {

                ShowMessagePanel();

                _view.Message = "No appointment has been selected! Please click a row to select an appointment.";

                ContinueButtonShow();

            }
        }

        private void OnCreateAppointmentButtonClicked(object sender, EventArgs e)
        {

            ResetChangesSavedSessionStatus();

            _view.RedirectToCreateAppointment();

        }

        public override void Load()
        {

            FetchData();
 
            WireUpEvents();

        }

        private void WireUpEvents()
        {

            _view.RowSelected += OnRowSelected;
            _view.SortColumnsByPropertyAscending += OnSortColumnsAscendingClicked;
            _view.SortColumnsByPropertyDescending += OnSortColumnsDescendingClicked;
            _view.CreateAppointmentButtonClicked += OnCreateAppointmentButtonClicked;
            _view.ManageAppointmentButtonClicked += OnManageAppointmentButtonClicked;
            _view.ManageAttendanceButtonClicked += OnManageAttendanceButtonClicked;
            _view.CreateReportButtonClicked += OnCreateReportButtonClicked;
            _view.ViewCoursesButtonClicked += OnViewCoursesButtonClicked;
            _view.AddSelectedAppointmentToCourseButtonClicked += OnAddSelectedAppointmentToCourseButtonClicked;
            _view.ContinueButtonClicked += OnContinueButtonClicked;

        }

        private void OnContinueButtonClicked(object sender, EventArgs e)
        {

            HideMessagePanel();

        }

        private void HideMessagePanel()
        {

            _view.MessagePanelVisible = false;

        }

        private void ShowMessagePanel()
        {

            _view.MessagePanelVisible = true;

        }

        public override void FirstTimeInit()
        {

            ResetSessionState();

            ShowData();

        }

        private void ShowData()
        {

            _view.SetDataSource = _model.GetAllAppointmentsForClient();

            _view.SetDataSource2 = _model.GetEmptyList();

            _view.BindData();

        }

        private void ResetSessionState()
        {

            _model.ResetSessionState();

        }

        private void ResetChangesSavedSessionStatus()
        {

            _model.ResetChangesSavedStatus();

        }


        private void FetchData()
        {

            var appointments = _model.GetCachedAppointments();

        }

        private bool CheckRowIsSelected()
        {
            int noRowSelected = -1;

            if (_model.GetSessionRowIndex() == noRowSelected)
            {

                return false;

            }
            else
            {

                return true;

            }
        }


        private void OnRowSelected(object sender, EventArgs e)
        {

            SaveRowIndexToSession();

            GetSelectedAppointmentIdFromGrid();

        }

        private void SaveRowIndexToSession()
        {

            int rowSelected = _view.SelectedRowIndex;

            _model.SetSessionRowIndex(rowSelected);

        }

        private void OnSortColumnsAscendingClicked(object sender, EventArgs e)
        {

            var apps = _model.GetAppointmentsSortedByPropertyAsc();

            _view.SetDataSource = apps;

            _view.SetDataSource2 = _model.GetEmptyList();

            _view.BindData();

            GetSelectedAppointmentIdFromGrid();

        }

        private void OnSortColumnsDescendingClicked(object sender, EventArgs e)
        {

            var apps = _model.GetAppointmentsSortedByPropertyDesc();

            _view.SetDataSource = apps;

            _view.SetDataSource2 = _model.GetEmptyList();

            _view.BindData();

            GetSelectedAppointmentIdFromGrid();

        }

        private void GetSelectedAppointmentIdFromGrid()
        {

            int noRowSelected = -1;

            if (_model.GetSessionRowIndex() != noRowSelected)
            {

                SaveSelectedAppointmentIdToSession();

                _view.Message = _model.GetSessionAppointmentId().ToString();

            }
        }

        private void SaveSelectedAppointmentIdToSession()
        {

            int selectedAppointmentId = (int)_view.SelectedRowValueDataKey;

            _model.SetSessionAppointmentId(selectedAppointmentId);

        }

        private void ContinueButtonShow()
        {

            _view.ContinueButtonVisible = true;

        }

        private void ContinueButtonHide()
        {

            _view.ContinueButtonVisible = false;

        }
    }
}
