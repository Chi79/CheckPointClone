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
    public class AttendeeRepository : Repository<ATTENDEE>, IAttendeeRepository
    {
        public AttendeeRepository(CheckPointContext context) : base(context)
        {
        }

        public CheckPointContext CheckPointContext
        {
            get { return Context as CheckPointContext; }
        }

        public IEnumerable<ATTENDEE> GetAllAttendees()
        {
            return CheckPointContext.ATTENDEE;
        }

        public IEnumerable<ATTENDEE> GetAllAttendeesForAppointment(int id)
        {
            return CheckPointContext.Set<ATTENDEE>().Where(a => a.AppointmentId.Equals(id));
        }

        public ATTENDEE GetSingleAttendeeForAppointment(int appointmentId, string tagId)
        {
            return CheckPointContext.Set<ATTENDEE>().FirstOrDefault(a => a.AppointmentId == appointmentId && a.TagId == tagId);
        }


        public RepositoryActionResult<ATTENDEE> UpdateAttendee(ATTENDEE attendee)
        {
            try
            {

                var existingAttendee = Context.Set<ATTENDEE>().FirstOrDefault(exa => exa.TagId == attendee.TagId && exa.AppointmentId == attendee.AppointmentId);

                if (existingAttendee == null)
                {
                    return new RepositoryActionResult<ATTENDEE>(attendee, RepositoryActionStatus.NotFound);
                }

                // change the original entity status to detached; otherwise, we get an error on attach
                // as the entity is already in the dbSet

                // set original entity state to detached
                Context.Entry(existingAttendee).State = EntityState.Detached;

                // attach & save
                Context.Set<ATTENDEE>().Attach(attendee);

                // set the updated entity state to modified, so it gets updated.
                Context.Entry(attendee).State = EntityState.Modified;


                var result = Context.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<ATTENDEE>(attendee, RepositoryActionStatus.Updated);
                }
                else
                {
                    return new RepositoryActionResult<ATTENDEE>(attendee, RepositoryActionStatus.NothingModified, null);
                }

            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<ATTENDEE>(null, RepositoryActionStatus.Error, ex);
            }

        }

        public RepositoryActionResult<ATTENDEE> DeleteAttendee(string tagId)
        {
            try
            {
                var attendee = Context.Set<ATTENDEE>().Where(a => a.TagId == tagId).FirstOrDefault();
                if (attendee != null)
                {
                    Context.Set<ATTENDEE>().Remove(attendee);
                    Context.SaveChanges();
                    return new RepositoryActionResult<ATTENDEE>(null, RepositoryActionStatus.Deleted);
                }
                return new RepositoryActionResult<ATTENDEE>(null, RepositoryActionStatus.NotFound);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<ATTENDEE>(null, RepositoryActionStatus.Error, ex);
            }
        }

        public ATTENDEE GetSingleAttendee(string tagId)
        {
            return CheckPointContext.Set<ATTENDEE>().FirstOrDefault(a => a.TagId == tagId);
        }
    }
}
