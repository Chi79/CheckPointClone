using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ServiceInterfaces;
using CheckPointDataTables.Tables;
using CheckPointCommon.RepositoryInterfaces;

namespace CheckPointModel.Services
{
    public class AttendeeHandler : IHandleAttendee
    {
        IUnitOfWork _uOW;

        public AttendeeHandler(IUnitOfWork uOW)
        {
            _uOW = uOW;
        }
        public void Create<T>(T attendee)
        {
            _uOW.ATTENDEEs.Add(attendee as ATTENDEE);
        }

        public void CreateRange<T>(IEnumerable<ATTENDEE> attendees)
        {
            _uOW.ATTENDEEs.AddRange(attendees);
        }

        public void Delete<T>(T item)
        {
            throw new NotImplementedException();
        }

        public object SaveChanges()
        {
            return _uOW.Complete();
        }
    }
}
