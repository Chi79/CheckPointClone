using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointCommon.ServiceInterfaces;
using CheckPointPresenters.Bases;
using CheckPointCommon.RepositoryInterfaces;
using CheckPointDataTables.Tables;


namespace CheckPointPresenters.Presenters
{
    public class HostHomePresenter : PresenterBase
    {
        private readonly IHostHomeView _view;
        private readonly IHostHomeModel _model;
        private readonly IShowAppointments<APPOINTMENT,object> _displayService;

        string host = "Morten";
        //TODO
        public HostHomePresenter(IHostHomeView hostHomeView, IHostHomeModel hostHomeModel,
                                 IShowAppointments<APPOINTMENT ,object> displayService)
        {
            _view = hostHomeView;
            _model = hostHomeModel;
            _displayService = displayService;

            _view.BindGrid += OnSortByDate;
        }
        public override void Load()
        {
            FetchData();
        }
        public override void FirstTimeInit()
        {
            FetchData();
            var apps = _displayService.GetAllAppointmentColumns();
            _view.SetDataSource = apps;
            _view.SetDataSource2 = _displayService.GetAllAppointmentsFor(host);
            _view.DataBind();
            _view.Message = "HostPage";
        }
        private void FetchData()
        {
            var appointments = _displayService.GetAllAppointmentsFor(host).ToList();
        }

        private void OnSortByDate(object sender, EventArgs e)
        {
            var apps = _displayService.GetAppointmentsSortedByDate();
            _view.SetDataSource = apps;
            _view.SetDataSource2 = apps;
            _view.DataBind();
        }
    }
}
