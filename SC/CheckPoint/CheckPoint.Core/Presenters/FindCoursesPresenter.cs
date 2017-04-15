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
    public class FindCoursesPresenter : PresenterBase
    {

        private readonly IFindCoursesView _view;
        private readonly IFindCoursesModel _model;

        public FindCoursesPresenter(IFindCoursesView view, IFindCoursesModel model)
        {

            _view = view;
            _model = model;

        }

        public override void FirstTimeInit()
        {
            


        }
    }
}
