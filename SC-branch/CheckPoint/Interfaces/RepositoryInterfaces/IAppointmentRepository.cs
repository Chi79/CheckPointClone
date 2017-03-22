using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointDataTables.Tables;

namespace CheckPointCommon.RepositoryInterfaces
{
    public interface IAppointmentRepository : IRepository<APPOINTMENT>
    {
        IEnumerable<APPOINTMENT> GetAllAppointmentsFor(string userName);

        APPOINTMENT GetAppointmentByAppointmentName(string appointmentName);

        APPOINTMENT GetAppointmentByAppointmentId(int appointmentId);
    }
}
