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
using CheckPointModel.Entities;
using CheckPointCommon.Structs;

namespace CheckPointPresenters.Presenters
{
    public class ManageAppointmentPresenter : PresenterBase
    {
        private readonly IManageAppointmentView _view;
        private readonly IManageAppointmentModel<APPOINTMENT, AppointmentModel> _model;
        private readonly IUnitOfWork _uOW;

        private AppointmentModel _appointmentModel = new AppointmentModel();
        private APPOINTMENT _appointmentToSave;

        private string _errorMessage;
        private List<string> _validationErrorMessage;

        private List<string> _listOfAppointmentNames;
        private List<APPOINTMENT> _listOfAppointments;
        private List<APPOINTMENT> _selectedAppointment;
        private APPOINTMENT _appointmentToDisplay;
        private string _selectedapp;

        private string _loggedInUsername = "Morten";  //TODO..this will be auto set later :D

        public ManageAppointmentPresenter(IManageAppointmentView manageAppointmentView,
                                          IManageAppointmentModel<APPOINTMENT, AppointmentModel>
                                          manageAppointmentModel, IUnitOfWork unitOfWork)
        {
            _view = manageAppointmentView;
            _model = manageAppointmentModel;
            _uOW = unitOfWork;

            _view.UpdateAppointment += OnUpdateAppointmentButtonClicked;
            _view.FetchData += OnFetchDataEvent;
            _view.ReloadPage += OnReloadPageEvent;

        }
        public override void FirstTimeInit()
        {
            PopulateAppointmentList();
        }

        private void CreateAppointmentModelFromInput()
        {
            _appointmentModel.CourseId = Convert.ToInt32(_view.CourseId);
            _appointmentModel.AppointmentName = _view.AppointmentName;
            _appointmentModel.Description = _view.Description;
            _appointmentModel.Date = _view.Date;
            _appointmentModel.StartTime = _view.StartTime;
            _appointmentModel.EndTime = _view.EndTime;
            _appointmentModel.UserName = _view.UserName;
            _appointmentModel.Address = _view.Address;
            _appointmentModel.PostalCode = _view.PostalCode;
            _appointmentModel.IsObligatory = Convert.ToBoolean(_view.IsObligatory);
            _appointmentModel.IsCancelled = Convert.ToBoolean(_view.IsCancelled);
        }
        private bool AppointmentToCreateIsValid()
        {
            bool AppointmentFieldsAreValid = _appointmentModel.IsValid(_appointmentModel);
            if (AppointmentFieldsAreValid)
            {
                _appointmentToSave = _model.ConvertAppointmentModelToAppointment(_appointmentModel);
                return true;
            }
            else
            {
                _validationErrorMessage = _appointmentModel.GetBrokenBusinessRules().ToList();
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
        private void SaveAppointmentToDatabase(APPOINTMENT newAppointment)
        {
            _uOW.APPOINTMENTs.Add(newAppointment);
            bool saveCompleted = AttemptSaveToDb();
            if (saveCompleted)
            {
                _view.Message = "New Appointment Saved Succesfully!";
                SetButtonVisibilityState();
            }
            else
            {
                _view.Message = "Failed to Save Appointment" + _errorMessage;
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

        private void PopulateAppointmentList()
        {
            string user = _loggedInUsername;
            _listOfAppointments = _uOW.APPOINTMENTs.GetAllAppointmentsFor(user).ToList();                                          
            _listOfAppointmentNames = _listOfAppointments.Select(app => app.AppointmentName).ToList();

            _view.FillAppointmentList(_listOfAppointmentNames);
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
            _view.Date = _appointmentToDisplay.Date.ToString("dd/MM/yyyy");
            _view.StartTime = _appointmentToDisplay.StartTime.ToString();
            _view.EndTime = _appointmentToDisplay.EndTime.ToString();
            _view.Address = _appointmentToDisplay.Address;
            _view.PostalCode = _appointmentToDisplay.PostalCode.ToString();
            _view.UserName = _appointmentToDisplay.UserName;
            _view.IsObligatory = _appointmentToDisplay.IsObligatory.ToString();
            _view.IsCancelled = _appointmentToDisplay.IsCancelled.ToString();
            _view.AppointmentNameList = _selectedapp;
        }
        private void OnUpdateAppointmentButtonClicked(object sender, EventArgs e)
        {
            CreateAppointmentModelFromInput();
            _appointmentModel.FillPropertyList(_appointmentModel);

            bool appointmentDataIsValid = AppointmentToCreateIsValid();
            if (appointmentDataIsValid)
            {
                _appointmentToSave = _model.ConvertAppointmentModelToAppointment(_appointmentModel);
                SaveAppointmentToDatabase(_appointmentToSave);
            }
        }
        private void OnFetchDataEvent(object sender, EventArgs e)
        {
            _selectedapp = _view.AppointmentNameList;

            bool listIsNull = (_listOfAppointments == null);
            bool listNotEmpty = (_listOfAppointments.Count > 0);

            if (listIsNull)
            {
                PopulateAppointmentList();
                DisplaySelectedAppointmentData();
            }
            else if (listNotEmpty)
            {
                DisplaySelectedAppointmentData();
            }
            else
            {
                _view.UpdateButtonVisible = false;
                _view.Message = "No appointments to manage.";
            }
        }
        private void OnReloadPageEvent(object sender, EventArgs e)
        {
            _view.RedirectAfterClickEvent();
        }
        private void SetButtonVisibilityState()
        {
            _view.UpdateButtonVisible = false;
            _view.ContinueButtonVisible = true;
        }
    }
}
