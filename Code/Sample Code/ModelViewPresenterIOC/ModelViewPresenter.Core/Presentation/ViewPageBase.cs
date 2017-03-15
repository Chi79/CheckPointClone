﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web;
using ModelViewPresenter.Core.Framework;

namespace ModelViewPresenter.Core.Presentation
{
    public abstract class ViewPageBase<TPresenter> : Page, IView where TPresenter : PresenterBase
    {
        private TPresenter _presenter;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoadComplete(e);
            _presenter = CreatePresenter();

            if(!IsPostBack)
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