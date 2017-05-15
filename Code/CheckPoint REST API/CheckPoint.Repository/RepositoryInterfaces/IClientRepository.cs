using CheckPoint.Repository.ConcreteRepositories;
using CheckPoint.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Repository.RepositoryInterfaces
{
    public interface IClientRepository : IRepository<CLIENT>
    {
        IEnumerable<CLIENT> GetAllClients();
        CLIENT GetSingleClient(string userName);

        RepositoryActionResult<CLIENT> UpdateClient(CLIENT client);

        RepositoryActionResult<CLIENT> DeleteClient(string userName);

        CLIENT ValidateClient(string userName, string password);
    }
}
