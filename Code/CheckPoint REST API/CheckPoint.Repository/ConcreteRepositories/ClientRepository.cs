using CheckPoint.Repository.Entities;
using CheckPoint.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Repository.ConcreteRepositories
{
    public class ClientRepository : Repository<CLIENT>, IClientRepository
    {
        public ClientRepository(CheckPointContext context) : base(context)
        {

        }

        public CheckPointContext CheckPointContext
        {
            get { return Context as CheckPointContext; }
        }

        public IEnumerable<CLIENT> GetAllClients()
        {
            return CheckPointContext.CLIENT;
        }

        public CLIENT ValidateClient(string userName, string password)
        {
            return CheckPointContext.Set<CLIENT>().FirstOrDefault(c => c.UserName == userName && c.Password == password && c.ClientType == 1);
                
        }

        public CLIENT GetSingleClient(string userName)
        {
            return CheckPointContext.Set<CLIENT>().FirstOrDefault(c => c.UserName == userName);
        }

        public RepositoryActionResult<CLIENT> UpdateClient(CLIENT client)
        {
            try
            {

                var existingClient = Context.Set<CLIENT>().FirstOrDefault(exg => exg.UserName == client.UserName);

                if (existingClient == null)
                {
                    return new RepositoryActionResult<CLIENT>(client, RepositoryActionStatus.NotFound);
                }

                // change the original entity status to detached; otherwise, we get an error on attach
                // as the entity is already in the dbSet

                // set original entity state to detached
                Context.Entry(existingClient).State = EntityState.Detached;

                // attach & save
                Context.Set<CLIENT>().Attach(client);

                // set the updated entity state to modified, so it gets updated.
                Context.Entry(client).State = EntityState.Modified;


                var result = Context.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<CLIENT>(client, RepositoryActionStatus.Updated);
                }
                else
                {
                    return new RepositoryActionResult<CLIENT>(client, RepositoryActionStatus.NothingModified, null);
                }

            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<CLIENT>(null, RepositoryActionStatus.Error, ex);
            }

        }

        public RepositoryActionResult<CLIENT> DeleteClient(string userName)
        {
            try
            {
                var client = Context.Set<CLIENT>().Where(c => c.UserName == userName).FirstOrDefault();
                if (client != null)
                {
                    Context.Set<CLIENT>().Remove(client);
                    Context.SaveChanges();
                    return new RepositoryActionResult<CLIENT>(null, RepositoryActionStatus.Deleted);
                }
                return new RepositoryActionResult<CLIENT>(null, RepositoryActionStatus.NotFound);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<CLIENT>(null, RepositoryActionStatus.Error, ex);
            }
        }

     
    }
}
