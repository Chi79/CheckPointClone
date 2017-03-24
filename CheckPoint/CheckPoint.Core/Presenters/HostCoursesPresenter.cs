using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointPresenters.Bases;
using CheckPointCommon.ServiceInterfaces;
using CheckPointDataTables.Tables;

namespace CheckPointPresenters.Presenters
{
    public class HostCoursesPresenter : PresenterBase
    {
        private readonly IHostCoursesView _view;
        private readonly IHostCoursesModel _model;
        private readonly IShowAppointments _displayService;

        private string _client;

        public HostCoursesPresenter(IHostCoursesView coursesView, IHostCoursesModel coursesModel, 
                                    IShowAppointments displayService)
        {
            _view = coursesView;
            _model = coursesModel;
            _displayService = displayService;

            _view.RowSelected += OnRowSelected;
            _view.SortColumnsByPropertyAscending += OnSortColumnsAscendingClicked;
            _view.SortColumnsByPropertyDescending += OnSortColumnsDescendingClicked;
            _view.ViewAppointmentsButtonClicked += OnViewAppointmentsButtonClicked;
            _view.ManageCourseButtonClicked += OnManageCourseButtonClicked;
            _view.CreateCourseButtonClicked += OnCreateCourseButtonClicked;
            _view.CreateReportButtonClicked += OnCreateReportButtonClicked;
            _view.ManageAttendanceButtonClicked += OnManageAttendanceButtonClicked;

            _client = _view.LoggedInClient;
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

            int noAppointmentSelected = -1;
            if (_view.SessionCourseId == noAppointmentSelected)
            {
                _view.Message = "No course has been selected!";
            }
            else
            {
                _view.RedirectToManageCourse();
            }

        }

        private void OnCreateCourseButtonClicked(object sender, EventArgs e)
        {

            _view.RedirectToCreateCourse();
        }

        public override void Load()
        {
            FetchData();
        }
        public override void FirstTimeInit()
        {
            _view.SetDataSource = _displayService.GetAllAppointmentsFor<APPOINTMENT>(_client);
            _view.SetDataSource2 = _displayService.GetEmptyList<APPOINTMENT>();
            _view.SessionRowIndex = -1;
            _view.SessionCourseId = -1;
            _view.BindData();
        }
        private void FetchData()
        {
            var appointments = _displayService.GetAppointmentsCached<APPOINTMENT>();

        }
        private void OnRowSelected(object sender, EventArgs e)
        {
            _view.SessionRowIndex = _view.SelectedRowIndex;
            GetSelectedCourseIdFromGrid();
        }

        private void OnSortColumnsAscendingClicked(object sender, EventArgs e)
        {
            var apps = _displayService.GetAppointmentsSortedByPropertyAscending<object>(_view.ColumnName);
            _view.SetDataSource = apps;
            _view.SetDataSource2 = _displayService.GetEmptyList<APPOINTMENT>();
            _view.BindData();

            GetSelectedCourseIdFromGrid();
        }
        private void OnSortColumnsDescendingClicked(object sender, EventArgs e)
        {
            var apps = _displayService.GetAppointmentsSortedByPropertyDescending<object>(_view.ColumnName);
            _view.SetDataSource = apps;
            _view.SetDataSource2 = _displayService.GetEmptyList<APPOINTMENT>();
            _view.BindData();

            GetSelectedCourseIdFromGrid();
        }
        private void GetSelectedCourseIdFromGrid()
        {

            int noIndexIsSelected = -1;
            if (_view.SessionRowIndex != noIndexIsSelected)
            {
                CheckCourseIdIsNotNull();
            }
        }
        private void CheckCourseIdIsNotNull()
        {
            var courseId = _view.SelectedRowValueDataKey;
            if (courseId != null)
            {
                var selectedCourseId = _view.SelectedRowValueDataKey;
                _view.SessionCourseId = (int)selectedCourseId;
                _view.Message = selectedCourseId.ToString();
            }
        }
    }
}
