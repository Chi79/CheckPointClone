using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointPresenters.Bases;
using CheckPointDataTables.Tables;
using CheckPointModel.DTOs;
using CheckPointCommon.Structs;
using CheckPointCommon.ServiceInterfaces;
using CheckPointCommon.Enums;

namespace CheckPointPresenters.Presenters
{
    public class CreateAppointmentPresenter : PresenterBase
    {
        private readonly ICreateAppointmentView _view;
        private readonly ICreateAppointmentModel<APPOINTMENT, AppointmentDTO> _model;
        private readonly IHandleAppointments<APPOINTMENT, SaveResult> _appointmentHandler; 

        private AppointmentDTO _dTO = new AppointmentDTO();
        private APPOINTMENT _validatedAppointment;

        public CreateAppointmentPresenter(ICreateAppointmentView createAppointmentView, 
                                          ICreateAppointmentModel<APPOINTMENT, AppointmentDTO> createAppointmentModel,
                                           IHandleAppointments<APPOINTMENT, SaveResult> appointmentHandler)
        {

            _view = createAppointmentView;
            _model = createAppointmentModel;
            _appointmentHandler = appointmentHandler;

            _view.CreateNewAppointment += OnCreateNewAppointmentButtonClicked;
            _view.Continue += OnContinueEvent;
            _view.YesButtonClicked += OnYesButtonClicked;
            _view.NoButtonClicked += OnNoButtonClicked;
        }

        private void OnNoButtonClicked(object sender, EventArgs e)
        {
            DecisionButtonsHide();
            _view.Message = "Ready.";
        }

        private void OnYesButtonClicked(object sender, EventArgs e)
        {
            DecisionButtonsHide();
            PerformJob();
        }

        private void OnContinueEvent(object sender, EventArgs e)
        {
            _view.RedirectAfterClickEvent();
        }

        private void OnCreateNewAppointmentButtonClicked(object sender, EventArgs e)
        {
            CreateAndValidateAppointment(DbAction.Create);
        }

        private void CreateAndValidateAppointment(DbAction action)
        {
            CreateAppointmentDTOFromInput();
            bool dataIsValid = ValidateDTO();
            if (dataIsValid)
            {
                ConfirmAction(action);
            }
        }

        private void ConfirmAction(DbAction action)
        {
            _view.JobState = (int)action;

            if (action == DbAction.Create)
            {
                _view.Message = "You are about to add this appointment! Do you wish to continue?";
            }
            DecisionButtonsShow();
        }

        private void PerformJob()
        {
            if (_view.JobState == (int)DbAction.Create)
            {
                ReCheckDataAfterConfirmation();
                _appointmentHandler.Create(_validatedAppointment);
            }
            UpdateDatabaseWithChanges((DbAction)_view.JobState);
        }

        private void ReCheckDataAfterConfirmation()
        {
            CreateAppointmentDTOFromInput();
            ValidateDTO();
        }

        private void CreateAppointmentDTOFromInput()
        {
  
            _dTO.CourseId = _view.CourseId;
            _dTO.AppointmentName = _view.AppointmentName;
            _dTO.Description = _view.Description;
            _dTO.Date = _view.Date;
            _dTO.StartTime = _view.StartTime;
            _dTO.EndTime = _view.EndTime;
            _dTO.UserName = _view.UserName;
            _dTO.Address = _view.Address;
            _dTO.PostalCode = _view.PostalCode;
            _dTO.IsObligatory = Convert.ToBoolean(_view.IsObligatory);
            _dTO.IsCancelled = Convert.ToBoolean(_view.IsCancelled);
        }

        private bool ValidateDTO()
        {

            bool appointmentDataIsValid = _dTO.IsValid(_dTO);
            if (appointmentDataIsValid)
            {
                _validatedAppointment = _model.ConvertToAppointment(_dTO);
                return true;
            }
            else
            {
                List<string> validationMessages = _dTO.GetBrokenBusinessRules().ToList();
                DisplayValidationMessage(validationMessages);
                return false;
            }
        }

        private void DisplayValidationMessage(List<string> validationMessages)
        {
            _view.Message = string.Empty;

            foreach (string message in validationMessages)
            {
                _view.Message += message;
            }
        }

        private void UpdateDatabaseWithChanges(DbAction action)
        {

            bool saveCompleted = AttemptSaveChangesToDb();
            if(saveCompleted)
            {
                DisplayActionMessage(action);
                ContinueButtonsShow();
            }
        }

        private void DisplayActionMessage(DbAction action)
        {
            if(action == DbAction.Create)
            {
                _view.Message = "New Appointment Saved Succesfully!";
            }
            ContinueButtonsShow();
        }

        private bool AttemptSaveChangesToDb()
        {
            SaveResult saveResult = _appointmentHandler.SaveChangesToAppointments();

            bool IsSavedToDb = saveResult.Result > 0;
            if (!IsSavedToDb)
            {
                _view.Message = "Failed to Save Appointment " + saveResult.ErrorMessage; 
                return false;
            }
            return true;
        }

        private void ContinueButtonsShow()
        {
            _view.CreateButtonVisible = false;
            _view.ContinueButtonVisible = true;
        }

        private void DecisionButtonsShow()
        {
            _view.ContinueButtonVisible = false;
            _view.CreateButtonVisible = false;
            _view.NoButtonVisible = true;
            _view.YesButtonVisible = true;
        }

        private void DecisionButtonsHide()
        {
            _view.ContinueButtonVisible = false;
            _view.CreateButtonVisible = true;
            _view.NoButtonVisible = false;
            _view.YesButtonVisible = false;
        }
    }
}
