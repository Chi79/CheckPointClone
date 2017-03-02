using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointCommon.ServiceInterfaces;
using CheckPointPresenters.Bases;
using CheckPointDataTables.Tables;
using CheckPointModel.DTOs;
using CheckPointCommon.Structs;
using CheckPointCommon.Enums;

namespace CheckPointPresenters.Presenters
{
    public class ManageAppointmentPresenter : PresenterBase
    {
        private readonly IManageAppointmentView _view;
        private readonly IManageAppointmentModel<APPOINTMENT, AppointmentDTO> _model;
        private readonly IHandleAppointments<APPOINTMENT, SaveResult> _appointmentHandler;

        private AppointmentDTO _dTO = new AppointmentDTO();

        private string client = "Morten";  //TODO..this will be auto set later :D

        public ManageAppointmentPresenter(
                                          IManageAppointmentView manageAppointmentView,
                                          IManageAppointmentModel<APPOINTMENT, AppointmentDTO> manageAppointmentModel,
                                          IHandleAppointments<APPOINTMENT, SaveResult> appointmentHandler
                                          )

        {
            _view = manageAppointmentView;
            _model = manageAppointmentModel;
            _appointmentHandler = appointmentHandler;

            _view.UpdateAppointment += OnUpdateAppointmentButtonClicked;
            _view.AddAppointment += OnAddAppointmentButtonClicked;
            _view.FetchData += OnFetchDataEvent;
            _view.ReloadPage += OnReloadPageEvent;
            _view.DeleteAppointment += OnDeleteAppointmentButtonClicked;
            _view.YesButtonClicked += _OnYesButtonClicked;
            _view.NoButtonClicked += OnNoButtonClicked;
        }

        public override void FirstTimeInit()
        {
            BindAppointmentNamesToViewList();
            CheckSelectedAppointmentStatus();
        }

        private void OnReloadPageEvent(object sender, EventArgs e)
        {
            _view.RedirectAfterClickEvent();
        }

        private void OnFetchDataEvent(object sender, EventArgs e)
        {
            CheckSelectedAppointmentStatus();
        }

        private void OnAddAppointmentButtonClicked(object sender, EventArgs e)
        {
            ConfirmAction(DbAction.Create);
        }

        private void OnUpdateAppointmentButtonClicked(object sender, EventArgs e)
        {
            ConfirmAction(DbAction.Update);
        }

        private void OnDeleteAppointmentButtonClicked(object sender, EventArgs e)
        {
            ConfirmAction(DbAction.Delete);
        }

        private void ConfirmAction(DbAction action)
        {
            _view.JobState = (int)action;

            if (action == DbAction.Delete)
            {
                _view.Message = "You are about to delete this appointment! Do you wish to continue?";
            }
            if (action == DbAction.Create)
            {
                _view.Message = "You are about to add this appointment! Do you wish to continue?";
            }
            if (action == DbAction.Update)
            {
                _view.Message = "You are about to update this appointment! Do you wish to continue?";
            }
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
            ValidateDTO();
        }

        private void ValidateDTO()
        {
            CreateAppointmentDTOFromInput();
 
            bool appointmentDataIsValid = _dTO.IsValid(_dTO);
            if(appointmentDataIsValid)
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
            if (_view.JobState == (int)DbAction.Delete)
            {
                var appointment = _appointmentHandler.GetAppointmentByName(_view.AppointmentName);
                _appointmentHandler.Delete(appointment);
            }
            if (_view.JobState == (int)DbAction.Create)
            {
                var appointment = ConvertDTOToAppointment();
                _appointmentHandler.Create(appointment);
            }
            if (_view.JobState == (int)DbAction.Update)
            {
                var appointment = ConvertDTOToAppointment();
                UpdateAppointmentData(appointment);
            }
            UpdateDatabaseWithChanges((DbAction)_view.JobState);
        }

        private APPOINTMENT ConvertDTOToAppointment()
        {
            var appointment = _model.ConvertToAppointment(_dTO);
            return appointment;
        }

        private void UpdateAppointmentData(APPOINTMENT validAppointment)
        {
            var appointmentToUpdate = _appointmentHandler.GetAppointmentByName(_view.AppointmentNameList);

            appointmentToUpdate.CourseId = validAppointment.CourseId;
            appointmentToUpdate.AppointmentName = validAppointment.AppointmentName;
            appointmentToUpdate.UserName = validAppointment.UserName;
            appointmentToUpdate.Description = validAppointment.Description;
            appointmentToUpdate.Date = validAppointment.Date;
            appointmentToUpdate.StartTime = validAppointment.StartTime;
            appointmentToUpdate.EndTime = validAppointment.EndTime;
            appointmentToUpdate.Address = validAppointment.Address;
            appointmentToUpdate.PostalCode = validAppointment.PostalCode;
            appointmentToUpdate.IsObligatory = validAppointment.IsObligatory;
            appointmentToUpdate.IsCancelled = validAppointment.IsCancelled;
        }

