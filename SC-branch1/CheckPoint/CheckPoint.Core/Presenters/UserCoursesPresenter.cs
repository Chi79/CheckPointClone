using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ViewInterfaces;
using CheckPointCommon.ModelInterfaces;
using CheckPointPresenters.Bases;

namespace CheckPointPresenters.Presenters
{
    public class UserCoursesPresenter : PresenterBase
    {

        private readonly IUserCoursesView _view;
        private readonly IUserCoursesModel _model;


        public UserCoursesPresenter(IUserCoursesView view, IUserCoursesModel model)
        {

            _view = view;
            _model = model;

        }

        public override void FirstTimeInit()
        {
            


        }
    }
}
