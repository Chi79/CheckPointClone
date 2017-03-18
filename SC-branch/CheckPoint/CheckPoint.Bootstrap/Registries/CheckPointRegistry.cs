using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using CheckPointPresenters.Bases;
using DataAccess.Concrete.Repositories;
using CheckPointModel.Models;
using CheckPointCache.Cache;



namespace CheckPoint.Bootstrap.Registries
{
    public class CheckPointRegistry : Registry 
    {
        public CheckPointRegistry()
        {
            Scan(scanner =>
            {    
                scanner.RegisterConcreteTypesAgainstTheFirstInterface();
                scanner.AssemblyContainingType<CacheData>();
                scanner.AssemblyContainingType<LoginModel>();
                scanner.AssemblyContainingType<UnitOfWork>();
                scanner.AssemblyContainingType<PresenterBase>();
                scanner.WithDefaultConventions();
                scanner.SingleImplementationsOfInterface();
            });
        }
        
    }
}
