using CheckPointCommon.RepositoryInterfaces;
using CheckPointCommon.ServiceInterfaces;
using CheckPointDataTables.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointModel.Services
{
    public class ShowAttendees : IShowAttendees
    {
        
        private List<ATTENDEE> emptyAttendeeList = new List<ATTENDEE>();

        public ShowAttendees()
        {
            
        }
        public IEnumerable<T> GetEmptyList<T>()
        {
            return emptyAttendeeList as IEnumerable<T>;
        }
    }
}
