using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointPresenters.Bases;
using CheckPointCommon.ViewInterfaces;
using CheckPointCommon.ModelInterfaces;
using CheckPointDataTables.Tables;
using CheckPointModel.DTOs;

namespace CheckPointPresenters.Presenters
{
    public class UpdateCoursePresenter : PresenterBase
    {

        private readonly IUpdateCourseView _view;
        private readonly IUpdateCourseModel _model;

        private CourseDTO _dTO = new CourseDTO();

        public UpdateCoursePresenter(IUpdateCourseView view, IUpdateCourseModel model)
        {

            _view = view;
            _model = model;

   
            _view.UpdateCourseButtonClicked += OnUpdateCourseButtonClicked;
            _view.YesButtonClicked += OnYesButtonClicked;
            _view.NoButtonClicked += OnNoButtonClicked;
            _view.ContinueButtonClicked += OnContinueButtonClicked;

        }

        private void OnContinueButtonClicked(object sender, EventArgs e)
        {

            HideMessagePanel();

        }

        public override void FirstTimeInit()
        {

            CheckAttemptToResaveStatus();

            DisplaySelectedCourseData();

        }

        public override void Load()
        {

            CheckAttemptToResaveStatus();

        }

        private void CheckAttemptToResaveStatus()
        {

            bool attemptToResave = (bool)_model.GetChangesSavedSessionStatus();
            if (attemptToResave)
            {

                _view.RedirectToHostCoursesPage();

            }

        }

        private void DisplaySelectedCourseData()
        {

            var selectedCourse = _model.GetSelectedCourseByCourseId() as COURSE;

            _view.CourseName = selectedCourse.Name;
            _view.Description = selectedCourse.Description;
            _view.IsObligatory = selectedCourse.IsObligatory.ToString();
            _view.IsPrivate = selectedCourse.IsPrivate.ToString();

        }

        private void OnNoButtonClicked(object sender, EventArgs e)
        {

            DecisionButtonsHide();

            HideMessagePanel();

        }

        private void OnYesButtonClicked(object sender, EventArgs e)
        {

            DecisionButtonsHide();

            bool DTOIsValid = ValidateDTO();
            if (DTOIsValid)
            {

                var course = ConvertDTOToCourse();
                PerformJob(course);

            }
            else
            {

                DisplayValidationMessage();

            }

        }

        private bool ValidateDTO()
        {

            CreateCourseDTOFromInput();

            bool courseDataIsValid = _dTO.IsValid(_dTO);
            if (courseDataIsValid)
            {

                return true;

            }
            else
            {

                return false;

            }

        }

        private COURSE ConvertDTOToCourse()
        {

            return _model.ConvertToCourse(_dTO) as COURSE;

        }

        private void CreateCourseDTOFromInput()
        {

            _dTO.UserName = _model.GetLoggedInClient();
            _dTO.Name = _view.CourseName;
            _dTO.Description = _view.Description;
            _dTO.IsObligatory = Convert.ToBoolean(_view.IsObligatory);
            _dTO.IsPrivate = Convert.ToBoolean(_view.IsPrivate);

        }

        private void OnUpdateCourseButtonClicked(object sender, EventArgs e)
        {

            _model.PrepareUpdateCourseJob();

            ConfirmAction();

        }

        private void DisplayValidationMessage()
        {
            ShowMessagePanel();

            _view.Message = string.Empty;

            var validationMessages = _dTO.GetBrokenBusinessRules().ToList();

            foreach (string message in validationMessages)
            {
                _view.Message += message;
            }

            ContinueButtonShow();

        }

        private void PerformJob(COURSE course)
        {

            _model.PerformJob(course);

            CheckChangesSaved();

        }


        private void CheckChangesSaved()
        {

            bool UpdateSuccessful = _model.UpdateDatabaseWithChanges();
            if (UpdateSuccessful)
            {

                RefreshCourseCache();

                SetCourseUpdatedStatus();

                _view.RedirectToManageCourseView();

            }
            else
            {
                ShowMessagePanel();

                _view.Message = "Failed to save changes!" + _model.GetUpdateErrorMessage();

                ContinueButtonShow();
            }

        }

        private void SetCourseUpdatedStatus()
        {

            _model.SetUpdateCourseStatus();


        }

        private void RefreshCourseCache()
        {

            _model.RefreshCourseCache();

        }


        private void ConfirmAction()
        {

            ShowMessagePanel();

            _view.Message = _model.GetJobConfirmationMessage();

            DecisionButtonsShow();

        }

        private void DecisionButtonsShow()
        {

            _view.UpdateCourseButtonVisible = false;
      
            _view.NoButtonVisible = true;
            _view.YesButtonVisible = true;
            _view.ContinueButtonVisible = false;

        }

        private void DecisionButtonsHide()
        {

            _view.UpdateCourseButtonVisible = true;
   
            _view.NoButtonVisible = false;
            _view.YesButtonVisible = false;
            _view.ContinueButtonVisible = false;

        }

        private void ShowMessagePanel()
        {

            _view.MessagePanelVisible = true;

        }

        private void HideMessagePanel()
        {

            _view.MessagePanelVisible = false;

        }

        private void ContinueButtonShow()
        {

            _view.ContinueButtonVisible = true;
        }

    }
}
