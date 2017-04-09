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
using CheckPointModel.DTOs;

namespace CheckPointPresenters.Presenters
{
    public class AddSelectedAppointmentToCoursePresenter : PresenterBase
    {
        private IAddSelectedAppointmentToCourseView _view;
        private IAddSelectedAppointmentToCourseModel _model;
        private readonly IShowAppointments _displayService;

        public AddSelectedAppointmentToCoursePresenter(IAddSelectedAppointmentToCourseView view,
                                                       IAddSelectedAppointmentToCourseModel model,
                                                       IShowAppointments displayService)
        {
            _view = view;
            _model = model;
            _displayService = displayService;
        }

        public override void FirstTimeInit()
        {

            DisplaySelectedAppointmentData();

        }

        private void DisplaySelectedAppointmentData()
        {

            var selectedAppointment = _displayService.GetSelectedAppointmentByAppointmentId(_model.GetSessionAppointmentId()) as APPOINTMENT;

            _view.AppointmentName = selectedAppointment.AppointmentName;
            _view.Description = selectedAppointment.Description;
            _view.Date = selectedAppointment.Date.ToString("MM/dd/yyyy");
            _view.StartTime = selectedAppointment.StartTime.ToString();
            _view.EndTime = selectedAppointment.EndTime.ToString();
            _view.Address = selectedAppointment.Address;
            _view.PostalCode = selectedAppointment.PostalCode.ToString();
            _view.IsObligatory = selectedAppointment.IsObligatory.ToString();
            _view.IsCancelled = selectedAppointment.IsCancelled.ToString();
            _view.IsPrivate = selectedAppointment.IsPrivate.ToString();

        }

        private void SetFieldsToReadOnly()
        {
            _view.AppointmentNameReadOnly = true;
            _view.AppointmentDescriptionReadOnly = true;
            _view.DateReadOnly = true;
            _view.StartTimeReadOnly = true;
            _view.EndTimeReadOnly = true;
            _view.IsCancelledEnabled = false;
            _view.IsObligatoryEnabled = false;
            _view.PostalCodeReadOnly = true;
            _view.AddressReadOnly = true;
            _view.IsPrivateEnabled = false;
        }
    }
}
