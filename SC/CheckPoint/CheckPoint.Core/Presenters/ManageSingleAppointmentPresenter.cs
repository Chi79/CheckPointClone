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


namespace CheckPointPresenters.Presenters
{
    public class ManageSingleAppointmentPresenter : PresenterBase
    {
        private readonly IManageSingleAppointmentView _view;
        private readonly IManageSingleAppointmentModel _model;

        private AppointmentDTO _dTO = new AppointmentDTO();

        public ManageSingleAppointmentPresenter(IManageSingleAppointmentView manageAppointmentView,
                                                IManageSingleAppointmentModel manageAppointmentModel)

        {

            _view = manageAppointmentView;
            _model = manageAppointmentModel;

        }


        private void OnUpdateAppointmentButtonClicked(object sender, EventArgs e)
        {
 
           _model.PrepareUpdateAppointmentJob();

            ConfirmAction();
        }

        private void OnDeleteAppointmentButtonClicked(object sender, EventArgs e)
        {

            _model.PrepareDeleteAppointmentJob();

            ConfirmAction();
        }

        private void OnBackToHomePageClicked(object sender, EventArgs e)
        {

            _view.RedirectToHostHomeView();

        }


        public override void FirstTimeInit()
        {

            DisplaySelectedAppointmentData();

        }

        public override void Load()
        {

            WireUpEvents();

        }

        public void WireUpEvents()
        {

            _view.UpdateAppointment += OnUpdateAppointmentButtonClicked;
            _view.ReloadPage += OnReloadPageEvent;
            _view.DeleteAppointment += OnDeleteAppointmentButtonClicked;
            _view.YesButtonClicked += _OnYesButtonClicked;
            _view.NoButtonClicked += OnNoButtonClicked;
            _view.BackToHomePage += OnBackToHomePageClicked;

        }

        private void OnReloadPageEvent(object sender, EventArgs e)
        {

            _model.RefreshAllAppointmentsForClient();  //refresh cache

            _view.RedirectAfterClickEvent();

            DisplaySelectedAppointmentData();

        }


        private void ConfirmAction()
        {

            _view.Message = _model.GetJobConfirmationMessage();

            DecisionButtonsShow();

        }

        private void OnNoButtonClicked(object sender, EventArgs e)
        {

            DecisionButtonsHide();

            _view.Message = "Ready.";

        }

        private void _OnYesButtonClicked(object sender, EventArgs e)
        {

            DecisionButtonsHide();

            bool DTOIsValid = ValidateDTO();
            if (DTOIsValid)
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
            _dTO.IsCancelled = Convert.ToBoolean(_view.IsCancelled);
            _dTO.IsPrivate = Convert.ToBoolean(_view.IsPrivate);

        }

        private void DisplayValidationMessage()
        {

            _view.Message = string.Empty;

            var validationMessages = _dTO.GetBrokenBusinessRules().ToList();

            foreach (string message in validationMessages)
            {
                _view.Message += message;
            }

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
            if(UpdateSuccessful)
            {
                _view.Message = _model.GetJobCompletedMessage();

                ContinueButtonsShow();

            }
            else
            {
                _view.Message = "Failed to save changes!" + _model.GetUpdateErrorMessage();
            }

        }


        private void DisplaySelectedAppointmentData()
        {

            var selectedAppointment = _model.GetAppointmentForClientByAppointmentId() as APPOINTMENT;

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

        private void ContinueButtonsShow()
        {
            _view.UpdateButtonVisible = false;
            _view.DeleteButtonVisible = false;
            _view.ContinueButtonVisible = true;
        }

        private void DecisionButtonsShow()
        {
            _view.UpdateButtonVisible = false;
            _view.DeleteButtonVisible = false;
            _view.ContinueButtonVisible = false;
            _view.NoButtonVisible = true;
            _view.YesButtonVisible = true;
        }

        private void DecisionButtonsHide()
        {
            _view.UpdateButtonVisible = true;
            _view.DeleteButtonVisible = true;
            _view.ContinueButtonVisible = false;
            _view.NoButtonVisible = false;
            _view.YesButtonVisible = false;
        }

        private void AllButtonsHide()
        {
            _view.UpdateButtonVisible = false;
            _view.DeleteButtonVisible = false;
            _view.ContinueButtonVisible = false;
        }

    }
}