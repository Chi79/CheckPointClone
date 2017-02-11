using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace ModelViewPresenter.Bootstrap
{
    public class Bootstrapper
    {
        public IContainer Container;

        public void BootstrapStructureMap()
        {
            Container = new Container(AddRegistryInfo);
        }

        private static void AddRegistryInfo(IRegistry registry)
        {
            registry.Scan(scanner =>
            {
                scanner.AssemblyContainingType<Bootstrapper>();
                scanner.LookForRegistries();
            });
        }
    }
}
