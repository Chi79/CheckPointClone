using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using StructureMap.Pipeline;

namespace ModelViewPresenter.Core.Framework
{
    public class IOC
    {
        public static IContainer Container;

        public static void Reset()
        {
            if (Container == null)
            {
                return;
            }
            Container.Dispose();
            Container = null;
        }

        public static TPresenter GetPresenter<TPresenter>(object view)
        {
            var explicitArguments = new ExplicitArguments();
            foreach (var implementedInterface in view.GetType().GetInterfaces())
            {
                explicitArguments.Set(implementedInterface, view);
            }
            return Container.GetInstance<TPresenter>(explicitArguments);
        }
    }
}
