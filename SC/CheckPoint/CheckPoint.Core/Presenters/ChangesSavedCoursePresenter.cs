using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointPresenters.Bases;
using CheckPointCommon.ViewInterfaces;
using CheckPointCommon.ModelInterfaces;


namespace CheckPointPresenters.Presenters
{
     public class ChangesSavedCoursePresenter : PresenterBase
    {

        private readonly IChangesSavedCourseView _view;
        private readonly IChangesSavedCourseModel _model;

        public ChangesSavedCoursePresenter(IChangesSavedCourseView view, IChangesSavedCourseModel model)
        {

            _view = view;

            _model = model;

        }

        public void DisplayMessage()
        {

            _view.Heading = "Operation Successful!";

            _view.Message = "All changes have been saved!";

        }

        public void WireUpEvents()
        {

            _view.BackToCoursesViewButtonClicked += OnBackToAppointmentsViewButtonClicked;

        }

        private void OnBackToAppointmentsViewButtonClicked(object sender, EventArgs e)
        {

            _view.RedirectToCoursesView();

        }

        public override void FirstTimeInit()
        {

            DisplayMessage();

            SetSavedChangesStatus();

        }

        public override void Load()
        {

            WireUpEvents();

        }

        public void SetSavedChangesStatus()
        {

            _model.SetChangesSavedStatus();

        }


    }
}
