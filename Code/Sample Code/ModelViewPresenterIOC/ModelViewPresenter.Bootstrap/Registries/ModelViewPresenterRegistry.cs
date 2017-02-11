using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using ModelViewPresenter.Core.Presentation;

namespace ModelViewPresenter.Bootstrap.Registries
{
    public class ModelViewPresenterRegistry : Registry
    {
        public ModelViewPresenterRegistry()
        {
            Scan(scanner =>
            {
                scanner.RegisterConcreteTypesAgainstTheFirstInterface();
                scanner.AssemblyContainingType<PresenterBase>();
                scanner.WithDefaultConventions();
                scanner.SingleImplementationsOfInterface();
            });
        }
    }
}
