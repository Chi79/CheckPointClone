using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointDataTables.Tables;
using CheckPointCommon.RepositoryInterfaces;

namespace DataAccess.Concrete.Repositories
{
    public class AppointmentRepository : Repository<APPOINTMENT>, IAppointmentRepository
    {
        public AppointmentRepository(CheckPointContext context):base(context)  // calls our base constructor Repository<User>
        {

        }
        public CheckPointContext CheckPointContext  // casting our context class as an entity DbContext 
        {
            get { return Context as CheckPointContext; }
        }

        public IEnumerable<APPOINTMENT> GetAllAppointmentsFor(string userName)
        {
            return CheckPointContext.APPOINTMENTs.Where(c => c.UserName == userName);
        }
    }
}
