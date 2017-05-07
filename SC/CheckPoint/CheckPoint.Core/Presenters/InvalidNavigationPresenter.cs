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
    public class InvalidNavigationPresenter : PresenterBase
    {
        private readonly IInvalidNavigationView _view;
        private readonly IInvalidNavigationModel _model;

        public InvalidNavigationPresenter(IInvalidNavigationView view, IInvalidNavigationModel model)
        {

            _view = view;
            _model = model;

            _view.BackToCoursesViewButtonClicked += OnBackToCoursesViewButtonClicked;
        }

        private void OnBackToCoursesViewButtonClicked(object sender, EventArgs e)
        {

            _view.RedirectToCoursesView();

        }

        public override void FirstTimeInit()
        {
            CheckNavigationStatus();
        }

        private void CheckNavigationStatus()
        {

            bool invalidNavigation = _model.GetCourseDeletedStatus();
            if(invalidNavigation)
            {

                _view.Message = "Whoops! Sorry, this form has already been submitted....";

                _model.SetSessionCourseNoRowSelected();

            }

        }
    }
}
