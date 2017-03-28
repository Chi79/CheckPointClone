using InjectionManager.Registries;
using ReaderPresenters.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InjectionManager
{
    public class Initializer
    {
        public void Init()
        {
            var manager = new Manager();
            manager.ManagerStructureMap();
            manager.Container.Configure(c =>
            {
                c.IncludeRegistry<ReaderRegistry>();
            });

            IOC.Container = manager.Container;
            
            
            
            
            
        }
    }
}
