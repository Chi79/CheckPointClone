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
    public class RecordedAppointmentAttendancePresenter : PresenterBase
    {

        private readonly IRecordedAppointmentAttendanceView _view;
        private readonly IRecordedAppointmentAttendanceModel _model;

        public RecordedAppointmentAttendancePresenter(IRecordedAppointmentAttendanceView view, IRecordedAppointmentAttendanceModel model)
        {

            _view = view;

            _model = model;

        }
        public override void FirstTimeInit()
        {

            ShowAppointmentData();

            ShowAttendeeData();

        }

        private void ShowAppointmentData()
        {

            _view.AppointmentsAppliedToHeaderSetDataSource = _model.GetEmptyAppointmentList();

            _view.AppointmentsAppliedToSetDataSource = _model.GetAppointmentByAppointmentId();

            _view.BindAppointmentData();

        }

        private void ShowAttendeeData()
        {

            _view.AppliedAttendeesHeaderSetDataSource = _model.GetEmptyClientList();

            _view.AppliedAttendeesSetDataSource = _model.GetAllAttendeesWhoAttendedTheAppointment();

            _view.BindAttendeeData();

        }

        public override void Load()
        {

            WireUpEvents();

        }

        private void WireUpEvents()
        {

            _view.ViewCompletedAppointmentsButtonClicked += OnViewCompletedAppointmentsButtonClicked;

        }

        private void OnViewCompletedAppointmentsButtonClicked(object sender, EventArgs e)
        {

            _view.RedirectToCompletedAppointmentsView();

        }

        private void UpdateGridViews()
        {

            ShowAppointmentData();
            ShowAttendeeData();

        }

    }
}
