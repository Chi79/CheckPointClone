using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointPresenters.Bases;
using CheckPointModel.Services;
using CheckPointDataTables.Tables;
using CheckPointModel.DTOs;


namespace CheckPointPresenters.Presenters
{
    public class CreateCoursePresenter : PresenterBase
    {

        private readonly ICreateCourseView _view;
        private readonly ICreateCourseModel _model;

        private CourseDTO _dTO = new CourseDTO();


        public CreateCoursePresenter(ICreateCourseView createCourseView,
                                     ICreateCourseModel createCourseModel)
                             
        {

            _view = createCourseView;
            _model = createCourseModel;

        }

        public override void Load()
        {

            WireUpEvents();

        }

        private void WireUpEvents()
        {

            _view.CreateNewCourse += OnCreateNewCourseButtonClicked;
            _view.YesButtonClicked += OnYesButtonClicked;
            _view.NoButtonClicked += OnNoButtonClicked;
            _view.BackToCoursesPageClicked += OnBackToCoursesPageClicked;

        }

        private void OnCreateNewCourseButtonClicked(object sender, EventArgs e)
        {

            _model.PrepareCreateCourseJob();

            SaveCourseNameToSession();

            ConfirmJob();

        }

        private void SaveCourseNameToSession()
        {

            string courseName = _view.CourseName;
            _model.SaveCourseNameToSession(courseName);

        }

        private void ConfirmJob()
        {
            _view.Message = _model.GetJobConfirmationMessage();

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


        private void CreateCourseDTOFromInput()
        {

            _dTO.UserName = _model.GetLoggedInClient();
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


        private void PerformJob(COURSE course)
        {

            _model.PerformJob(course);
 
            CheckChangesSaved();

        }

        private COURSE ConvertDTOToCourse()
        {

            return  _model.ConvertToCourse(_dTO) as COURSE;
  
        }


        private void CheckChangesSaved()
        {

            bool UpdateSuccessful = _model.UpdateDatabaseWithChanges();
            if (UpdateSuccessful)
            {

                _view.Message = _model.GetJobCompletedMessage();
                DisplayCourseSavedButtons();

            }
            else
            {

                _view.Message = "Failed to save changes!" + _model.GetUpdateErrorMessage();

            }

        }


        private void DisplayJobCompletedMessage(JobServiceBase job)
        {

            _view.Message = job.CompletedMessage;

        }

        private void OnBackToCoursesPageClicked(object sender, EventArgs e)
        {

            _view.RedirectToCoursesPage();

        }

        private void DecisionButtonsShow()
        {
            _view.CreateCourseButtonVisible = false;
            _view.NoButtonVisible = true;
            _view.YesButtonVisible = true;
        }

        private void DecisionButtonsHide()
        {
            _view.CreateCourseButtonVisible = true;
            _view.NoButtonVisible = false;
            _view.YesButtonVisible = false;
        }

        public void DisplayCourseSavedButtons()
        {
            _view.CreateCourseButtonVisible = false;
            _view.BackToCoursesPageButtonVisible = true;
        }
    }
}