        private void UpdateDatabaseWithChanges(DbAction action)
        {
            bool saveCompleted = AttemptSaveChangesToAppointments();
            if (saveCompleted)
            {
                DisplayActionMessage(action);
            }
        }

        private bool AttemptSaveChangesToAppointments()
        {
            SaveResult saveResult = _appointmentHandler.SaveChangesToAppointments();

            bool IsSavedToDb = saveResult.Result > 0;
            if (!IsSavedToDb)
            {
                _view.Message = "Failed to save changes!" + saveResult.ErrorMessage;
                ContinueButtonsShow();
                return false;
            }
            return true;
        }

        private void DisplayActionMessage(DbAction action)
        {
            if(action == DbAction.Create)
            {
                _view.Message = "New Appointment Added Succesfully!";
            }
            if (action == DbAction.Update)
            {
                _view.Message = "New Appointment Updated Succesfully!";
            }
            if (action == DbAction.Delete)
            {
                _view.Message = "Appointment Deleted Succesfully!";
            }
            ContinueButtonsShow();
        }

        private void BindAppointmentNamesToViewList()
        {
            var allAppointmentNames = _appointmentHandler.GetAllAppointmentNamesForClient(client).ToList();
            _view.SetDataSource = (allAppointmentNames);
            _view.BindAppointmentList();
        }

        private void DisplaySelectedAppointmentData()
        {
            var appointmentToDisplay = _appointmentHandler.GetAppointmentByName(_view.AppointmentName);

            _view.CourseId = appointmentToDisplay.CourseId.ToString();
            _view.AppointmentName = appointmentToDisplay.AppointmentName;
            _view.Description = appointmentToDisplay.Description;
            _view.Date = appointmentToDisplay.Date.ToString("MM/dd/yyyy");
            _view.StartTime = appointmentToDisplay.StartTime.ToString();
            _view.EndTime = appointmentToDisplay.EndTime.ToString();
            _view.Address = appointmentToDisplay.Address;
            _view.PostalCode = appointmentToDisplay.PostalCode.ToString();
            _view.UserName = appointmentToDisplay.UserName;
            _view.IsObligatory = appointmentToDisplay.IsObligatory.ToString();
            _view.IsCancelled = appointmentToDisplay.IsCancelled.ToString();

            _view.AppointmentNameList = _view.AppointmentName;
        }

        private void CheckSelectedAppointmentStatus()
        {
            _view.AppointmentName = _view.AppointmentNameList;
            IsListFilled();
            IsListEmpty();
        }

        private void IsListFilled()
        {
            bool listIsFull = (_appointmentHandler.GetAllAppointmentsForClient(client).ToList().Count > 0);
            if (listIsFull)
            {
                DisplaySelectedAppointmentData();
            }
        }

        private void IsListEmpty()
        {
            bool ListIsEmpty = (_appointmentHandler.GetAllAppointmentsForClient(client).ToList().Count == 0);
            if (ListIsEmpty)
            {
                AllButtonsHide();
                _view.Message = "No appointments to manage.";
            }
        }

        private void ContinueButtonsShow()
        {
            _view.UpdateButtonVisible = false;
            _view.AddButtonVisible = false;
            _view.DeleteButtonVisible = false;
            _view.ContinueButtonVisible = true;
        }

        private void DecisionButtonsShow()
        {
            _view.UpdateButtonVisible = false;
            _view.AddButtonVisible = false;
            _view.DeleteButtonVisible = false;
            _view.ContinueButtonVisible = false;
            _view.NoButtonVisible = true;
            _view.YesButtonVisible = true;
        }

        private void DecisionButtonsHide()
        {
            _view.UpdateButtonVisible = true;
            _view.AddButtonVisible = true;
            _view.DeleteButtonVisible = true;
            _view.ContinueButtonVisible = false;
            _view.NoButtonVisible = false;
            _view.YesButtonVisible = false;
        }

        private void AllButtonsHide()
        {
            _view.UpdateButtonVisible = false;
            _view.AddButtonVisible = false;
            _view.DeleteButtonVisible = false;
            _view.ContinueButtonVisible = false;
        }
    }
}
