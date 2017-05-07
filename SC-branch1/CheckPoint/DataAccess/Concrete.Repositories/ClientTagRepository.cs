using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.RepositoryInterfaces;
using CheckPointDataTables.Tables;

namespace DataAccess.Concrete.Repositories
{
    public class ClientTagRepository : Repositories.Repository<CLIENT_TAG>, IClientTagRepository
    {
        
        public ClientTagRepository(CheckPointContext context) : base(context)
        {
            
        }
        public CheckPointContext CheckPointContext  // casting our context class as an entity DbContext 
        {
            get { return Context as CheckPointContext; }
        }
        public string GetClientTagId(string userName)
        {            
            var result = CheckPointContext.CLIENT_TAG
                 .Where(ct => ct.UserName == userName);

            if (!result.Any())
            {
                //throw new Exception("No TagId found for this client");   
                return null;   
            }
            else
            {
                var myResult = result.FirstOrDefault();

                return myResult.TagId;
            }
          

        }


    }
}
