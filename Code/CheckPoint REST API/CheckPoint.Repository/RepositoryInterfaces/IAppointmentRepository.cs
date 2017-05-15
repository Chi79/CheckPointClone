using CheckPoint.Repository.ConcreteRepositories;
using CheckPoint.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Repository.RepositoryInterfaces
{
    public interface IAppointmentRepository : IRepository<APPOINTMENT>
    {
        IEnumerable<APPOINTMENT> GetAllAppointments();

        IEnumerable<APPOINTMENT> GetClientsAppointments(string clientId);
        APPOINTMENT GetSingleAppointment(int appointmentId);

        RepositoryActionResult<APPOINTMENT> UpdateAppointment(APPOINTMENT appointment);

        RepositoryActionResult<APPOINTMENT> DeleteAppointment(int appointmentId);
    }
}
