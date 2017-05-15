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
    public class CourseRepository : Repository<COURSE>, ICourseRepository
    {
        public CourseRepository(CheckPointContext context) : base(context)
        {
        }

        public CheckPointContext CheckPointContext
        {
            get { return Context as CheckPointContext; }
        }

        public IEnumerable<COURSE> GetAllCourses()
        {
            return CheckPointContext.COURSE;
        }

        public COURSE GetSingleCourse(int courseId)
        {
            return CheckPointContext.Set<COURSE>().FirstOrDefault(c => c.CourseId == courseId);
        }

        public RepositoryActionResult<COURSE> UpdateCourse(COURSE course)
        {
            try
            {

                // you can only update when an expensegroup already exists for this id

                var existingCourse = Context.Set<COURSE>().FirstOrDefault(exc => exc.CourseId == course.CourseId);

                if (existingCourse == null)
                {
                    return new RepositoryActionResult<COURSE>(course, RepositoryActionStatus.NotFound);
                }

                // change the original entity status to detached; otherwise, we get an error on attach
                // as the entity is already in the dbSet

                // set original entity state to detached
                Context.Entry(existingCourse).State = EntityState.Detached;

                // attach & save
                Context.Set<COURSE>().Attach(course);

                // set the updated entity state to modified, so it gets updated.
                Context.Entry(course).State = EntityState.Modified;


                var result = Context.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<COURSE>(course, RepositoryActionStatus.Updated);
                }
                else
                {
                    return new RepositoryActionResult<COURSE>(course, RepositoryActionStatus.NothingModified, null);
                }

            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<COURSE>(null, RepositoryActionStatus.Error, ex);
            }

        }

        public RepositoryActionResult<COURSE> DeleteCourse(int courseId)
        {
            try
            {
                var course = Context.Set<COURSE>().Where(c => c.CourseId == courseId).FirstOrDefault();
                if (course != null)
                {
                    Context.Set<COURSE>().Remove(course);
                    Context.SaveChanges();
                    return new RepositoryActionResult<COURSE>(null, RepositoryActionStatus.Deleted);
                }
                return new RepositoryActionResult<COURSE>(null, RepositoryActionStatus.NotFound);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<COURSE>(null, RepositoryActionStatus.Error, ex);
            }
        }
    }
}
