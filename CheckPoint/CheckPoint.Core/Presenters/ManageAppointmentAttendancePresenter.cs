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
    public class ManageAppointmentAttendancePresenter : PresenterBase
    {
        private readonly IManageAppointmentAttendanceView _view;
        private readonly IManageAppointmentAttendanceModel _model;

        public ManageAppointmentAttendancePresenter(IManageAppointmentAttendanceView view, IManageAppointmentAttendanceModel model)
        {
            _view = view;
            _model = model;
        }
        public override void FirstTimeInit()
        {
            ResetSessionState();
            ShowAppointmentData();
        }

        private void ResetSessionState()
        {
            _model.ResetSessionState();
        }

        private void ShowAppointmentData()
        {
            _view.AppointmentsAppliedToHeaderSetDataSource = _model.GetEmptyAppointmentList();
            _view.AppointmentsAppliedToSetDataSource = _model.GetAllAppointmentsWithAttendeeRequests();

            _view.BindAppointmentData();
        }

        private void ShowAttendeeData()
        {
            _view.AppliedAttendeesHeaderSetDataSource = _model.GetEmptyClientList();
            _view.AppliedAttendeesSetDataSource = null;

            _view.BindAttendeeData();
        }


        public override void Load()
        {
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            _view.AcceptAttendanceRequest += OnAcceptAttendanceRequestButtonClicked;
            _view.RowSelected += OnGridViewRowSelected;
            _view.RedirectToManageCourseAttendance += OnManageCourseAttendanceButtonClicked;
        }

        private void OnManageCourseAttendanceButtonClicked(object sender, EventArgs e)
        {
            _view.RedirectToManageCourseAttendanceView();
        }

        private void OnGridViewRowSelected(object sender, EventArgs e)
        {
            
        }

        private void OnAcceptAttendanceRequestButtonClicked(object sender, EventArgs e)
        {
            
        }
    }
}
