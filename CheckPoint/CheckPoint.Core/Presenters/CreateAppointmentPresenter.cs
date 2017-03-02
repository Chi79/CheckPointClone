using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointCommon.FactoryInterfaces;
using CheckPointModel.Services;
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
        private readonly IFactory<JobServiceBase, DbAction> _factory;

        private AppointmentDTO _dTO = new AppointmentDTO();

        public CreateAppointmentPresenter(ICreateAppointmentView createAppointmentView, 
                                          ICreateAppointmentModel<APPOINTMENT, AppointmentDTO> createAppointmentModel,
                                          IHandleAppointments<APPOINTMENT, SaveResult> appointmentHandler,
                                          IFactory<JobServiceBase, DbAction> factory
                                          )
        {

            _view = createAppointmentView;
            _model = createAppointmentModel;
            _appointmentHandler = appointmentHandler;
            _factory = factory;

            _view.CreateNewAppointment += OnCreateNewAppointmentButtonClicked;
            _view.Continue += OnContinueEvent;
            _view.YesButtonClicked += OnYesButtonClicked;
            _view.NoButtonClicked += OnNoButtonClicked;
        }

        private void OnCreateNewAppointmentButtonClicked(object sender, EventArgs e)
        {
            var job = _factory.Create(DbAction.Create);
            ConfirmAction(job);
        }

        private void ConfirmAction(JobServiceBase job)
        {

            _view.JobState = (int)job.Actiontype;
            job.AppointmentName = _view.AppointmentName;
            _view.Message = job.ConfirmationMessage;
            DecisionButtonsShow();
        }

        private void OnNoButtonClicked(object sender, EventArgs e)
        {
            DecisionButtonsHide();
            _view.Message = "Ready.";
        }

        private void OnYesButtonClicked(object sender, EventArgs e)
        {
            DecisionButtonsHide();
            ValidateDTO();
        }

        private void ValidateDTO()
        {
            CreateAppointmentDTOFromInput();

            bool appointmentDataIsValid = _dTO.IsValid(_dTO);
            if (appointmentDataIsValid)
            {
                PerformJob();
            }
            else
            {
                DisplayValidationMessage();
            }
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

        private void DisplayValidationMessage()
        {
            _view.Message = string.Empty;

            var validationMessages = _dTO.GetBrokenBusinessRules().ToList();

            foreach (string message in validationMessages)
            {
                _view.Message += message;
            }
        }

        private void PerformJob()
        {

            var job = _factory.Create((DbAction)_view.JobState);
            var appointment = ConvertDTOToAppointment();

            job.AppointmentName = _view.AppointmentName;
            job.PerformTask(appointment);

            UpdateDatabaseWithChanges(job);
        }

        private APPOINTMENT ConvertDTOToAppointment()
        {
            var appointment = _model.ConvertToAppointment(_dTO);
            return appointment;
        }

        private void UpdateDatabaseWithChanges(JobServiceBase job)
        {

            bool saveCompleted = AttemptSaveChangesToDb(job);
            if (saveCompleted)
            {
                DisplayActionMessage(job);
                ContinueButtonsShow();
            }
        }

        private void DisplayActionMessage(JobServiceBase job)
        {

            _view.Message = job.CompletedMessage;
            ContinueButtonsShow();
        }

        private bool AttemptSaveChangesToDb(JobServiceBase job)
        {

            SaveResult saveResult = job.SaveChanges();

            bool IsSavedToDb = saveResult.Result > 0;
            if (!IsSavedToDb)
            {
                _view.Message = "Failed to Save Appointment " + saveResult.ErrorMessage;
                return false;
            }
            return true;
        }

        private void OnContinueEvent(object sender, EventArgs e)
        {
            _view.RedirectAfterClickEvent();
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
