using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ViewInterfaces;
using CheckPointCommon.ModelInterfaces;
using CheckPointPresenters.Bases;
using CheckPointDataTables.Tables;

namespace CheckPointPresenters.Presenters
{
    public class ApplyToAttendAppointmentPresesnter : PresenterBase
    {

        private readonly IApplyToAttendAppointmentView _view;
        private readonly IApplyToAttendAppointmentModel _model;

        public ApplyToAttendAppointmentPresesnter(IApplyToAttendAppointmentView view, IApplyToAttendAppointmentModel model)
        {

            _view = view;
            _model = model;

        }

        public override void FirstTimeInit()
        {

            DisplaySelectedAppointmentData();

            SetFieldsToReadOnly();

            DisplayConfirmationMessage();

        }

        public void DisplayConfirmationMessage()
        {

            _view.Message = "Are you sure you wish to attend this appointment?";

        }

        private void DisplaySelectedAppointmentData()
        {

            var selectedAppointment = _model.GetPublicAppointmentByAppointmentId() as APPOINTMENT;

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

        public override void Load()
        {

            WireUpEvents();

        }

        public void WireUpEvents()
        {

            _view.ContinueButtonClicked += OnContinueButtonClicked;
            _view.YesButtonClicked += OnYesButtonClicked;
            _view.NoButtonClicked += OnNoButtonClicked;

        }

        private void OnNoButtonClicked(object sender, EventArgs e)
        {

            _view.RedirectToFindAppointmentsView();

        }

        private void OnYesButtonClicked(object sender, EventArgs e)
        {

            CreateAttendee();

        }

        public void CreateAttendee()
        {

            _model.CreateAttendee();


            CheckIfAttendeeIsSavedToDB();

        }

        public void CheckIfAttendeeIsSavedToDB()
        {

            bool AttendeeIsSavedToDB = _model.UpdateDatabaseWithChanges();
            if(AttendeeIsSavedToDB)
            {

                _view.Message = _model.GetJobCompletedMessage();
      
            }
            else
            {

                _view.Message = "Failed to save changes!" + _model.GetUpdateErrorMessage();

            }
            DisplayContinueButtons();
        }

        public void DisplayContinueButtons()
        {

            _view.ContinueButtonVisible = true;
            _view.YesButtonVisible = false;
            _view.NoButtonVisible = false;

        }

        public void SetFieldsToReadOnly()
        {

            _view.AddressReadOnly = true;
            _view.AppointmentDescriptionReadOnly = true;
            _view.AppointmentNameReadOnly = true;
            _view.DateReadOnly = true;
            _view.EndTimeReadOnly = true;
            _view.IsCancelledEnabled = false;
            _view.IsObligatoryEnabled = false;
            _view.IsPrivateEnabled = false;
            _view.PostalCodeReadOnly = true;
            _view.StartTimeReadOnly = true;

        }

        private void OnContinueButtonClicked(object sender, EventArgs e)
        {

            _view.RedirectToFindAppointmentsView();
         
        }
    }
}
