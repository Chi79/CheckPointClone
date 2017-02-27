using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointPresenters.Bases;
using CheckPointCommon.RepositoryInterfaces;
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
        private readonly IUnitOfWork _uOW;

        private AppointmentDTO _appointmentDTO = new AppointmentDTO();
        private APPOINTMENT _validatedAppointment;
        private APPOINTMENT _appointmentToUpdate;

        private string _errorMessage;
        private List<string> _validationErrorMessage;

        private List<string> _allAppointmentNames;
        private List<APPOINTMENT> _allAppointmentsForClient;
        private List<APPOINTMENT> _selectedAppointment;
        private APPOINTMENT _appointmentToDisplay;
        private string _selectedAppointmentName;


        private string _loggedInUsername = "Morten";  //TODO..this will be auto set later :D

        public ManageAppointmentPresenter(IManageAppointmentView manageAppointmentView,
                                          IManageAppointmentModel<APPOINTMENT, AppointmentDTO>
                                          manageAppointmentModel, IUnitOfWork unitOfWork)

        {
            _view = manageAppointmentView;
            _model = manageAppointmentModel;
            _uOW = unitOfWork;

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
            GetAllAppointmentForClient();
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
            Execute(DbAction.Create);
        }

        private void OnUpdateAppointmentButtonClicked(object sender, EventArgs e)
        {
            Execute(DbAction.Update);
        }

        private void OnDeleteAppointmentButtonClicked(object sender, EventArgs e)
        {
            Execute(DbAction.Delete);
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
                _validationErrorMessage = _appointmentDTO.GetBrokenBusinessRules().ToList();
                DisplayValidationMessage();
                return false;
            }
        }

        private void DisplayValidationMessage()
        {
            _view.Message = string.Empty;

            foreach (string message in _validationErrorMessage)
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

        private void Execute(DbAction action)
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
                CheckSelectedAppointmentStatus();
                _uOW.APPOINTMENTs.Remove(_appointmentToDisplay);
            }
            if (_view.JobState == (int)DbAction.Create)
            {
                FinalCheck();
                _uOW.APPOINTMENTs.Add(_validatedAppointment);
            }
            if (_view.JobState == (int)DbAction.Update)
            {
                FinalCheck();
                UpdateAppointmentData();
            }
            UpdateDatabaseWithChanges((DbAction)_view.JobState);
        }

        private void FinalCheck()
        {
            CreateAppointmentDTOFromInput();
            ValidateDTO();
        }

        private void UpdateDatabaseWithChanges(DbAction action)
        {
            bool saveCompleted = AttemptSaveToDb();
            if (saveCompleted)
            {
                DisplayActionMessage(action);
            }
            else
            {
                _view.Message = "Failed to save changes!" + _errorMessage;
            }
        }

        private bool AttemptSaveToDb()
        {
            SaveResult saveResult = _uOW.Complete();

            bool IsSavedToDb = saveResult.Result > 0;
            if (!IsSavedToDb)
            {
                _errorMessage = saveResult.ErrorMessage;
                return false;
            }
            return true;
        }

        private void UpdateAppointmentData()
        {
            _appointmentToUpdate = _uOW.APPOINTMENTs.GetAppointmentByAppointmentName(_view.AppointmentNameList);

            _appointmentToUpdate.CourseId = _validatedAppointment.CourseId;
            _appointmentToUpdate.AppointmentName = _validatedAppointment.AppointmentName;
            _appointmentToUpdate.UserName = _validatedAppointment.UserName;
            _appointmentToUpdate.Description = _validatedAppointment.Description;
            _appointmentToUpdate.Date = _validatedAppointment.Date;
            _appointmentToUpdate.StartTime = _validatedAppointment.StartTime;
            _appointmentToUpdate.EndTime = _validatedAppointment.EndTime;
            _appointmentToUpdate.Address = _validatedAppointment.Address;
            _appointmentToUpdate.PostalCode = _validatedAppointment.PostalCode;
            _appointmentToUpdate.IsObligatory = _validatedAppointment.IsObligatory;
            _appointmentToUpdate.IsCancelled = _validatedAppointment.IsCancelled;
        }

        private void GetAllAppointmentForClient()
        {
            string client = _loggedInUsername;

            _allAppointmentsForClient = _uOW.APPOINTMENTs.GetAllAppointmentsFor(client).ToList();
            _allAppointmentNames = _allAppointmentsForClient.Select(app => app.AppointmentName).ToList();
        }

        private void BindAppointmentNamesToViewList()
        {
            _view.SetDataSource = (_allAppointmentNames);
            _view.BindAppointmentList();
        }

        private void SelectAppointmentToDisplay()
        {
            _selectedAppointment = _allAppointmentsForClient 
                                  .Where(app => app.AppointmentName == _selectedAppointmentName).ToList();

            _appointmentToDisplay = _selectedAppointment.FirstOrDefault();
        }

        private void DisplaySelectedAppointmentData()
        {
            SelectAppointmentToDisplay();

            _view.CourseId = _appointmentToDisplay.CourseId.ToString();
            _view.AppointmentName = _appointmentToDisplay.AppointmentName;
            _view.Description = _appointmentToDisplay.Description;
            _view.Date = _appointmentToDisplay.Date.ToString("MM/dd/yyyy");
            _view.StartTime = _appointmentToDisplay.StartTime.ToString();
            _view.EndTime = _appointmentToDisplay.EndTime.ToString();
            _view.Address = _appointmentToDisplay.Address;
            _view.PostalCode = _appointmentToDisplay.PostalCode.ToString();
            _view.UserName = _appointmentToDisplay.UserName;
            _view.IsObligatory = _appointmentToDisplay.IsObligatory.ToString();
            _view.IsCancelled = _appointmentToDisplay.IsCancelled.ToString();
            _view.AppointmentNameList = _selectedAppointmentName;
        }

        private void CheckSelectedAppointmentStatus()
        {
            bool newAppointmentIsSelected = !(_view.AppointmentNameList == _selectedAppointmentName);
            if (newAppointmentIsSelected)
            {
                _selectedAppointmentName = _view.AppointmentNameList;

                GetAllAppointmentForClient();
                IsListFilled();
                IsListEmpty();
            }
        }

        private void IsListFilled()
        {
            bool listIsFull = (_allAppointmentsForClient.Count > 0);
            if (listIsFull)
            {
                DisplaySelectedAppointmentData();
            }
        }

        private void IsListEmpty()
        {
            bool ListIsEmpty = (_allAppointmentsForClient.Count == 0); 
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
