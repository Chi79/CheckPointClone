using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointDataTables.Tables;

namespace CheckPointCommon.ServiceInterfaces
{
   public interface IHandleAttendee:IHandler
    {
       void CreateRange<T>(IEnumerable<ATTENDEE> attendees);
    }
}
