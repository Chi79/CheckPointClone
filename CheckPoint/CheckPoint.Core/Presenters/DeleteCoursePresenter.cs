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


            _view.BackToCoursesPageClicked += OnBackToCoursesPageClicked;
            _view.DeleteCourseButtonClicked += OnDeleteCourseButtonClicked;
            _view.YesButtonClicked += OnYesButtonClicked;
            _view.NoButtonClicked += OnNoButtonClicked;
        }

        public override void FirstTimeInit()
        {

            CheckValidNavigation();

            //DisplayPage();

        }



        private void CheckValidNavigation()
        {
            bool invalidNavigation = _model.GetDeleteCourseStatus();
            if(invalidNavigation)
            {


                _view.RedirectToCoursesPage();
                //_view.RedirectToAppointmentsView();

            }
            else
            {

                DisplayPage();

                //var course = _model.GetSelectedCourseByCourseId();

                //_model.PerformJob(course);

                //CheckChangesSaved();

            }
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

            _view.Message = "Ready.";

        }

        private void OnYesButtonClicked(object sender, EventArgs e)
        {

            if(_model.GetDeleteCourseStatus())
            {

                _view.RedirectToAppointmentsView();

            }
            else
            {

                var course = _model.GetSelectedCourseByCourseId();

                _model.PerformJob(course);

                CheckChangesSaved();

                //CheckValidNavigation();
            }

        }

        private void CheckChangesSaved()
        {

            bool UpdateSuccessful = _model.UpdateDatabaseWithChanges();
            if (UpdateSuccessful)
            {

                RefreshCourseCache();

                SetCourseDeletedStatus();

                //_view.RedirectToCoursesPage();

                _view.RedirectAfterClick();

            }
            else
            {
                _view.Message = "Failed to save changes!" + _model.GetUpdateErrorMessage();
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

            _view.Message = _model.GetJobConfirmationMessage();

            DecisionButtonsShow();

        }

        private void DecisionButtonsShow()
        {

            _view.DeleteCourseButtonVisible = false;
            _view.BackToCoursesPageButtonVisible = false;
            _view.NoButtonVisible = true;
            _view.YesButtonVisible = true;

        }

        private void DecisionButtonsHide()
        {

            _view.DeleteCourseButtonVisible = true;
            _view.BackToCoursesPageButtonVisible = true;
            _view.NoButtonVisible = false;
            _view.YesButtonVisible = false;

        }

        private void SetFieldsToReadOnly()
        {

            _view.CourseNameReadonly = true;
            _view.DescriptionReadonly = true;
            _view.IsObligatoryEnabled = false;
            _view.IsPrivateEnabled = false;

        }

        private void OnBackToCoursesPageClicked(object sender, EventArgs e)
        {

            _view.RedirectToCoursesPage();

        }
    }
}
