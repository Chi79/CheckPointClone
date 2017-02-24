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
        private readonly IManageAppointmentView _manageAppointmentView;
        private readonly IManageAppointmentModel<APPOINTMENT, AppointmentModel> _manageAppointmentModel;
        private readonly IUnitOfWork _unitOfWork;

        private AppointmentModel _appointmentModel = new AppointmentModel();
        private APPOINTMENT _appointmentToSave;

        private string _errorMessage;
        private List<string> _validationErrorMessage;

        private List<string> _listOfAppointmentNames;
        private List<APPOINTMENT> _listOfAppointments;
        private List<APPOINTMENT> _selectedAppointment;
        private APPOINTMENT _appointmentToDisplay;
        private string _selectedapp;

        private string _loggedInUsername = "Bono";  //TODO..this will be auto set later :D

        public ManageAppointmentPresenter(IManageAppointmentView manageAppointmentView, IManageAppointmentModel<APPOINTMENT, AppointmentModel>
                                          manageAppointmentModel, IUnitOfWork unitOfWork)
        {
            _manageAppointmentView = manageAppointmentView;
            _manageAppointmentModel = manageAppointmentModel;
            _unitOfWork = unitOfWork;

            _manageAppointmentView.UpdateAppointment += OnUpdateAppointmentButtonClicked;
            _manageAppointmentView.FetchData += OnFetchDataEvent;
            _manageAppointmentView.ReloadPage += OnReloadPageEvent;

        }
        public override void FirstTimeInit()
        {
            PopulateAppointmentList();
        }

        private void CreateAppointmentModelFromInput()
        {
            _appointmentModel.AppointmentName = _manageAppointmentView.AppointmentName;
            _appointmentModel.Description = _manageAppointmentView.Description;
            _appointmentModel.Date = _manageAppointmentView.Date;
            _appointmentModel.FromTime = _manageAppointmentView.FromTime;
            _appointmentModel.ToTime = _manageAppointmentView.ToTime;
            _appointmentModel.UserName = _manageAppointmentView.UserName;
            _appointmentModel.StreetAddress = _manageAppointmentView.StreetAddress;
            _appointmentModel.PostalCode = _manageAppointmentView.PostalCode;
            _appointmentModel.IsObligatory = Convert.ToBoolean(_manageAppointmentView.IsObligatory);
            _appointmentModel.Private = Convert.ToBoolean(_manageAppointmentView.Private);
            _appointmentModel.IsCancelled = Convert.ToBoolean(_manageAppointmentView.IsCancelled);
        }
        private bool AppointmentToCreateIsValid()
        {
            bool AppointmentFieldsAreValid = _appointmentModel.IsValid(_appointmentModel);
            if (AppointmentFieldsAreValid)
            {
                _appointmentToSave = _manageAppointmentModel.ConvertAppointmentModelToAppointment(_appointmentModel);
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
            _manageAppointmentView.Message = string.Empty;

            foreach (string message in _validationErrorMessage)
            {
                _manageAppointmentView.Message += message;
            }
        }
        private void SaveAppointmentToDatabase(APPOINTMENT newAppointment)
        {
            _unitOfWork.APPOINTMENTs.Add(newAppointment);
            bool saveCompleted = AttemptSaveToDb();
            if (saveCompleted)
            {
                _manageAppointmentView.Message = "New Appointment Saved Succesfully!";
                SetButtonVisibilityState();
            }
            else
            {
                _manageAppointmentView.Message = "Failed to Save Appointment" + _errorMessage;
            }
        }

        private bool AttemptSaveToDb()
        {
            SaveResult saveResult = _unitOfWork.myComplete();
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
            _listOfAppointments = _unitOfWork.APPOINTMENTs.GetAllAppointmentsFor(user).ToList();                                          
            _listOfAppointmentNames = _listOfAppointments.Select(app => app.AppointmentName).ToList();

            _manageAppointmentView.FillAppointmentList(_listOfAppointmentNames);
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

            _manageAppointmentView.AppointmentName = _appointmentToDisplay.AppointmentName;
            _manageAppointmentView.Description = _appointmentToDisplay.Description;
            _manageAppointmentView.Date = _appointmentToDisplay.Date.ToString("dd/MM/yyyy");
            _manageAppointmentView.FromTime = _appointmentToDisplay.FromTime.ToString();
            _manageAppointmentView.ToTime = _appointmentToDisplay.ToTime.ToString();
            _manageAppointmentView.StreetAddress = _appointmentToDisplay.StreetAddress;
            _manageAppointmentView.PostalCode = _appointmentToDisplay.PostalCode.ToString();
            _manageAppointmentView.UserName = _appointmentToDisplay.UserName;
            _manageAppointmentView.Private = _appointmentToDisplay.Private.ToString();
            _manageAppointmentView.IsObligatory = _appointmentToDisplay.IsObligatory.ToString();
            _manageAppointmentView.IsCancelled = _appointmentToDisplay.IsCancelled.ToString();
        }
        private void OnUpdateAppointmentButtonClicked(object sender, EventArgs e)
        {
            CreateAppointmentModelFromInput();
            _appointmentModel.FillPropertyList(_appointmentModel);

            bool appointmentDataIsValid = AppointmentToCreateIsValid();
            if (appointmentDataIsValid)
            {
                _appointmentToSave = _manageAppointmentModel.ConvertAppointmentModelToAppointment(_appointmentModel);
                SaveAppointmentToDatabase(_appointmentToSave);
            }
        }
        private void OnFetchDataEvent(object sender, EventArgs e)
        {
            _selectedapp = _manageAppointmentView.AppointmentNameList;
            if (_listOfAppointments == null)
            {
                PopulateAppointmentList();
                DisplaySelectedAppointmentData();
            }
        }
        private void OnReloadPageEvent(object sender, EventArgs e)
        {
            _manageAppointmentView.RedirectAfterClickEvent();
        }
        private void SetButtonVisibilityState()
        {
            _manageAppointmentView.UpdateButtonVisible = false;
            _manageAppointmentView.ContinueButtonVisible = true;
        }
    }
}
