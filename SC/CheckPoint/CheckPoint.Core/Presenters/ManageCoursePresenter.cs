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

                ShowSelectedCourse();

                ShowAppointmentData();

                SetSessionRowIndex();

                _view.BindData();

            }
            else
            {

                _view.RedirectToCourseSelectorView();

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

        private void SetSessionRowIndex()
        {

            int ResetRowIndex = -1;

            _model.SetSessionRowIndex(ResetRowIndex);

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
    }
}
