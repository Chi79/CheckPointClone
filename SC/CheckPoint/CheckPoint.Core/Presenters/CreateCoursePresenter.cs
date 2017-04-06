﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointPresenters.Bases;
using CheckPointCommon.FactoryInterfaces;
using CheckPointModel.Services;
using CheckPointDataTables.Tables;
using CheckPointModel.DTOs;
using CheckPointCommon.Structs;
using CheckPointCommon.Enums;
using CheckPointCommon.ServiceInterfaces;

namespace CheckPointPresenters.Presenters
{
    public class CreateCoursePresenter : PresenterBase
    {

        private readonly ICreateCourseView _view;
        private readonly ICreateCourseModel _model;
        private readonly IHandleCourses _courseService;
        private readonly ISessionService _sessionService;
        private readonly IFactory _factory;

        private CourseDTO _dTO = new CourseDTO();


        public CreateCoursePresenter(ICreateCourseView createCourseView,
                                     ICreateCourseModel createCourseModel,
                                     IHandleCourses courseService,
                                     ISessionService sessionService,
                                     IFactory factory )
        {

            _view = createCourseView;
            _model = createCourseModel;
            _factory = factory;
            _courseService = courseService;
            _sessionService = sessionService;

            _view.CreateNewCourse += OnCreateNewCourseButtonClicked;
            _view.Continue += OnContinueEvent;
            _view.YesButtonClicked += OnYesButtonClicked;
            _view.NoButtonClicked += OnNoButtonClicked;
            _view.BackToHomePageClicked += OnBackToHomePageClicked;

            _view.AddNewAppontmentToCourseClicked += OnAddNewAppontmentToCourseClicked;
            _view.AddExistingAppontmentToCourseClicked += OnAddExistingAppontmentToCourseClicked;
        }


        private void OnCreateNewCourseButtonClicked(object sender, EventArgs e)
        {
            var job = _factory.CreateCourseJobType(DbAction.CreateCourse);
            ConfirmAction(job as JobServiceBase);
        }

        private void ConfirmAction(JobServiceBase job)
        {
            _sessionService.JobState = (int)job.Actiontype;
            job.ItemName = _view.CourseName;
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
            CreateCourseDTOFromInput();

            bool courseDataIsValid = _dTO.IsValid(_dTO);
            if (courseDataIsValid)
            {
                PerformJob();
            }
            else
            {
                DisplayValidationMessage();
            }
        }

        private void CreateCourseDTOFromInput()
        {
            _dTO.UserName = _sessionService.LoggedInClient;
            _dTO.Name = _view.CourseName;
            _dTO.Description = _view.Description;
            _dTO.IsPrivate = Convert.ToBoolean(_view.IsPrivate);
            _dTO.IsObligatory = Convert.ToBoolean(_view.IsObligatory);

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

            var job = _factory.CreateCourseJobType((DbAction)_sessionService.JobState) as JobServiceBase;
            var course = ConvertDTOToCourse();

            job.ItemName = _view.CourseName;
            job.PerformTask(course);

            UpdateDatabaseWithChanges(job);
        }

        private COURSE ConvertDTOToCourse()
        {
            var course = _model.ConvertToCourse(_dTO) as COURSE;
            return course;
        }

        private void UpdateDatabaseWithChanges(JobServiceBase job)
        {

            SaveResult saveResult = job.SaveChanges();

            bool IsSavedToDb = saveResult.Result > 0;
            if (IsSavedToDb)
            {
                StoreNewCourseIdInSession(job);
                DisplayAddAppointmentToCourseButtons();
                _view.Message = "Add an appointment to the course";
            }
            else
            {
                _view.Message = "Failed to Save Course " + saveResult.ErrorMessage;
            }
        }
        public void StoreNewCourseIdInSession(JobServiceBase job)
        {
            var newlyCreatedCourse = _courseService.GetCourseByName(job.ItemName) as COURSE;
            _sessionService.SessionCourseId = newlyCreatedCourse.CourseId;

        }
        public void UpdateAddAppointmentToCourseStatus()
        {
            _sessionService.AddingAppointmentToCourseStatus = true;
        } 

        private void DisplayActionMessage(JobServiceBase job)
        {

            _view.Message = job.CompletedMessage;
            ContinueButtonsShow();
        }

        private void OnContinueEvent(object sender, EventArgs e)
        {
            _view.RedirectAfterClickEvent();
        }

        private void OnAddExistingAppontmentToCourseClicked(object sender, EventArgs e)
        {
            UpdateAddAppointmentToCourseStatus();
            _view.RedirectToAddExistingAppointmentToCourse();
        }

        private void OnAddNewAppontmentToCourseClicked(object sender, EventArgs e)
        {
            UpdateAddAppointmentToCourseStatus();
            _view.RedirectToAddNewAppointmentToCourse();
        }

        private void OnBackToHomePageClicked(object sender, EventArgs e)
        {
            _view.RedirectToHomePage();
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

        public void DisplayAddAppointmentToCourseButtons()
        {
            _view.AddExistingAppointmentToCourseButtonVisible = true;
            _view.AddNewAppointmentToCourseButtonVisible = true;
            _view.CreateCourseButtonVisible = false;
            _view.BackToHomePageButtonVisible = false;
        }
    }
}
