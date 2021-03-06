﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointPresenters.Bases;
using CheckPointDataTables.Tables;
using CheckPointModel.DTOs;


namespace CheckPointPresenters.Presenters
{
    public class CreateAppointmentPresenter : PresenterBase
    {
        private readonly ICreateAppointmentView _view;
        private readonly ICreateAppointmentModel _model;


        private AppointmentDTO _dTO = new AppointmentDTO();


        public CreateAppointmentPresenter(ICreateAppointmentView createAppointmentView,
                                          ICreateAppointmentModel createAppointmentModel)
        {

            _view = createAppointmentView;
            _model = createAppointmentModel;

        }

        public override void FirstTimeInit()
        {

            CheckAttemptToResaveStatus();

            HideIsCancelledField();
 
        }


        public override void Load()
        {

            WireUpEvents();

            CheckAttemptToResaveStatus();

            HideIsCancelledField();

        }

        private void CheckAttemptToResaveStatus()
        {

            bool attemptToResave = (bool)_model.GetChangesSavedSessionStatus();
            if (attemptToResave)
            {

                _view.RedirectToHomePage();

            }

        }

        private void WireUpEvents()
        {

            _view.CreateNewAppointment += OnCreateNewAppointmentButtonClicked;
            _view.Continue += OnContinueEvent;
            _view.YesButtonClicked += OnYesButtonClicked;
            _view.NoButtonClicked += OnNoButtonClicked;
          

        }


        private void OnCreateNewAppointmentButtonClicked(object sender, EventArgs e)
        {

            PrepareJobType();

            SaveAppointmentNameToSession();

            ConfirmJob();

        }


        private void PrepareJobType()
        {

          _model.PrepareCreateNewAppointmentJob();

        }

        private void SaveAppointmentNameToSession()
        {

            string appointmentName = _view.AppointmentName;

            _model.SaveAppointmentNameToSession(appointmentName);

        }


        private void ConfirmJob()
        {

            ShowMessagePanel();

            _view.Message = _model.GetJobConfirmationMessage();

            DecisionButtonsShow();

        }

        private void ShowMessagePanel()
        {

            _view.MessagePanelVisible = true;

        }

        private void HideMessagePanel()
        {

            _view.MessagePanelVisible = false;

        }

        private void OnNoButtonClicked(object sender, EventArgs e)
        {

            DecisionButtonsHide();
  
            HideMessagePanel();

        }

        private void OnYesButtonClicked(object sender, EventArgs e)
        {

            DecisionButtonsHide();

            bool DTOIsValid = ValidateDTO();
            if(DTOIsValid)
            {

                var appointment = ConvertDTOToAppointment();
                PerformJob(appointment);

            }
            else
            {

                DisplayValidationMessage();

            }

        }

        private bool ValidateDTO()
        {

            CreateAppointmentDTOFromInput();

            bool appointmentDataIsValid = _dTO.IsValid(_dTO);
            if (appointmentDataIsValid)
            {

                return true;

            }
            else
            {

                return false;

            }

        }


        private void CreateAppointmentDTOFromInput()
        {

            _dTO.AppointmentName = _view.AppointmentName;
            _dTO.Description = _view.Description;
            _dTO.Date = _view.Date;
            _dTO.StartTime = _view.StartTime;
            _dTO.EndTime = _view.EndTime;
            _dTO.UserName = _model.GetLoggedInClient();
            _dTO.Address = _view.Address;
            _dTO.PostalCode = _view.PostalCode;
            _dTO.IsObligatory = Convert.ToBoolean(_view.IsObligatory);
            _dTO.IsCancelled = false;
            _dTO.IsPrivate = Convert.ToBoolean(_view.IsPrivate);

        }

        private void DisplayValidationMessage()
        {

            ShowMessagePanel();

            _view.Message = string.Empty;

            var validationMessages = _dTO.GetBrokenBusinessRules().ToList();

            foreach (string message in validationMessages)
            {
                _view.Message += message;
            }

            ContinueButtonShow();

        }


        private void PerformJob(APPOINTMENT appointment)
        {

            _model.PerformJob(appointment);

            CheckChangesSaved();

        }

        private APPOINTMENT ConvertDTOToAppointment()
        {

            return  _model.ConvertToAppointment(_dTO) as APPOINTMENT;

        }

        private void CheckChangesSaved()
        {

            bool UpdateSuccessful = _model.UpdateDatabaseWithChanges();
            if (UpdateSuccessful)
            {

                _view.RedirectToChangesSavedPage();

            }
            else
            {

                ShowMessagePanel();

                _view.Message = "Failed to save changes!  <br />" + _model.GetUpdateErrorMessage();

                ContinueButtonShow();

            }

        }


        private void OnContinueEvent(object sender, EventArgs e)
        {

            HideMessagePanel();

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

        private void ContinueButtonShow()
        {

            _view.ContinueButtonVisible = true;

        }

        private void HideIsCancelledField()
        {

            _view.IsCancelledDropDownVisible = false;
            _view.IsCancelledLabelVisible = false;

        }
    }
}
