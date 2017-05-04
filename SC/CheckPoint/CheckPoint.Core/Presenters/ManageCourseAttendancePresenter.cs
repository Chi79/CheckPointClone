using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointPresenters.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointPresenters.Presenters
{
    public class ManageCourseAttendancePresenter : PresenterBase
    {
        private readonly IManageCourseAttendanceView _view;
        private readonly IManageCourseAttendanceModel _model;

        public ManageCourseAttendancePresenter(IManageCourseAttendanceView view, IManageCourseAttendanceModel model)
        {
            _view = view;
            _model = model;
        }
        public override void FirstTimeInit()
        {
            ResetSessionState();
            ShowCourseData();
        }

        private void ResetSessionState()
        {
            _model.ResetSessionState();
        }

        private void ShowCourseData()
        {
            _view.CoursesAppliedToHeaderSetDataSource = _model.GetEmptyCourseList();
            _view.CoursesAppliedToSetDataSource = _model.GetAllCoursesWithAttendeeRequests();

            _view.BindCourseData();
        }

        private void ShowAttendeeData()
        {
            _view.AppliedAttendeesHeaderSetDataSource = _model.GetEmptyClientList();
            _view.AppliedAttendeesSetDataSource = _model.GetClientInformationForAttendees();

            _view.BindAttendeeData();
        }

        public override void Load()
        {
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            _view.AcceptAttendanceRequest += OnAcceptAttendanceRequestButtonClicked;
            _view.RowSelected += OnGridViewRowSelected;
            _view.RedirectToManageAppointmentAttendance += OnManageAppointmentAttendanceButtonClicked;
        }

        private void OnManageAppointmentAttendanceButtonClicked(object sender, EventArgs e)
        {
            _view.RedirectToManageAppointmentAttendanceView();
        }

        private void OnGridViewRowSelected(object sender, EventArgs e)
        {
            SaveRowIndexToSession();

            GetSelectedCourseIdFromGrid();

            DisplayAppliedAttendeesForSelectedCourse();                     
        }

        private void ShowAttendeePanel()
        {
            _view.ShowAttendeeGridViewHeaderPanel = true;
            _view.ShowAttendeeGridViewPanel = true;
        }

        private void DisplayAppliedAttendeesForSelectedCourse()
        {
            //ShowAttendeePanel();
            ShowAttendeeData();
        }

        private void SaveRowIndexToSession()
        {

            int rowSelected = _view.SelectedRowIndex;

            _model.SetSessionRowIndex(rowSelected);

        }

        private void GetSelectedCourseIdFromGrid()
        {

            int noRowSelected = -1;

            if (_model.GetSessionRowIndex() != noRowSelected)
            {
                SaveSelectedCourseIdToSession();

            }

        }

        private void SaveSelectedCourseIdToSession()
        {

            int selectedCourseId = (int)_view.SelectedRowValueDataKey;

            _model.SetSessionCourseId(selectedCourseId);

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

        private void OnAcceptAttendanceRequestButtonClicked(object sender, EventArgs e)
        {
            
        }
    }
}
