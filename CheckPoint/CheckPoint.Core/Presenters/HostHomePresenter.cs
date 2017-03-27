using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointCommon.ServiceInterfaces;
using CheckPointPresenters.Bases;
using CheckPointDataTables.Tables;


namespace CheckPointPresenters.Presenters
{
    public class HostHomePresenter : PresenterBase
    {
        private readonly IHostHomeView _view;
        private readonly IHostHomeModel _model;
        private readonly IShowAppointments _displayService;

        private string _client;

        public HostHomePresenter(IHostHomeView hostHomeView, IHostHomeModel hostHomeModel,
                                 IShowAppointments displayService)
        {
            _view = hostHomeView;
            _model = hostHomeModel;
            _displayService = displayService;
            _client = _view.LoggedInClient;

            _view.RowSelected += OnRowSelected;
            _view.SortColumnsByPropertyAscending += OnSortColumnsAscendingClicked;
            _view.SortColumnsByPropertyDescending += OnSortColumnsDescendingClicked;
            _view.CreateAppointmentButtonClicked += OnCreateAppointmentButtonClicked;
            _view.ManageAppointmentButtonClicked += OnManageAppointmentButtonClicked;
            _view.ManageAttendanceButtonClicked += OnManageAttendanceButtonClicked;
            _view.CreateReportButtonClicked += OnCreateReportButtonClicked;
            _view.ViewCoursesButtonClicked += OnViewCoursesButtonClicked;
            _view.AddSelectedAppointmentToCourseButtonClicked += OnAddSelectedAppointmentToCourseButtonClicked;
        }

        private void OnAddSelectedAppointmentToCourseButtonClicked(object sender, EventArgs e)
        {
            _view.RedirectToManageAppointment();
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

            int noAppointmentSelected = -1;
            if (_view.SessionAppointmentId == noAppointmentSelected)
            {
                _view.Message = "No appointment has been selected!";
            }
            else
            {
                _view.RedirectToManageAppointment();
            }

        }

        private void OnCreateAppointmentButtonClicked(object sender, EventArgs e)
        {

           _view.RedirectToCreateAppointment();
        }

        public override void Load()
        {
            FetchData();
        }
        public override void FirstTimeInit()
        {
            CheckAddAppointmentStatus();

            _view.SetDataSource = _displayService.GetAllAppointmentsFor<APPOINTMENT>(_client);
            _view.SetDataSource2 = _displayService.GetEmptyList<APPOINTMENT>();
            _view.SessionRowIndex = -1;
            _view.SessionAppointmentId = -1;
            _view.BindData();
        }

        private void CheckAddAppointmentStatus()
        {
            bool AddingAppointmentToCourse = _view.AddAppointmentToCourseStatus;
            if(AddingAppointmentToCourse == true)
            {
                DisplayAddToCourseButtons();
            }
        }

        private void DisplayAddToCourseButtons()
        {
            _view.ManageAppointmentButtonVisible = false;
            _view.CreateAppointmentButtonVisible = false;
            _view.ManageAttendanceButtonVisible = false;
            _view.CreateReportButtonVisible = false;
            _view.ViewCoursesButtonVisible = false;
            _view.AddSelectedAppointmenButtonVisible = true;
        }

        private void FetchData()
        {
            var appointments = _displayService.GetAppointmentsCached<APPOINTMENT>();

        }
        private void OnRowSelected(object sender, EventArgs e)
        {
            _view.SessionRowIndex = _view.SelectedRowIndex;
            GetSelectedAppointmentIdFromGrid();    
        }

        private void OnSortColumnsAscendingClicked(object sender, EventArgs e)
        {
            var apps = _displayService.GetAppointmentsSortedByPropertyAscending<object>(_view.ColumnName);
            _view.SetDataSource = apps;
            _view.SetDataSource2 = _displayService.GetEmptyList<APPOINTMENT>();
            _view.BindData();

            GetSelectedAppointmentIdFromGrid();
        }
        private void OnSortColumnsDescendingClicked(object sender, EventArgs e)
        {
            var apps = _displayService.GetAppointmentsSortedByPropertyDescending<object>(_view.ColumnName);
            _view.SetDataSource = apps;
            _view.SetDataSource2 = _displayService.GetEmptyList<APPOINTMENT>();
            _view.BindData();

            GetSelectedAppointmentIdFromGrid();
        }
        private void GetSelectedAppointmentIdFromGrid()
        {
            int noIndexSelected = -1;
            if(_view.SessionRowIndex != noIndexSelected)
            {
                var selectedAppointmentId = _view.SelectedRowValueDataKey;
                _view.SessionAppointmentId = (int)selectedAppointmentId;
                _view.Message = selectedAppointmentId.ToString();
            }
        }
    }
}
