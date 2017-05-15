using CheckPoint.Repository.Entities;
using CheckPoint.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Repository.ConcreteRepositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CheckPointContext _context;

        public IAttendeeRepository Attendees { get; private set; }
        public IAppointmentRepository Appointments { get; private set; }
        public ICourseRepository Courses { get; private set; }
        public IClientRepository Clients { get; private set; }

        public UnitOfWork(CheckPointContext context)
        {
            _context = context;
            Attendees = new AttendeeRepository(_context);
            Clients = new ClientRepository(_context);
            Appointments = new AppointmentRepository(_context);
            Courses = new CourseRepository(_context);


        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
