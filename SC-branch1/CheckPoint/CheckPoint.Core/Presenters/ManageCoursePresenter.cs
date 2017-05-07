using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointPresenters.Bases;


namespace CheckPointPresenters.Presenters
{
    public class ManageCoursePresenter : PresenterBase
    {

        private readonly IManageCourseView _view;
        private readonly IManageCourseModel _model;


        public ManageCoursePresenter(IManageCourseView view, IManageCourseModel model)
                       
        {
            _view = view;
            _model = model;

        }
 

        public override void Load()
        {

            CheckForValidNavigation();

        }

        public void CheckForValidNavigation()
        {
            bool validNavigation = CheckIsCourseSelected();

            if (validNavigation)
            {

                FetchData();

                WireUpEvents();

            }
            else
            {

                _view.RedirectToAppointmentsView();

            }

        }

        private void WireUpEvents()
        {

            _view.RowSelected += OnRowSelected;
            _view.SortColumnsByPropertyAscending += OnSortColumnsAscendingClicked;
            _view.SortColumnsByPropertyDescending += OnSortColumnsDescendingClicked;
            _view.ViewAppointementsButtonClicked += OnViewAppointementsButtonClicked;
            _view.ViewCoursesButtonClicked += OnViewCoursesButtonClicked;
            _view.RemoveSelectedAppointmentButtonClicked += OnRemoveSelectedAppointmentButtonClicked;
            _view.MoveSelectedAppointmentToAnotherCourseButtonClicked += OnMoveSelectedAppointmentToAnotherCourseButtonClicked;
            _view.AddAnotherAppointmentToThisCourseButtonClicked += OnAddAnotherAppointmentToThisCourseButtonClicked;
            _view.UpdateCourseButtonClicked += OnUpdateCourseButtonClicked;
            _view.DeleteCourseButtonClicked += OnDeleteCourseButtonClicked;

            _view.ContinueButtonClicked += OnContinueButtonClicked;
        }

        private void OnContinueButtonClicked(object sender, EventArgs e)
        {

            HideMessagePanel();

        }

        private void OnDeleteCourseButtonClicked(object sender, EventArgs e)
        {

            ResetCourseDeletedStatus();

            _view.RedirectToDeleteCourseView();

        }

        private void OnUpdateCourseButtonClicked(object sender, EventArgs e)
        {

            _view.RedirectToUpdateCourseView();

        }

        private void OnAddAnotherAppointmentToThisCourseButtonClicked(object sender, EventArgs e)
        {

            _model.SetValidNavigationStatus();

            _view.RedirectToAppointmentSelectorView();

        }

        private void OnMoveSelectedAppointmentToAnotherCourseButtonClicked(object sender, EventArgs e)
        {

            bool AppointmentSelected = CheckIsAppointmentSelected();

            if (AppointmentSelected)
            {

                _view.RedirectToCourseSelectorView();

            }
            else
            {
                ShowMessagePanel();

                _view.Message = "No appointment has been selected! <br /> <br /> Please click a row to select the appointment you wish to move to another course.";

                ContinueButtonShow();

            }       

        }

        private void OnRemoveSelectedAppointmentButtonClicked(object sender, EventArgs e)
        {

            RemoveSelectedAppointement();

        }

        private void RemoveSelectedAppointement()
        {

            bool AppointmentSelected = CheckIsAppointmentSelected();

            if (AppointmentSelected)
            {

                _model.RemoveSelectedAppointmentFromCourse();

                ResetSessionState();

                _view.ReloadPageAfterEditing();

            }
            else
            {
                ShowMessagePanel();

                _view.Message = "No appointment has been selected! <br /> <br /> Please click a row to select the appointment you wish to remove from the course.";

                ContinueButtonShow();

            }

        }

        private void FetchData()
        {

            var courses = _model.GetCachedCourses();

        }
        public override void FirstTimeInit()
        {

            bool CourseSelected = CheckIsCourseSelected();

            if(CourseSelected)
            {

                ShowData();

                InitializeState();

            }
            else
            {

                _view.RedirectToAppointmentsView();

            }

        }

        private bool CheckIsCourseSelected()
        {

            int noCourseSelected = -1;

            if (_model.GetSessionCourseId() == noCourseSelected)
            {

                return false;

            }
            else
            {

                return true;

            }
        }

        private bool CheckIsAppointmentSelected()
        {

            int noAppointmentSelected = -1;

            if (_model.GetSessionAppointmentId() == noAppointmentSelected)
            {

                return false;

            }
            else
            {

                return true;

            }
        }

