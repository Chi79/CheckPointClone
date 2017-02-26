using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointPresenters.Bases
{
    public abstract class PresenterBase
    {
        public virtual void Load() { }
        public virtual void PreRender() { }
        public virtual void FirstTimeInit() { }
    }
}
//Three methods to be overridden and will be used together with the Page events to control the presenter
//implementations at the proper time in the Page lifecycle.
