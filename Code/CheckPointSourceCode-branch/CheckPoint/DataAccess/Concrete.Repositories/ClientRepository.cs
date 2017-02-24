using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.RepositoryInterfaces;
using CheckPointDataTables.Tables;
using CheckPointCommon.Enums;

namespace DataAccess
{
    public class ClientRepository : Repository<CLIENT>, IClientRepository
    {
        
        public ClientRepository(CheckPointContext context):base(context)  // calls our base constructor Repository<User>
        {

        }
        public CheckPointContext CheckPointContext  // casting our context class as an entity DbContext 
        {
            get { return Context as CheckPointContext; }
        }
        public IEnumerable<CLIENT> GetAllUsers()
        {
            return CheckPointContext.CLIENTs.Where(c => - c.ClientType == (int)ClientType.User).OrderBy(c => c.FirstName);
        }
        public IEnumerable<CLIENT> GetClientByName(string name)
        {
            return CheckPointContext.CLIENTs.Where(c => c.UserName == name);
        }
        public bool Login(string userName, string Password, out int clientType)
        {
            clientType = 0;

            var result = CheckPointContext.CLIENTs
                .Where(c => c.UserName == userName)
                .Where(c => c.Password == Password);

            if (!result.Any())
            {
                return false;
            }
            var myresult = result.FirstOrDefault();
            clientType = myresult.ClientType;
            return true;
        }
        public CLIENT GetAClientByName(string clientName)
        {
            return CheckPointContext.CLIENTs
                .FirstOrDefault(client => client.UserName.Equals(clientName));
        }

        public List<string> GetAllUserNames()
        {
            return CheckPointContext.CLIENTs
                .Select(client => client.FirstName + " " + client.LastName)
                .ToList();
        }
    }
}
