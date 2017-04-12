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

            FetchData();

            WireUpEvents();

        }
  
        private void WireUpEvents()
        {

            _view.RowSelected += OnRowSelected;
            _view.SortColumnsByPropertyAscending += OnSortColumnsAscendingClicked;
            _view.SortColumnsByPropertyDescending += OnSortColumnsDescendingClicked;
            _view.ViewAppointementsButtonClicked += OnViewAppointementsButtonClicked;
            _view.ViewCoursesButtonClicked += OnViewCoursesButtonClicked;
            _view.RemoveSelectedAppointmentButtonClicked += OnRemoveSelectedAppointmentButtonClicked;

        }

        private void OnRemoveSelectedAppointmentButtonClicked(object sender, EventArgs e)
        {

            bool CourseSelected = CheckIsCourseSelected();  
            if(CourseSelected)
            {

                RemoveSelectedAppointement();

            }
            else
            {

                _view.Message = "No course has been selected! - please return to the course page and select a course.";

            }

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

                _view.Message = "No appointment has been selected";

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

                ResetSessionRowIndex();
                
                ResetSessionAppointmentId();

                _view.Message = "AppointmentID is:  " + _model.GetSessionAppointmentId().ToString() + "  and CourseID is:  " + _model.GetSessionCourseId();

            }
            else
            {

                //_view.RedirectToCoursesView();
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

        private void ResetSessionRowIndex()
        {

            _model.ResetSessionRowIndex();

        }

        private void ResetSessionAppointmentId()
        {

            _model.ResetSessionAppointmentId();

        }

        private void ResetSessionState()
        {

            _model.ResetSessionState();

        }

        private void ShowData()
        {

            CheckIfNewAppointmentAdded();

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
                _view.AppointmentAddedMessageVisible = true;

                _model.ResetNewAppointmentAddedToCourseStatus();
            }

        }

        private void OnRowSelected(object sender, EventArgs e)
        {

            SaveRowIndexToSession();

            GetSelectedAppointmentIdFromGrid();

            _view.Message = "AppointmentID is:  " + _model.GetSessionAppointmentId().ToString() + "  and CourseID is:  " + _model.GetSessionCourseId();

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
    }
}
