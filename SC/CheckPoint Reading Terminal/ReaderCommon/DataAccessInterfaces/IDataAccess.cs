using CheckPoint.DTO;
using ReaderCommon.Enum;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReaderCommon.DataAccessInterfaces
{
    public interface IDataAccess
    {
        Task<RegistrationFeedbackStatus> UpdateAttendeeWithStampAndStatus(string tagId, string appointmentId, bool isAppointmentObligatory);

        Task<bool> AttemptLogin(string userName, string password);

        Task<Client> GetLoggedInHost(string userName);

        Task<IEnumerable<object>> GetHostAppointments(string hostUserName);

        
    }
}
