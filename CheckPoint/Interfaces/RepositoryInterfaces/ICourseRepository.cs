using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointDataTables.Tables;

namespace CheckPointCommon.RepositoryInterfaces
{
    public interface ICourseRepository : IRepository<COURSE>
    {
        IEnumerable<COURSE> GetAllCoursesFor(string userName);

        COURSE GetCourseByCourseName(string courseName);

        COURSE GetCourseByCourseId(int coursetId);
    }
}
