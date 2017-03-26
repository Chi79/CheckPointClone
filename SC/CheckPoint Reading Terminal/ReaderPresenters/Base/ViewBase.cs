using ReaderPresenters.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReaderPresenters.Base
{
    public abstract class ViewBase<TPresenter> : Form where TPresenter : PresenterBase
    {
        private TPresenter _presenter;

        protected override void OnLoad(EventArgs e)
        {
            _presenter = CreatePresenter();
        }

        protected TPresenter CreatePresenter()
        {
            return IOC.GetPresenter<TPresenter>(this);
        }
    }
}
