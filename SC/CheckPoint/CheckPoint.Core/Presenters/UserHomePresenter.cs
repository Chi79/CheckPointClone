using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointPresenters.Bases;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointCommon.ServiceInterfaces;
using CheckPointDataTables.Tables;

namespace CheckPointPresenters.Presenters
{
    public class UserHomePresenter : PresenterBase
    {
        private readonly IUserHomeModel _model;
        private readonly IUserHomeView _view;

        public UserHomePresenter(IUserHomeModel userHomeModel, IUserHomeView userHomeView)
        {

            _view = userHomeView;
            _model = userHomeModel;

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

                _view.RedirectToManageAppointment();

            }
            else
            {

                _view.Message = "No appointment has been selected!";

            }

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


        private void OnManageCoursesButtonClicked(object sender, EventArgs e)
        {

            _view.Message = "Fabio Goose";

        }


        private void OnCreateAppointmentButtonClicked(object sender, EventArgs e)
        {

            _view.RedirectToCreateAppointment();

        }

        public override void Load()
        {

            FetchData();

            WireUpEvents();
        }

        private void WireUpEvents()
        {

            _view.SortColumnsByPropertyAscending += OnSortColumnsAscendingClicked;
            _view.SortColumnsByPropertyDescending += OnSortColumnsDescendingClicked;
            _view.RowSelected += OnRowSelected;
            _view.CreateAppointmentButtonClicked += OnCreateAppointmentButtonClicked;
            _view.ManageCoursesButtonClicked += OnManageCoursesButtonClicked;
            _view.ManageAppointmentButtonClicked += OnManageAppointmentButtonClicked;
            _view.ManageAttendanceButtonClicked += OnManageAttendanceButtonClicked;
            _view.CreateReportButtonClicked += OnCreateReportButtonClicked;

        }


        public override void FirstTimeInit()
        {

            _view.SetDataSource = _model.GetAllAppointmentsForClient();

            _view.SetDataSource2 = _model.GetEmptyList();

            _model.ResetSessionState();

            _view.BindData();

        }


        private void FetchData()
        {

            var appointments = _model.GetCachedAppointments();

        }


        private void OnRowSelected(object sender, EventArgs e)
        {

            int rowIndex = _view.SelectedRowIndex;
            _model.SetSessionRowIndex(rowIndex);

            GetSelectedAppointmentIdFromGrid();

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
    }
}
