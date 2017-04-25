using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointPresenters.Bases;
using CheckPointCommon.RepositoryInterfaces;

namespace CheckPointPresenters.Presenters
{
    public class ManageAttendancePresenter : PresenterBase
    {
        private readonly IManageAttendanceView _view;
        private readonly IManageAttendanceModel _model;
        
     
        public ManageAttendancePresenter(IManageAttendanceView view, IManageAttendanceModel model, IUnitOfWork unitOfWork)
        {
            _view = view;
            _model = model;                               
        }

        private void OnAcceptAttendanceRequestButtonClicked(object sender, EventArgs e)
        {
            //TODO
        }

        public override void Load()
        {
            FetchData();

            WireUpEvents();
        }

        public override void FirstTimeInit()
        {
            ShowData();
        }



        private void FetchData()
        {
           //

        }
        private void WireUpEvents()
        {
            _view.AcceptAttendanceRequest += OnAcceptAttendanceRequestButtonClicked;
        }

        private void ShowData()
        {
            
            _view.CoursesAppliedToSetDataSource = _model.GetAllCoursesWithAppliedAttendees();
            _view.CoursesAppliedToHeaderSetDataSource = _model.GetEmptyCourseList();

            _view.AppointmentsAppliedToSetDataSource = null;
            _view.AppointmentsAppliedToHeaderSetDataSource = _model.GetEmptyAppointmentList();
            _view.BindData();            
        }
    }
}
