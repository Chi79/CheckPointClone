using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelViewPresenter.Core.Framework;
using System.Web;


namespace ModelViewPresenter.Bootstrap
{
    public class Initializer : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            var bootstrapper = new Bootstrapper();
            bootstrapper.BootstrapStructureMap();
            IOC.Container = bootstrapper.Container;
        }

        public void Dispose()
        {
        }
    }
}
