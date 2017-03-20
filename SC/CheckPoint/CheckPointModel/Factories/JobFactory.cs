using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointModel.Services;
using CheckPointCommon.Enums;
using CheckPointCommon.ServiceInterfaces;
using CheckPointCommon.FactoryInterfaces;

namespace CheckPointModel.Factories
{

    public class JobFactory : IFactory
    {

        private IHandleAppointments _handler;

        private Dictionary<DbAction, JobServiceBase> Jobs; 
 
        public JobFactory(IHandleAppointments handler)
        {
            _handler = handler;
        }

        public void LoadDictionary(IHandleAppointments handler)
        {
            if (Jobs == null)
            {
                Jobs = new Dictionary<DbAction, JobServiceBase>();

                Jobs.Add(DbAction.Create, new CreateJob(handler));
                Jobs.Add(DbAction.Delete, new DeleteJob(handler));
                Jobs.Add(DbAction.Update, new UpdateJob(handler));
            }
        }

        public object CreateJobType(object action)
        {
            LoadDictionary(_handler);
            return Jobs[(DbAction)action] as JobServiceBase;
        }
    }
}
