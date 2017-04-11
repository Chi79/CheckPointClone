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
    public class CourseSelectorPresenter : PresenterBase
    {

        private readonly ICourseSelectorView _view;
        private readonly ICourseSelectorModel _model;

        public CourseSelectorPresenter(ICourseSelectorView coursesView, ICourseSelectorModel coursesModel)
        {

            _view = coursesView;
            _model = coursesModel;

        }

        private void OnAddAppointmentToSelectedCourseButtonClicked(object sender, EventArgs e)
        {

            bool RowSelected = CheckRowIsSelected();

            if (RowSelected)
            {

                AddAppointmentToSelectedCourse();

                _model.SetNewAppointmentAddedToCourseStatus();

                _view.RedirectToManageCourseView();

            }
            else
            {

                _view.Message = "No appointment has been selected!";

            }
        }

        private bool CheckRowIsSelected()
        {
            int noRowSelected = -1;

            if (_model.GetSessionRowIndex() == noRowSelected)
            {

                return false;

            }
            else
            {

                return true;

            }
        }

        private void AddAppointmentToSelectedCourse()
        {

            var selectedAppointment = _model.GetSelectedAppointment() as APPOINTMENT;

            selectedAppointment.CourseId = _model.GetSessionCourseId();

            _model.AddSelectedAppointmentToCourse(selectedAppointment);

        }

        private void OnCancelButtonClicked(object sender, EventArgs e)
        {

            _view.RedirectToAppointmentsView();

        }


        public override void Load()
        {

            FetchData();

            WireUpEvents();

        }

        public void WireUpEvents()
        {

            _view.RowSelected += OnRowSelected;
            _view.SortColumnsByPropertyAscending += OnSortColumnsAscendingClicked;
            _view.SortColumnsByPropertyDescending += OnSortColumnsDescendingClicked;
            _view.CancelButtonClicked += OnCancelButtonClicked;
            _view.AddAppointmentToSelectedCourseButtonClicked += OnAddAppointmentToSelectedCourseButtonClicked;

        }


        public override void FirstTimeInit()
        {

            ResetSessionState();

            ShowData();
   
            //_view.SetDataSource = _model.GetAllCoursesForClient();

            //_view.SetDataSource2 = _model.GetEmptyList();

            //_model.ResetSessionState();

            //_view.BindData();

        }

        private void ShowData()
        {

            _view.SetDataSource = _model.GetAllCoursesForClient();

            _view.SetDataSource2 = _model.GetEmptyList();

            _view.BindData();
        }


        private void ResetSessionState()
        {

            _model.ResetNewAppointmentAddedToCourseStatus();

            _model.ResetSessionState();

        }


        private void FetchData()
        {

            var courses = _model.GetCachedCourses();

        }


        private void OnRowSelected(object sender, EventArgs e)
        {

            SaveRowIndexToSession();

            GetSelectedCourseIdFromGrid();

        }

        private void SaveRowIndexToSession()
        {

            int rowSelected = _view.SelectedRowIndex;

            _model.SetSessionRowIndex(rowSelected);

        }


        private void OnSortColumnsAscendingClicked(object sender, EventArgs e)
        {

            var courses = _model.GetCoursesSortedByPropertyAsc();

            _view.SetDataSource = courses;

            _view.SetDataSource2 = _model.GetEmptyList();

            _view.BindData();

            GetSelectedCourseIdFromGrid();

        }


        private void OnSortColumnsDescendingClicked(object sender, EventArgs e)
        {

            var courses = _model.GetCoursesSortedByPropertyDesc();

            _view.SetDataSource = courses;

            _view.SetDataSource2 = _model.GetEmptyList();

            _view.BindData();

            GetSelectedCourseIdFromGrid();

        }


        private void GetSelectedCourseIdFromGrid()
        {

            int noRowSelected = -1;

            if (_model.GetSessionRowIndex() != noRowSelected)
            {

                CheckCourseIdIsNotNull();

            }
        }


        private void CheckCourseIdIsNotNull()
        {
            var courseId = _view.SelectedRowValueDataKey;

            if (courseId != null)
            {

                StoreSelectedCourseIdToSession();

                _view.Message = _model.GetSessionCourseId().ToString();

            }
        }

        private void StoreSelectedCourseIdToSession()
        {

            var selectedCourseId = _view.SelectedRowValueDataKey;

            _model.SetSessionCourseId((int)selectedCourseId);

        }
    }
}
