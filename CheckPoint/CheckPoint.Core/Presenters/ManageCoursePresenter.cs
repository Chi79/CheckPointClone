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
    public class ManageCoursePresenter : PresenterBase
    {
        private readonly IManageCourseView _view;
        private readonly IManageCourseModel _model;
        private readonly IShowCourses _courseDisplayService;
        private readonly IShowAppointments _appointmentDisplayService;
        private readonly ISessionService _sessionService;

        public ManageCoursePresenter(IManageCourseView view, IManageCourseModel model,
                                     IShowCourses courseDisplayService, IShowAppointments appointmentDisplayService,
                                     ISessionService sessionService)
        {
            _view = view;
            _model = model;
            _courseDisplayService = courseDisplayService;
            _appointmentDisplayService = appointmentDisplayService;
            _sessionService = sessionService;


            _view.RowSelected += OnRowSelected;
            _view.SortColumnsByPropertyAscending += OnSortColumnsAscendingClicked;
            _view.SortColumnsByPropertyDescending += OnSortColumnsDescendingClicked;
        }
 

        public override void Load()
        {
            FetchData();
        }
        private void FetchData()
        {
            var courses = _courseDisplayService.GetCoursesCached<COURSE>();

        }
        public override void FirstTimeInit()
        {
            List<COURSE> Course = _courseDisplayService.GetEmptyList<COURSE>().ToList();
            Course.Add(_courseDisplayService.GetSelectedCourseByCourseId(_sessionService.SessionCourseId) as COURSE);      
            _view.SetDataSource = Course;
            _view.SetDataSource2 = _courseDisplayService.GetEmptyList<COURSE>();

            _view.SetDataSourceAppointmentData = _model.GetAllAppointmentsForClientByCourseId(_sessionService.SessionCourseId);

            _view.SetDataSourceAppointmentHeader = _model.GetEmptyList();

            //_sessionService.SessionRowIndex = -1;
            //_sessionService.SessionCourseId = -1;
            _view.BindData();
        }


        private void OnRowSelected(object sender, EventArgs e)
        {

            int rowIndex = _view.SelectedRowIndex;
            _model.SetSessionRowIndex(rowIndex);

            GetSelectedAppointmentIdFromGrid();

        }

        private void OnSortColumnsAscendingClicked(object sender, EventArgs e)
        {

            var apps = _model.GetAppointmentsInCourseSortedByPropertyAsc();

            _view.SetDataSourceAppointmentData = apps;

            _view.SetDataSourceAppointmentHeader = _model.GetEmptyList();

            _view.BindData();

            GetSelectedAppointmentIdFromGrid();

        }
        private void OnSortColumnsDescendingClicked(object sender, EventArgs e)
        {

            var apps = _model.GetAppointmentsInCourseSortedByPropertyDesc();

            _view.SetDataSourceAppointmentData = apps;

            _view.SetDataSourceAppointmentHeader = _model.GetEmptyList();

            _view.BindData();

            GetSelectedAppointmentIdFromGrid();

        }
        private void GetSelectedAppointmentIdFromGrid()
        {

            int unAssigned = -1;

            if (_model.GetSessionRowIndex() != unAssigned)
            {

                int selectedAppointmentId = (int)_view.SelectedRowValueDataKey;

                _model.SetSessionAppointmentId(selectedAppointmentId);

                _view.Message = selectedAppointmentId.ToString();

            }
        }
    }
}
