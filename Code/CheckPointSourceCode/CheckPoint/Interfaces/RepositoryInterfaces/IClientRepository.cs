using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointDataTables.Tables;
using CheckPointCommon.Structs;

namespace CheckPointCommon.RepositoryInterfaces
{
    public interface IClientRepository : IRepository<CLIENT> 
    {
        IEnumerable<CLIENT> GetAllUsers();
        IEnumerable<CLIENT> GetClientByName(string name);
        LoginResult Login(string userName, string Password);
        CLIENT GetAClientByName(string clientName);
        List<string> GetAllUserNames();
    }
}
