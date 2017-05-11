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

            ShowData();
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
           //display attendee stamp data for selected appointment
        }

        private void ResetSessionState()
        {
            _model.ResetSessionState();
        }

        private void ShowData()
        {
            _view.AppointmentsHistoryToHeaderSetDataSource = GetEmptyAppointmentList();

            _view.AppointmentsHistoryToSetDataSource = GetAttendedAppointmentsForUser();

            _view.BindAppointmentData();
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
