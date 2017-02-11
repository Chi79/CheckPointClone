using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelViewPresenter.Core.Model;

namespace ModelViewPresenter.Core.Presentation.StartPage
{
    public class StartPagePresenter : PresenterBase
    {
        private readonly IStartPageView _view;
        private readonly IModel _model;

        public StartPagePresenter(IStartPageView view, IModel model)
        {
            if (view == null) throw new ArgumentNullException("view");
            if (model == null) throw new ArgumentNullException("model");
            _view = view;
            _model = model;
        }

        public override void Load()
        {
            _view.Heading = GetHeading(true);
            _view.Message = GetMessage(true);
        }

        public string GetHeading(bool useService)
        {
            return useService ?
                _model.GetHeading("") :
                "No heading";
        }

        public string GetMessage(bool useService)
        {
            return useService ?
                _model.GetMessage("") :
                "No text";
        }
    }
}
