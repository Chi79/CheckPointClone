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

            _view.SortColumn += OnSortColumnClicked;
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
        }
        private void OnRowSelected(object sender, EventArgs e)
        {
            _view.SessionRowIndex = _view.SelectedRowIndex;
            _view.Message = _view.SessionRowIndex.ToString();          
        }

        private void OnSortColumnClicked(object sender, EventArgs e)
        {
            _view.Message = _view.ColumnTitle;
            var apps = _displayService.SortColumnBy(_view.ColumnTitle);
            _view.SetDataSource = apps;
            _view.BindData();
        }
    }
}
