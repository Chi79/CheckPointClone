using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Repository.RepositoryInterfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAttendeeRepository Attendees { get; }
        IAppointmentRepository Appointments { get; }
        ICourseRepository Courses { get; }
        IClientRepository Clients { get; }


        int Complete();
    }
}
