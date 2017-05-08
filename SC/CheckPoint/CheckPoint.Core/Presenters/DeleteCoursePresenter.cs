using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ViewInterfaces;
using CheckPointCommon.ModelInterfaces;
using CheckPointPresenters.Bases;
using CheckPointDataTables.Tables;

namespace CheckPointPresenters.Presenters
{
    public class DeleteCoursePresenter : PresenterBase
    {
        private readonly IDeleteCourseView _view;
        private readonly IDeleteCourseModel _model;

        public DeleteCoursePresenter(IDeleteCourseView view, IDeleteCourseModel model)
        {

            _view = view;
            _model = model;



            _view.DeleteCourseButtonClicked += OnDeleteCourseButtonClicked;
            _view.YesButtonClicked += OnYesButtonClicked;
            _view.NoButtonClicked += OnNoButtonClicked;
            _view.ContinueButtonClicked += OnContinueButtonClicked;
        }

        private void OnContinueButtonClicked(object sender, EventArgs e)
        {



        }

        public override void FirstTimeInit()
        {

            bool validNavigation = CheckValidNavigation();
            if (validNavigation)
            {

                DisplayPage();

            }
            else
            {

                _view.RedirectToInvalidNavigationView();

            }

        }

        private bool CheckValidNavigation()
        {

            bool invalidNavigation = _model.GetDeleteCourseStatus();

            if (invalidNavigation)
            {

                return false;


            }
            else
            {

                return true;

            }

        }

        private void ContinueWithDeletion()
        {

            var course = _model.GetSelectedCourseByCourseId();

            _model.PerformJob(course);

            CheckChangesSaved();

        }

        private void DisplayPage()
        {

            DisplaySelectedCourseData();

            SetFieldsToReadOnly();

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

            bool validNavigation = CheckValidNavigation();
            if (validNavigation)
            {

                ContinueWithDeletion();

            }
            else
            {

                _view.RedirectToInvalidNavigationView();

            }

        }

        private void CheckChangesSaved()
        {

            bool UpdateSuccessful = _model.UpdateDatabaseWithChanges();
            if (UpdateSuccessful)
            {

                RefreshCourseCache();

                SetCourseDeletedStatus();

                _view.RedirectToChangesSavedCoursePage();

            }
            else
            {
                ShowMessagePanel();

                _view.Message = "Failed to save changes!  <br /><br />" + _model.GetUpdateErrorMessage();

                ContinueButtonShow();
            }

        }

        private void SetCourseDeletedStatus()
        {

            _model.SetDeleteCourseStatus();

        }

        private void RefreshCourseCache()
        {

            _model.RefreshCourseCache();

        }

        private void OnDeleteCourseButtonClicked(object sender, EventArgs e)
        {

            _model.PrepareDeleteCourseJob();

            ConfirmAction();

        }

        private void ConfirmAction()
        {
            ShowMessagePanel();

            _view.Message = _model.GetJobConfirmationMessage();

            DecisionButtonsShow();

        }

        private void DecisionButtonsShow()
        {

            _view.DeleteCourseButtonVisible = false;

            _view.NoButtonVisible = true;
            _view.YesButtonVisible = true;
            _view.ContinueButtonVisible = false;

        }

        private void DecisionButtonsHide()
        {

            _view.DeleteCourseButtonVisible = true;

            _view.NoButtonVisible = false;
            _view.YesButtonVisible = false;
            _view.ContinueButtonVisible = false;

        }

        private void SetFieldsToReadOnly()
        {

            _view.CourseNameReadonly = true;
            _view.DescriptionReadonly = true;
            _view.IsObligatoryEnabled = false;
            _view.IsPrivateEnabled = false;

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
