using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjectionManager
{
    class Manager
    {
        public IContainer Container;

        public void ManagerStructureMap()
        {
            Container = new Container(AddRegistryInfo);
        }

        private static void AddRegistryInfo(IRegistry registry)
        {
            registry.Scan(scanner =>
            {
                scanner.AssemblyContainingType<Manager>();
                scanner.LookForRegistries();
            });
        }
    }
}
