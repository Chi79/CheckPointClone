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
            ShowData();
        }

        private void ResetSessionState()
        {
            _model.ResetSessionState();
        }

        private void ShowData()
        {
            _view.CoursesAppliedToHeaderSetDataSource = _model.GetEmptyCourseList();
            _view.CoursesAppliedToSetDataSource = _model.GetAllCoursesWithAttendeeRequests();

            _view.BindCourseData();
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
            
        }

        private void OnAcceptAttendanceRequestButtonClicked(object sender, EventArgs e)
        {
            
        }
    }
}
