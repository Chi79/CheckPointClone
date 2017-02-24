using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.RepositoryInterfaces;
using CheckPointDataTables.Tables;

namespace DataAccess.Concrete.Repositories
{
    public class CourseRepository : Repository<COURSE> , ICourseRepository
    {
        public CourseRepository(CheckPointContext context):base(context)  // calls our base constructor Repository<User>
        {
            //TODO
        }
    }
}
