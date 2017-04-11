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
    public class HostCoursesPresenter : PresenterBase
    {
        private readonly IHostCoursesView _view;
        private readonly IHostCoursesModel _model;

        public HostCoursesPresenter(IHostCoursesView coursesView, IHostCoursesModel coursesModel)
        {

            _view = coursesView;
            _model = coursesModel;

        }

        private void OnViewAppointmentsButtonClicked(object sender, EventArgs e)
        {

            _view.RedirectToAppointmentsView();

        }

        private void OnCreateReportButtonClicked(object sender, EventArgs e)
        {

            _view.Message = "Fabio Goose";

        }

        private void OnManageAttendanceButtonClicked(object sender, EventArgs e)
        {

            _view.Message = "Fabio Goose";

        }

        private void OnManageCourseButtonClicked(object sender, EventArgs e)
        {

            bool RowSelected = CheckRowIsSelected();

            if (RowSelected)
            {

                _view.RedirectToManageCourse();

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

        private void OnCreateCourseButtonClicked(object sender, EventArgs e)
        {

            _view.RedirectToCreateCourse();

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
            _view.ViewAppointmentsButtonClicked += OnViewAppointmentsButtonClicked;
            _view.ManageCourseButtonClicked += OnManageCourseButtonClicked;
            _view.CreateCourseButtonClicked += OnCreateCourseButtonClicked;
            _view.CreateReportButtonClicked += OnCreateReportButtonClicked;
            _view.ManageAttendanceButtonClicked += OnManageAttendanceButtonClicked;

        }

        public override void FirstTimeInit()
        {

             ResetSessionState();

             ShowData();
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
