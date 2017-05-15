using CheckPoint.Repository.ConcreteRepositories;
using CheckPoint.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Repository.RepositoryInterfaces
{
    public interface ICourseRepository : IRepository<COURSE>
    {
        IEnumerable<COURSE> GetAllCourses();
        COURSE GetSingleCourse(int courseId);

        RepositoryActionResult<COURSE> UpdateCourse(COURSE course);

        RepositoryActionResult<COURSE> DeleteCourse(int courseId);
    }
}
