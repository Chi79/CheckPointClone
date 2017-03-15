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

        string host = "Morten";
        //TODO

        public HostHomePresenter(IHostHomeView hostHomeView, IHostHomeModel hostHomeModel,
                                 IShowAppointments displayService)
        {
            _view = hostHomeView;
            _model = hostHomeModel;
            _displayService = displayService;

            _view.SortColumnsByPropertyAscending += OnSortColumnsAscendingClicked;
            _view.SortColumnsByPropertyDescending += OnSortColumnsDescendingClicked;
            _view.RowSelected += OnRowSelected;

            _view.UpdateButtonClicked += OnUpdateButtonClicked;
            _view.ManageCoursesButtonClicked += OnManageCoursesButtonClicked;
            _view.ManageAppointmentsButtonClicked += OnManageAppointmentsButtonClicked;
            _view.ManageAttendanceButtonClicked += OnManageAttendanceButtonClicked;
            _view.CreateReportButtonClicked += OnCreateReportButtonClicked;
        }

        private void OnCreateReportButtonClicked(object sender, EventArgs e)
        {
            _view.Message = "Fabio Goose";
        }

        private void OnManageAttendanceButtonClicked(object sender, EventArgs e)
        {
            _view.Message = "Fabio Goose";
        }

        private void OnManageAppointmentsButtonClicked(object sender, EventArgs e)
        {
            _view.Message = "Fabio Goose";
        }

        private void OnManageCoursesButtonClicked(object sender, EventArgs e)
        {
            _view.Message = "Fabio Goose";
        }

        private void OnUpdateButtonClicked(object sender, EventArgs e)
        {
            _view.Message = "Fabio Goose";
        }

        public override void Load()
        {
            FetchData();
        }
        public override void FirstTimeInit()
        {
            _view.SetDataSource = _displayService.GetAllAppointmentsFor<APPOINTMENT>(host);
            _view.SetDataSource2 = _displayService.GetEmptyList<APPOINTMENT>();
            _view.SessionRowIndex = -1;
            _view.BindData();
        }
        private void FetchData()
        {
            var appointments = _displayService.GetAppointmentsCached<APPOINTMENT>();

        }
        private void OnRowSelected(object sender, EventArgs e)
        {
            _view.SessionRowIndex = _view.SelectedRowIndex;
            GetSelectedAppointmentIdFromGrid();
            //_view.Message = _view.SessionRowIndex.ToString();
            //var datakey = _view.SelectedRowValueDataKey;
            //_view.Message = datakey.ToString();       
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
            var datakey = _view.SelectedRowValueDataKey;
            _view.Message = datakey.ToString();
        }
    }
}
