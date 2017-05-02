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
    public class ManageAttendancePresenter : PresenterBase
    {
        private readonly IManageAttendanceView _view;
        private readonly IManageAttendanceModel _model;
     
        public ManageAttendancePresenter(IManageAttendanceView view, IManageAttendanceModel model)
        {
            _view = view;
            _model = model;                               
        }

        private void OnAcceptAttendanceRequestButtonClicked(object sender, EventArgs e)
        {
           
        }

        private void OnAppointmentGridViewRowSelected(object sender, EventArgs e)
        {
            SaveAppointmentRowIndexToSession();

            ShowAttendeesAppliedToSelectedAppointment();
            
            //GetSelectedAppointmentIdFromGrid(); 
        }

        private void ShowCourseGridView()
        {
            _view.ShowCourseGridViewHeader = true;
            _view.ShowCourseGridView = true;
        }

        private void HideCourseGridView()
        {
            _view.ShowCourseGridViewHeader = false;
            _view.ShowCourseGridView = false;
        }

        private void ShowAppointmentGridView()
        {
            _view.ShowAppointmentGridViewHeader = true;
            _view.ShowAppointmentGridView = true;
        }

        private void HideAppointmentGridView()
        {
            _view.ShowAppointmentGridViewHeader = false;
            _view.ShowAppointmentGridView = false;
        }

        private void OnCourseGridViewRowSelected(object sender, EventArgs e)
        {
            SaveCourseRowIndexToSession();

            ShowAttendeesAppliedToSelectedCourse();
        }

        private void ShowAttendeesAppliedToSelectedAppointment()
        {
            //todo
        }

        private void ShowAttendeesAppliedToSelectedCourse()
        {
            //todo
        }

        private void SaveAppointmentRowIndexToSession()
        {
            var rowSelected = _view.SelectedAppointmentRowIndex; 

            _model.SetSessionRowIndex(rowSelected);

        }

        private void SaveCourseRowIndexToSession()
        {
            var rowSelected = _view.SelectedCourseRowIndex;

            _model.SetSessionRowIndex(rowSelected);

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

        private void ResetSessionState()
        {
            _model.ResetSessionState();
        }

        public override void Load()
        {
            FetchData();
            WireUpEvents();
        }

        public override void FirstTimeInit()
        {
            
            ResetSessionState();
            ShowData();
        }

        private void FetchData()
        {
           //
        }
        private void WireUpEvents()
        {
            _view.AcceptAttendanceRequest += OnAcceptAttendanceRequestButtonClicked;
            _view.ShowAppointments += OnShowAppointmentsButtonClicked;
            _view.ShowCourses += OnShowCoursesButtonClicked;
            _view.AppointmentRowSelected += OnAppointmentGridViewRowSelected;
            _view.CourseRowSelected += OnCourseGridViewRowSelected;
        }

        private void OnShowCoursesButtonClicked(object sender, EventArgs e)
        {
            ShowCourses();
        }

        private void OnShowAppointmentsButtonClicked(object sender, EventArgs e)
        {
            ShowAppointments();
        }

        private void ShowAppointments()
        {
            ShowAppointmentGridView();
            HideCourseGridView();
        }

        private void ShowCourses()
        {
            ShowCourseGridView();
            HideAppointmentGridView();
        }

        private void ShowData()
        {           
            _view.CoursesAppliedToSetDataSource = _model.GetAllCoursesWithAttendeeRequests();
            _view.CoursesAppliedToHeaderSetDataSource = _model.GetEmptyCourseList();

            _view.AppointmentsAppliedToSetDataSource = _model.GetAllAppointmentsWithAttendeeRequests();
            _view.AppointmentsAppliedToHeaderSetDataSource = _model.GetEmptyAppointmentList();

            _view.AppliedAttendeesHeaderSetDataSource = _model.GetEmptyCourseList();

            _view.BindData();            
        }
    }
}