        private void InitializeState()
        {

            ResetSessionRowIndex();

            ResetSessionAppointmentId();

            ResetValidNavigationStatus();

        }

        private void ResetSessionRowIndex()
        {

            _model.ResetSessionRowIndex();

        }

        private void ResetCourseDeletedStatus()
        {

            _model.ResetCourseDeletedStatus();

        }

        private void ResetSessionAppointmentId()
        {

            _model.ResetSessionAppointmentId();

        }

        private void ResetSessionState()
        {

            _model.ResetSessionState();

        }

        private void SetValidNavigationStatus()
        {

            _model.SetValidNavigationStatus();

        }

        private void ResetValidNavigationStatus()
        {

            _model.ResetValidNavigationStatus();

        }

        private void ShowData()
        {

            CheckIfNewAppointmentAdded();

            CheckIfAppointmentDeleted();

            CheckIfCourseUpdated();

            ShowSelectedCourse();

            ShowAppointmentData();

            _view.BindData();

        }


        private void ShowSelectedCourse()
        {

            _view.SetDataSource = _model.GetSelectedCourse();

            _view.SetDataSource2 = _model.GetEmptyCourseList();

        }


        private void ShowAppointmentData()
        {

            _view.SetDataSourceAppointmentData = _model.GetAllAppointmentsForClientByCourseId();

            _view.SetDataSourceAppointmentHeader = _model.GetEmptyAppointmentList();

        }

        private void CheckIfNewAppointmentAdded()
        {

            bool newAppointmentAdded = _model.GetNewAppointmentAddedToCourseStatus();
            if(newAppointmentAdded)
            {
                ShowMessagePanel();

                _view.Message = "<br /> The appointment has been added to this course!<br /><br />";

                ContinueButtonShow();

                _model.ResetNewAppointmentAddedToCourseStatus();

            }

        }

        private void CheckIfAppointmentDeleted()
        {

            bool appointmentDeleted = _model.GetAppointmentDeletedFromCourseStatus();
            if(appointmentDeleted)
            {

                ShowMessagePanel();

                _view.Message = " <br /> The appointment has been removed from this course!<br /><br />";

                ContinueButtonShow();

                _model.ResetAppointmentDeletedFromCourseStatus();

            }

        }

        private void CheckIfCourseUpdated()
        {

            bool courseUpdated = _model.GetCourseUpdatedStatus();
            if (courseUpdated)
            {

                ShowMessagePanel();

                _view.Message = "<br />This course has been updated successfuly!<br /><br />";

                ContinueButtonShow();

                _model.ResetUpdateCourseStatus();

            }

        }


        private void OnRowSelected(object sender, EventArgs e)
        {

            SaveRowIndexToSession();

            GetSelectedAppointmentIdFromGrid();


        }

        private void SaveRowIndexToSession()
        {

            int rowSelected = _view.SelectedRowIndex;

            _model.SetSessionRowIndex(rowSelected);

        }

        private void OnSortColumnsAscendingClicked(object sender, EventArgs e)
        {

            var apps = _model.GetAppointmentsInCourseSortedByPropertyAsc();

            _view.SetDataSourceAppointmentData = apps;

            _view.SetDataSourceAppointmentHeader = _model.GetEmptyAppointmentList();

            ShowSelectedCourse();

            _view.BindData();

            GetSelectedAppointmentIdFromGrid();

        }

        private void OnSortColumnsDescendingClicked(object sender, EventArgs e)
        {

            var apps = _model.GetAppointmentsInCourseSortedByPropertyDesc();

            _view.SetDataSourceAppointmentData = apps;

            _view.SetDataSourceAppointmentHeader = _model.GetEmptyAppointmentList();

            ShowSelectedCourse();

            _view.BindData();

            GetSelectedAppointmentIdFromGrid();

        }


        private void GetSelectedAppointmentIdFromGrid()
        {

            int noRowSelected = -1;

            if (_model.GetSessionRowIndex() != noRowSelected)
            {

                SaveSelectedAppointmentIdToSession();

                _view.Message = _model.GetSessionAppointmentId().ToString();

            }
        }

        private void SaveSelectedAppointmentIdToSession()
        {

            int selectedAppointmentId = (int)_view.SelectedRowValueDataKey;

            _model.SetSessionAppointmentId(selectedAppointmentId);

        }

        private void OnViewCoursesButtonClicked(object sender, EventArgs e)
        {

            _view.RedirectToCoursesView();

        }

        private void OnViewAppointementsButtonClicked(object sender, EventArgs e)
        {

            _view.RedirectToAppointmentsView();

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
