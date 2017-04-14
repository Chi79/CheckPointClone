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

            _view.BackToCoursesPageClicked += OnBackToCoursesPageClicked;
            _view.UpdateCourseButtonClicked += OnUpdateCourseButtonClicked;
            _view.YesButtonClicked += OnYesButtonClicked;
            _view.NoButtonClicked += OnNoButtonClicked;

        }

        public override void FirstTimeInit()
        {

            DisplaySelectedCourseData();

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

            _view.Message = "Ready.";

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

            _view.Message = string.Empty;

            var validationMessages = _dTO.GetBrokenBusinessRules().ToList();

            foreach (string message in validationMessages)
            {
                _view.Message += message;
            }

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

                _view.RedirectToManageCourseView();

            }
            else
            {
                _view.Message = "Failed to save changes!" + _model.GetUpdateErrorMessage();
            }

        }

        private void RefreshCourseCache()
        {

            _model.RefreshCourseCache();

        }


        private void ConfirmAction()
        {

            _view.Message = _model.GetJobConfirmationMessage();

            DecisionButtonsShow();

        }

        private void DecisionButtonsShow()
        {

            _view.UpdateCourseButtonVisible = false;
            _view.BackToCoursesPageButtonVisible = false;
            _view.NoButtonVisible = true;
            _view.YesButtonVisible = true;

        }

        private void DecisionButtonsHide()
        {

            _view.UpdateCourseButtonVisible = true;
            _view.BackToCoursesPageButtonVisible = true;
            _view.NoButtonVisible = false;
            _view.YesButtonVisible = false;

        }

        private void OnBackToCoursesPageClicked(object sender, EventArgs e)
        {

            _view.RedirectToCoursesPage();

        }
    }
}
