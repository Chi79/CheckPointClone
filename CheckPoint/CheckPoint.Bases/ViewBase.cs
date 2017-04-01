using System;
using System.Web;
using System.Web.UI;
using CheckPoint.Interfaces;
using CheckPoint.IOC;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CheckPoint.Bases
{
    public abstract class ViewBase<TPresenter> : Page , IView where TPresenter : PresenterBase
    {
        private TPresenter _presenter;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoadComplete(e);
            _presenter = CreatePresenter();

            if (!IsPostBack)
            {
                _presenter.FirstTimeInit();
            }
            _presenter.Load();
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            _presenter.PreRender();
        }
        protected TPresenter CreatePresenter()
        {
            return IOC.GetPresenter<TPresenter>(this);
        }

        public MasterPage MasterPage
        {
            get { return Page.Master; }
        }

        public virtual Uri Uri
        {
            get { return HttpContext.Current.Request.Url; }
        }
    }
}
