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

        private AppointmentDTO _appointmentDTO = new AppointmentDTO();
        private APPOINTMENT _validatedAppointment;

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
            CreateAndValidateAppointment(DbAction.Create);
        }

        private void OnUpdateAppointmentButtonClicked(object sender, EventArgs e)
        {
            CreateAndValidateAppointment(DbAction.Update);
        }

        private void OnDeleteAppointmentButtonClicked(object sender, EventArgs e)
        {
            CreateAndValidateAppointment(DbAction.Delete);
        }

        private void OnNoButtonClicked(object sender, EventArgs e)
        {
            DecisionButtonsHide();
            _view.Message = "Ready.";
        }

        private void _OnYesButtonClicked(object sender, EventArgs e)
        {      
            DecisionButtonsHide();
            PerformJob();
        }

        private void CreateAppointmentDTOFromInput()
        {
            _appointmentDTO.CourseId = _view.CourseId;
            _appointmentDTO.AppointmentName = _view.AppointmentName;
            _appointmentDTO.Description = _view.Description;
            _appointmentDTO.Date = _view.Date;
            _appointmentDTO.StartTime = _view.StartTime;
            _appointmentDTO.EndTime = _view.EndTime;
            _appointmentDTO.UserName = _view.UserName;
            _appointmentDTO.Address = _view.Address;
            _appointmentDTO.PostalCode = _view.PostalCode;
            _appointmentDTO.IsObligatory = Convert.ToBoolean(_view.IsObligatory);
            _appointmentDTO.IsCancelled = Convert.ToBoolean(_view.IsCancelled);
        }

        private bool ValidateDTO()
        {
            _appointmentDTO.FillPropertyList(_appointmentDTO);

            bool appointmentDataIsValid = _appointmentDTO.IsValid(_appointmentDTO);
            if (appointmentDataIsValid)
            {
                 _validatedAppointment = _model.ConvertAppointmentDTOToAppointment(_appointmentDTO);
                return true;
            }
            else
            {
                List<string> validationMessages = _appointmentDTO.GetBrokenBusinessRules().ToList();
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

        private void CreateAndValidateAppointment(DbAction action)
        {
            CreateAppointmentDTOFromInput();
            bool DataIsValid = ValidateDTO();
            if(DataIsValid)
            {
                ConfirmAction(action);
            }  
        }

        private void ConfirmAction(DbAction action)
        {
            _view.JobState = (int)action;

            if(action == DbAction.Delete)
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

        private void PerformJob()
        {
            if(_view.JobState == (int)DbAction.Delete)
            {
                _appointmentHandler.Delete(_appointmentHandler.GetAppointmentByName(_view.AppointmentName));
            }
            if (_view.JobState == (int)DbAction.Create)
            {
                ReCheckDataAfterConfirmation();
                _appointmentHandler.Create(_validatedAppointment);
            }
            if (_view.JobState == (int)DbAction.Update)
            {
                ReCheckDataAfterConfirmation();
                UpdateAppointmentData();
            }
            UpdateDatabaseWithChanges((DbAction)_view.JobState);
        }

        private void ReCheckDataAfterConfirmation()
        {
            CreateAppointmentDTOFromInput();
            ValidateDTO();
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
            SaveResult saveResult = _appointmentHandler.SaveChengesToAppointments();

            bool IsSavedToDb = saveResult.Result > 0;
            if (!IsSavedToDb)
            {
                _view.Message = "Failed to save changes!" + saveResult.ErrorMessage;
                ContinueButtonsShow();
                return false;
            }
            return true;
        }

        private void UpdateAppointmentData()
        {
            var appointmentToUpdate = _appointmentHandler.GetAppointmentByName(_view.AppointmentNameList);

            appointmentToUpdate.CourseId = _validatedAppointment.CourseId;
            appointmentToUpdate.AppointmentName = _validatedAppointment.AppointmentName;
            appointmentToUpdate.UserName = _validatedAppointment.UserName;
            appointmentToUpdate.Description = _validatedAppointment.Description;
            appointmentToUpdate.Date = _validatedAppointment.Date;
            appointmentToUpdate.StartTime = _validatedAppointment.StartTime;
            appointmentToUpdate.EndTime = _validatedAppointment.EndTime;
            appointmentToUpdate.Address = _validatedAppointment.Address;
            appointmentToUpdate.PostalCode = _validatedAppointment.PostalCode;
            appointmentToUpdate.IsObligatory = _validatedAppointment.IsObligatory;
            appointmentToUpdate.IsCancelled = _validatedAppointment.IsCancelled;
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
