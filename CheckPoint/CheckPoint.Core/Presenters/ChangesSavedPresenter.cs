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
     public class ChangesSavedPresenter : PresenterBase
    {

        private readonly IChangesSavedView _view;
        private readonly IChangesSavedModel _model;

        public ChangesSavedPresenter(IChangesSavedView view, IChangesSavedModel model)
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

            _view.BackToAppointmentsViewButtonClicked += OnBackToAppointmentsViewButtonClicked;

        }

        private void OnBackToAppointmentsViewButtonClicked(object sender, EventArgs e)
        {

            _view.RedirectToAppointmentsView();

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
