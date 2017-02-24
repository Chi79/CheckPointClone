using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointDataTables.Tables;

namespace CheckPointCommon.RepositoryInterfaces
{
    public interface IClientRepository : IRepository<CLIENT> 
    {
        IEnumerable<CLIENT> GetAllUsers();
        IEnumerable<CLIENT> GetClientByName(string name);
        bool Login(string userName, string Password , out int clientType);
        CLIENT GetAClientByName(string clientName);
        List<string> GetAllUserNames();
    }
}
