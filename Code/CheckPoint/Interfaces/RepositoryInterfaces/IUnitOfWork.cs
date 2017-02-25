using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.Structs;

namespace CheckPointCommon.RepositoryInterfaces
{
    public interface IUnitOfWork : IDisposable //inherits from IDisposable
    {
        IClientRepository CLIENTs { get; }   //exposes our repositories via interfaces (testable)
        IAppointmentRepository APPOINTMENTs { get; }
        ICourseRepository COURSEs { get; }
        IAttendeeRepository ATTENDEEs { get; } 
        SaveResult Complete();
        
    }
}
