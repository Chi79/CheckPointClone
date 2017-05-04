using CheckPointCommon.ServiceInterfaces;
using CheckPointDataTables.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointModel.Services
{
    
    public class ShowClients : IShowClients
    {
        private List<CLIENT> emptyClientList = new List<CLIENT>();
        public IEnumerable<T> GetEmptyList<T>()
        {
            return emptyClientList as IEnumerable<T>;
        }
    }
}
