using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointPresenters.Bases;
using CheckPointCommon.RepositoryInterfaces;
using CheckPointDataTables.Tables;


namespace CheckPointPresenters.Presenters
{
    public class HostHomePresenter : PresenterBase
    {
        private readonly IHostHomeView _view;
        private readonly IHostHomeModel _model;
        private readonly IUnitOfWork _uOW;

        private List<APPOINTMENT> appointments;
        private IEnumerable<object> apps;
        //TODO
        public HostHomePresenter(IHostHomeView hostHomeView, IHostHomeModel hostHomeModel, IUnitOfWork unitOfWork)
        {
            _view = hostHomeView;
            _model = hostHomeModel;
            _uOW = unitOfWork;

            _view.BindGrid += OnSortByDate;

            FetchData();
            var apps = from a in appointments
                       select new
                       {
                           a.CourseId,
                           a.AppointmentName,
                           a.Description,
                           a.Date,
                           a.StartTime,
                           a.EndTime,
                           a.Address,
                           a.PostalCode,
                           a.IsObligatory,
                           a.IsCancelled
                       };
            _view.SetDataSource = apps;
            _view.DataBind();
            _view.Message = "HostPage";
        }
        public override void Load()
        {
            FetchData();
        }
        public override void FirstTimeInit()
        {
            FetchData();
        }
        private void FetchData()
        {
            string host = "Morten";
            appointments = _uOW.APPOINTMENTs.GetAllAppointmentsFor(host).ToList();
        }

        private void OnSortByDate(object sender, EventArgs e)
        {
            var app = appointments.OrderBy(a => a.Date).ToList();
            apps = from a in app
                       select new
                       {
                           a.CourseId,
                           a.AppointmentName,
                           a.Description,
                           a.Date,
                           a.StartTime,
                           a.EndTime,
                           a.Address,
                           a.PostalCode,
                           a.IsObligatory,
                           a.IsCancelled
                       };
            _view.SetDataSource = apps;
            _view.DataBind();
        }
    }
}
