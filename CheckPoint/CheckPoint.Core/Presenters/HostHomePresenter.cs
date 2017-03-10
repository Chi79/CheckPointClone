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
        private readonly IShowAppointments<APPOINTMENT, object> _displayService;

        string host = "Morten";
        //TODO

        public HostHomePresenter(IHostHomeView hostHomeView, IHostHomeModel hostHomeModel,
                                 IShowAppointments<APPOINTMENT, object> displayService)
        {
            _view = hostHomeView;
            _model = hostHomeModel;
            _displayService = displayService;

            _view.SortColumnsByPropertyAscending += OnSortColumnsAscendingClicked;
            _view.SortColumnsByPropertyDescending += OnSortColumnsDescendingClicked;
            _view.RowSelected += OnRowSelected;
        }

        public override void Load()
        {
            FetchData();
        }
        public override void FirstTimeInit()
        {
            _view.SetDataSource = _displayService.GetAllAppointmentsFor(host);
            _view.SessionRowIndex = -1;
            _view.BindData();
        }
        private void FetchData()
        {
            var appointments = _displayService.GetAllAppointmentsFor(host);
            //var appointments = _displayService.Cache;

        }
        private void OnRowSelected(object sender, EventArgs e)
        {
            _view.SessionRowIndex = _view.SelectedRowIndex;
            _view.Message = _view.SessionRowIndex.ToString();          
        }

        private void OnSortColumnsAscendingClicked(object sender, EventArgs e)
        {
            var apps = _displayService.GetAppointmentsSortedByPropertyAscending(_view.ColumnName);
            _view.SetDataSource = apps;
            _view.BindData();
        }
        private void OnSortColumnsDescendingClicked(object sender, EventArgs e)
        {
            var apps = _displayService.GetAppointmentsSortedByPropertyDescending(_view.ColumnName);
            _view.SetDataSource = apps;
            _view.BindData();
        }
    }
}
