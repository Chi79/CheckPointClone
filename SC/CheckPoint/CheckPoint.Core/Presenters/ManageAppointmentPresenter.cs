using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointCommon.ServiceInterfaces;
using CheckPointCommon.FactoryInterfaces;
using CheckPointModel.Services;
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
        private readonly IManageAppointmentModel _model;
        private readonly IHandleAppointments _appointmentHandler;
        private readonly IFactory _factory;

        private AppointmentDTO _dTO = new AppointmentDTO();

        private string client = "Morten";  //TODO..this will be auto set later :D

        public ManageAppointmentPresenter(
                                          IManageAppointmentView manageAppointmentView,
                                          IManageAppointmentModel manageAppointmentModel,
                                          IHandleAppointments appointmentHandler,
                                          IFactory factory
                                          )

        {
            _view = manageAppointmentView;
            _model = manageAppointmentModel;
            _appointmentHandler = appointmentHandler;
            _factory = factory;

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
            var job =_factory.CreateAppointmentJobType(DbAction.CreateAppointment);
            ConfirmAction(job as JobServiceBase);
        }

        private void OnUpdateAppointmentButtonClicked(object sender, EventArgs e)
        {
            var job = _factory.CreateAppointmentJobType(DbAction.UpdateAppointment);
            ConfirmAction(job as JobServiceBase);
        }

        private void OnDeleteAppointmentButtonClicked(object sender, EventArgs e)
        {
            var job = _factory.CreateAppointmentJobType(DbAction.DeleteAppointment);
            ConfirmAction(job as JobServiceBase);
        }

        private void ConfirmAction(JobServiceBase job)
        {
            _view.JobState = (int)job.Jobtype;
            job.ItemName = _view.AppointmentNameList;
            _view.Message = job.ConfirmationMessage;
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
            var job = _factory.CreateAppointmentJobType((DbAction)_view.JobState) as JobServiceBase;
            var appointment = ConvertDTOToAppointment();

            job.ItemName = _view.AppointmentNameList;
            job.PerformTask(appointment);

            UpdateDatabaseWithChanges(job as JobServiceBase);
        }

        private APPOINTMENT ConvertDTOToAppointment()
        {
            var appointment = _model.ConvertToAppointment(_dTO) as APPOINTMENT;
            return appointment;
        }
    

        private void UpdateDatabaseWithChanges(JobServiceBase job)
        {
            bool saveCompleted = AttemptSaveChangesToAppointments(job);
            if (saveCompleted)
            {
                DisplayActionMessage(job);
            }
        }

        private bool AttemptSaveChangesToAppointments(JobServiceBase job)
        {

            SaveResult saveResult = job.SaveChanges();

            bool IsSavedToDb = saveResult.Result > 0;
            if (!IsSavedToDb)
            {
                _view.Message = "Failed to save changes!" + saveResult.ErrorMessage;
                ContinueButtonsShow();
                return false;
            }
            return true;
        }

        private void DisplayActionMessage(JobServiceBase job)
        {
            _view.Message = job.CompletedMessage;

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
            var appointmentToDisplay = _appointmentHandler.GetAppointmentByName(_view.AppointmentName) as APPOINTMENT;

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
            bool listIsFull = (_appointmentHandler.GetAllAppointmentsForClient<APPOINTMENT>(client).ToList().Count > 0);
            if (listIsFull)
            {
                DisplaySelectedAppointmentData();
            }
        }

        private void IsListEmpty()
        {
            bool ListIsEmpty = (_appointmentHandler.GetAllAppointmentsForClient<APPOINTMENT>(client).ToList().Count == 0);
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
