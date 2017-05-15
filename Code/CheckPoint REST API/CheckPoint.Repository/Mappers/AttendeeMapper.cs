using CheckPoint.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Repository.Mappers
{
    public class AttendeeMapper
    {
        public AttendeeMapper()
        {

        }

        public DTO.Attendee CreateAttendee(ATTENDEE attendee)
        {
            return new DTO.Attendee()
            {
                TagId = attendee.TagId,
                AppointmentId = attendee.AppointmentId,
                TimeAttended = attendee.TimeAttended,
                StatusId = attendee.StatusId,
                PersonalNote = attendee.PersonalNote
            };
        }

        public ATTENDEE CreateAttendee(DTO.Attendee attendee)
        {
            return new ATTENDEE()
            {
                TagId = attendee.TagId,
                AppointmentId = attendee.AppointmentId,
                TimeAttended = attendee.TimeAttended,
                StatusId = attendee.StatusId,
                PersonalNote = attendee.PersonalNote
            };
        }

        public object CreateShapeDataObject(ATTENDEE attendee, List<string> listOfFields)
        {
            //pass through from entity to DTO
            return CreateShapeDataObject(CreateAttendee(attendee), listOfFields);
        }

        public object CreateShapeDataObject(DTO.Attendee client, List<string> listOfFields)
        {
            if (!listOfFields.Any())
            {
                return client;
            }
            else
            {
                ExpandoObject objectToReturn = new ExpandoObject();
                foreach (var field in listOfFields)
                {
                    var fieldValue = client.GetType()
                        .GetProperty(field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                        .GetValue(client, null);

                    ((IDictionary<string, object>)objectToReturn).Add(field, fieldValue);
                }

                return objectToReturn;
            }

        }
    }
}
