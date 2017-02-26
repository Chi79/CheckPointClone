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

        private List<string> _listOfAppointmentNames;
        private List<APPOINTMENT> _listOfAppointments;
        private List<APPOINTMENT> _selectedAppointment;
        private APPOINTMENT _appointmentToDisplay;
        private string _selectedapp;

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

        }

        public override void FirstTimeInit()
        {
            GetAppointmentList();
            SetAppointmentList();
            CheckAppointmentStatus();
        }
        private void OnReloadPageEvent(object sender, EventArgs e)
        {
            _view.RedirectAfterClickEvent();
        }
        private void OnFetchDataEvent(object sender, EventArgs e)
        {
            CheckAppointmentStatus();
        }
        private void OnAddAppointmentButtonClicked(object sender, EventArgs e)
        {
            Execute(DbAction.Create);
        }
        private void OnUpdateAppointmentButtonClicked(object sender, EventArgs e)
        {
            Execute(DbAction.Update);
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
   
        private void UpdateDatabaseWithChanges(DbAction action)
        {
            bool saveCompleted = AttemptSaveToDb();
            if (saveCompleted)
            {
                DisplayActionMessage(action);
            }
            else
            {
                _view.Message = "Failed to Add Appointment" + _errorMessage;
            }
        }
        private void DisplayActionMessage(DbAction action)
        {
            if(action == DbAction.Create)
            {
                _view.Message = "New Appointment Added Succesfully!";
                SetButtonVisibilityState();
            }
            if (action == DbAction.Update)
            {
                _view.Message = "New Appointment Updated Succesfully!";
                SetButtonVisibilityState();
            }
        }
        private void Execute(DbAction action)
        {
            CreateAppointmentDTOFromInput();
            bool appointmentIsValidated = ValidateDTO();
            if (appointmentIsValidated)
            {
                PerformAction(action);
            }
        }
        private void PerformAction(DbAction action)
        {
            if (action == DbAction.Create)
            {
                _uOW.APPOINTMENTs.Add(_validatedAppointment);
                UpdateDatabaseWithChanges(action);
            }
            if (action == DbAction.Update)
            {
                UpdateAppointmentData();
                UpdateDatabaseWithChanges(action);
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

        private void GetAppointmentList()
        {
            string user = _loggedInUsername;

            _listOfAppointments = _uOW.APPOINTMENTs.GetAllAppointmentsFor(user).ToList();
            _listOfAppointmentNames = _listOfAppointments.Select(app => app.AppointmentName).ToList();
        }

        private void SetAppointmentList()
        {
            _view.SetDataSource = (_listOfAppointmentNames);
            _view.BindAppointmentList();
        }

        private void SelectAppointmentToDisplay()
        {
            _selectedAppointment = _listOfAppointments 
                                  .Where(app => app.AppointmentName == _selectedapp).ToList();

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
            _view.AppointmentNameList = _selectedapp;
        }

        private void CheckAppointmentStatus()
        {
            bool newAppointmentIsSelected = !(_view.AppointmentNameList == _selectedapp);
            if (newAppointmentIsSelected)
            {
                _selectedapp = _view.AppointmentNameList;

                GetAppointmentList();
                IsListFull();
                IsListEmpty();
            }
        }

        private void IsListFull()
        {
            bool listIsFull = (_listOfAppointments.Count > 0);
            if (listIsFull)
            {
                DisplaySelectedAppointmentData();
            }
        }

        private void IsListEmpty()
        {
            bool ListIsEmpty = (_listOfAppointments.Count == 0);
            if (ListIsEmpty)
            {
                _view.UpdateButtonVisible = false;
                _view.AddButtonVisible = false;
                _view.Message = "No appointments to manage.";
            }
        }

        private void SetButtonVisibilityState()
        {
            _view.UpdateButtonVisible = false;
            _view.AddButtonVisible = false;
            _view.ContinueButtonVisible = true;
        }
    }
}
