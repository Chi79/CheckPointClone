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
    public class AppointmentRepository : Repository<APPOINTMENT>, IAppointmentRepository
    {
        public AppointmentRepository(CheckPointContext context) : base(context)
        {
        }


        public CheckPointContext CheckPointContext
        {
            get { return Context as CheckPointContext; }
        }

        public IEnumerable<APPOINTMENT> GetAllAppointments()
        {
            return CheckPointContext.APPOINTMENT;
        }

        

        public APPOINTMENT GetSingleAppointment(int appointmentId)
        {
            return CheckPointContext.Set<APPOINTMENT>().FirstOrDefault(a => a.AppointmentId == appointmentId);
        }

        public RepositoryActionResult<APPOINTMENT> UpdateAppointment(APPOINTMENT appointment)
        {
            try
            {

                // you can only update when an expensegroup already exists for this id

                var existingAppointment = Context.Set<APPOINTMENT>().FirstOrDefault(exa => exa.AppointmentId == appointment.AppointmentId);

                if (existingAppointment == null)
                {
                    return new RepositoryActionResult<APPOINTMENT>(appointment, RepositoryActionStatus.NotFound);
                }

                // change the original entity status to detached; otherwise, we get an error on attach
                // as the entity is already in the dbSet

                // set original entity state to detached
                Context.Entry(existingAppointment).State = EntityState.Detached;

                // attach & save
                Context.Set<APPOINTMENT>().Attach(appointment);

                // set the updated entity state to modified, so it gets updated.
                Context.Entry(appointment).State = EntityState.Modified;


                var result = Context.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<APPOINTMENT>(appointment, RepositoryActionStatus.Updated);
                }
                else
                {
                    return new RepositoryActionResult<APPOINTMENT>(appointment, RepositoryActionStatus.NothingModified, null);
                }

            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<APPOINTMENT>(null, RepositoryActionStatus.Error, ex);
            }

        }

        public RepositoryActionResult<APPOINTMENT> DeleteAppointment(int appointmentId)
        {
            try
            {
                var appointment = Context.Set<APPOINTMENT>().Where(a => a.AppointmentId == appointmentId).FirstOrDefault();
                if (appointment != null)
                {
                    Context.Set<APPOINTMENT>().Remove(appointment);
                    Context.SaveChanges();
                    return new RepositoryActionResult<APPOINTMENT>(null, RepositoryActionStatus.Deleted);
                }
                return new RepositoryActionResult<APPOINTMENT>(null, RepositoryActionStatus.NotFound);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<APPOINTMENT>(null, RepositoryActionStatus.Error, ex);
            }
        }

        public IEnumerable<APPOINTMENT> GetClientsAppointments(string clientId)
        {
            return CheckPointContext.APPOINTMENT.Where(a => a.UserName.Equals(clientId) && a.Date >= DateTime.Now);

                
        }
    }
}
