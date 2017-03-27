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
    public class ManageSingleAppointmentPresenter : PresenterBase
    {
        private readonly IManageSingleAppointmentView _view;
        private readonly IManageSingleAppointmentModel _model;
        private readonly IShowAppointments _displayService;
        private readonly IFactory _factory;

        private AppointmentDTO _dTO = new AppointmentDTO();
        private string _client; 

        public ManageSingleAppointmentPresenter(
                                          IManageSingleAppointmentView manageAppointmentView,
                                          IManageSingleAppointmentModel manageAppointmentModel,
                                          IShowAppointments displayService,
                                          IFactory factory
                                          )

        {
            _view = manageAppointmentView;
            _model = manageAppointmentModel;
            _factory = factory;

            _displayService = displayService;

            _view.UpdateAppointment += OnUpdateAppointmentButtonClicked;
            _view.ReloadPage += OnReloadPageEvent;
            _view.DeleteAppointment += OnDeleteAppointmentButtonClicked;
            _view.YesButtonClicked += _OnYesButtonClicked;
            _view.NoButtonClicked += OnNoButtonClicked;
            _view.BackToHomePage += OnBackToHomePageClicked;
            _view.AddAppointmentToCourseButtonClicked += OnAddAppointmentToCourseButtonClicked;
            _view.BackToCoursesButtonClicked += OnBackToCoursesButtonClicked;
            _view.SelectAnotherAppointmentButtonClicked += OnSelectAnotherAppointmentButtonClicked;


            _client = _view.UserName;
        }


        private void OnAddAppointmentToCourseButtonClicked(object sender, EventArgs e)
        {
            var job = _factory.CreateAppointmentJobType(DbAction.AddExistingAppointmentToCourse);
            ConfirmAction(job as JobServiceBase);
        }

        private void OnBackToHomePageClicked(object sender, EventArgs e)
        {
            _view.RedirectToHostHomeView();
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

        private void OnSelectAnotherAppointmentButtonClicked(object sender, EventArgs e)
        {
            ResetAddAppointmentStatus();
            _view.RedirectToHostHomeView();
        }

        private void OnBackToCoursesButtonClicked(object sender, EventArgs e)
        {
            ResetAddAppointmentStatus();
            _view.RedirectToViewCourses();
        }

        public override void FirstTimeInit()
        {
            CheckAddAppointentToCourseStatus();

            DisplaySelectedAppointmentData();
        }

        private void CheckAddAppointentToCourseStatus()
        {
            bool AddingAppointmentToCourse = _view.AddAppointmentToCourseStatus;
            if(AddingAppointmentToCourse == true)
            {
                DisplayAddToCourseButtons();
                SetFieldsToReadOnly();
            }
        }

        private void OnReloadPageEvent(object sender, EventArgs e)
        {
            _displayService.GetAllAppointmentsFor<APPOINTMENT>(_client);  //refresh cache
            _view.RedirectAfterClickEvent();
            DisplaySelectedAppointmentData();
        }


        private void ConfirmAction(JobServiceBase job)
        {
            _view.JobState = (int)job.Actiontype;
            job.ItemId = _view.AppointmentId;
            _view.Message = job.ConfirmationMessage;
            DecisionButtonsShow();
        }

        private void OnNoButtonClicked(object sender, EventArgs e)
        {
            CheckIfAddingAppointmentIsRejected();
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
            job.ItemId = _view.AppointmentId;
            var appointment = ConvertDTOToAppointment();

            if (_view.JobState == (int)DbAction.AddExistingAppointmentToCourse)
            {
                appointment.CourseId = _view.SessionCourseId;
            }

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
            SaveResult saveResult = job.SaveChanges();

            bool IsSavedToDb = saveResult.Result > 0;
            if (IsSavedToDb)
            {

                DisplayActionMessage(job);
                CheckIfAppointmentWasAddedToCourse();
            }
            else
            {
                _view.Message = "Failed to save changes!" + saveResult.ErrorMessage;
                ContinueButtonsShow();
            }

        }

        private void CheckIfAppointmentWasAddedToCourse()
        {
            bool AppointmentWasAdded = _view.AddAppointmentToCourseStatus;
            if (AppointmentWasAdded == true)
            {
                ContinueWithCourseCreationButtonShow();
            }
            else
            {
                ContinueButtonsShow();
            }
        }

        private void CheckIfAddingAppointmentIsRejected()
        {
            bool AppointmentAddedIsRejected = _view.AddAppointmentToCourseStatus;
            if (AppointmentAddedIsRejected == true)
            {
                BackToCourseCreationOrSelectDifferentAppointmentButtonsShow();
            }
            else
            {
                DecisionButtonsHide();
                _view.Message = "Ready.";
            }
        }

        private void ResetAddAppointmentStatus()
        {
            _view.AddAppointmentToCourseStatus = false;
        }

        private void DisplayActionMessage(JobServiceBase job)
        {
            _view.Message = job.CompletedMessage;

            ContinueButtonsShow();
        }

        private void DisplaySelectedAppointmentData()
        {
             var selectedAppointment = _displayService.GetSelectedAppointmentByAppointmentId(_view.AppointmentId) as APPOINTMENT;

            _view.AppointmentName = selectedAppointment.AppointmentName;
            _view.Description = selectedAppointment.Description;
            _view.Date = selectedAppointment.Date.ToString("MM/dd/yyyy");
            _view.StartTime = selectedAppointment.StartTime.ToString();
            _view.EndTime = selectedAppointment.EndTime.ToString();
            _view.Address = selectedAppointment.Address;
            _view.PostalCode = selectedAppointment.PostalCode.ToString();
            _view.IsObligatory = selectedAppointment.IsObligatory.ToString();
            _view.IsCancelled = selectedAppointment.IsCancelled.ToString();
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
        private void DisplayAddToCourseButtons()
        {
            _view.UpdateButtonVisible = false;
            _view.DeleteButtonVisible = false;
            _view.ContinueButtonVisible = false;
            _view.BackToHomePageButtonVisible = false;
            _view.AddAppointmentToCourseButtonVisible = true;
        }

        private void ContinueWithCourseCreationButtonShow()
        {
            _view.BackToHomePageButtonVisible = false;
            _view.ContinueButtonVisible = false;
            _view.AddAppointmentToCourseButtonVisible = false;
            _view.BackToCoursesButtonVisible = true;
            //TODO show continue managing course button instead - finish manage course view first.
        }

        private void BackToCourseCreationOrSelectDifferentAppointmentButtonsShow()
        {
            _view.BackToCoursesButtonVisible = true;
            _view.SelectAnotherAppointmentButtonVisible = true;
            _view.AddAppointmentToCourseButtonVisible = false;
        }

        private void SetFieldsToReadOnly()
        {
            _view.AppointmentNameReadOnly = true;
            _view.AppointmentDescriptionReadOnly = true;
            _view.DateReadOnly = true;
            _view.StartTimeReadOnly = true;
            _view.EndTimeReadOnly = true;
            _view.IsCancelledEnabled = false;
            _view.IsObligatoryEnabled = false;
            _view.PostalCodeReadOnly = true;
            _view.AddressReadOnly = true;
        }

    }
}