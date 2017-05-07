using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointPresenters.Bases;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;

namespace CheckPointPresenters.Presenters
{
   public class ApplyToCoursePresenter: PresenterBase
    {
        private readonly IApplyToCourseModel _model;
        private readonly IApplyToCourseView _view;

            public ApplyToCoursePresenter(IApplyToCourseModel model, IApplyToCourseView view)
        {
            _model = model;
            _view = view;
        }
        public override void FirstTimeInit()
        {
            ResetSessionState();

            ShowData();
        }
        public void ResetSessionState()
        {
            _model.ResetSessionState();
        }
        public override void Load()
        {
            FetchData();
            WireUpEvents();
            DisplayAppointments();
        }
        private void ShowData()
        {

            _view.SetDataSource = _model.GetAppointmentsInCourse();

            _view.SetDataSource2 = _model.GetEmptyList();

            _view.BindData();

        }

        public void WireUpEvents()
        {
            _view.btnApplyToCourse_Click += OnbtnApplyToCourse_Click;
        }

        private void OnbtnApplyToCourse_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void FetchData()
        {
            var appointments = _model.GetAppointmentsInCourse();
           
        }
        public void DisplayAppointments()
        {


        }
  

    }
}
