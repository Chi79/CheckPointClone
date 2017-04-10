using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ViewInterfaces;
using CheckPointCommon.ModelInterfaces;
using CheckPointPresenters.Bases;
using CheckPointCommon.ServiceInterfaces;
using CheckPointDataTables.Tables;

namespace CheckPointPresenters.Presenters
{
    public class CourseSelectorPresenter : PresenterBase
    {
        private readonly ICourseSelectorView _view;
        private readonly ICourseSelectorModel _model;
        private readonly IShowCourses _displayService;
        private readonly ISessionService _sessionService;


        public CourseSelectorPresenter(ICourseSelectorView coursesView, ICourseSelectorModel coursesModel,
                                    IShowCourses displayService, ISessionService sessionService)
        {
            _view = coursesView;
            _model = coursesModel;
            _displayService = displayService;
            _sessionService = sessionService;

            _view.RowSelected += OnRowSelected;
            _view.SortColumnsByPropertyAscending += OnSortColumnsAscendingClicked;
            _view.SortColumnsByPropertyDescending += OnSortColumnsDescendingClicked;

            _view.CancelButtonClicked += OnCancelButtonClicked;
            _view.AddAppointmentToSelectedCourseButtonClicked += OnAddAppointmentToSelectedCourseButtonClicked;

        }

        private void OnAddAppointmentToSelectedCourseButtonClicked(object sender, EventArgs e)
        {
            int noAppointmentSelected = -1;
            if (_sessionService.SessionCourseId == noAppointmentSelected)
            {
                _view.Message = "No course has been selected!";
            }
            else
            {
                AddAppointmentToSelectedCourse();

                _view.RedirectToManageCourseView();
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
        }
        public override void FirstTimeInit()
        {
            _view.SetDataSource = _displayService.GetAllCoursesFor<COURSE>(_sessionService.LoggedInClient);
            _view.SetDataSource2 = _displayService.GetEmptyList<COURSE>();
            _sessionService.SessionRowIndex = -1;
            _sessionService.SessionCourseId = -1;
            _view.BindData();
        }
        private void FetchData()
        {
            var courses = _displayService.GetCoursesCached<COURSE>();

        }
        private void OnRowSelected(object sender, EventArgs e)
        {
            _sessionService.SessionRowIndex = _view.SelectedRowIndex;
            GetSelectedCourseIdFromGrid();
        }

        private void OnSortColumnsAscendingClicked(object sender, EventArgs e)
        {

            var courses = _displayService.GetCoursesSortedByPropertyAscending<object>(_sessionService.ColumnName);
            _view.SetDataSource = courses;
            _view.SetDataSource2 = _displayService.GetEmptyList<COURSE>();
            _view.BindData();

            GetSelectedCourseIdFromGrid();
        }
        private void OnSortColumnsDescendingClicked(object sender, EventArgs e)
        {

            var courses = _displayService.GetCoursesSortedByPropertyDescending<object>(_sessionService.ColumnName);
            _view.SetDataSource = courses;
            _view.SetDataSource2 = _displayService.GetEmptyList<COURSE>();
            _view.BindData();

            GetSelectedCourseIdFromGrid();
        }
        private void GetSelectedCourseIdFromGrid()
        {

            int noIndexIsSelected = -1;
            if (_sessionService.SessionRowIndex != noIndexIsSelected)
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
                _sessionService.SessionCourseId = (int)selectedCourseId;
                _view.Message = selectedCourseId.ToString();
            }
        }
    }
}
