using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointDataTables.Tables;
using CheckPointModel.Entities;

namespace CheckPointModel.Utilities
{
    public class AttendeeModelMapper
    {
        //TODO

        public static ATTENDEE ConvertAttendeeModelToAttendee( AttendeeModel attendeModel)
        {
           

            ATTENDEE attendee = new ATTENDEE();


            attendee.AppointmentId = attendeModel.AppointmentId;
            attendee.TagId = attendeModel.TagId;
            attendee.StatusId = attendeModel.StatusId;
            attendee.PersonalNote = attendeModel.PersonalNote;

            if (ValidateStringInput.IsStringValid(attendeModel.TimeAttended))  // allows timeattended to be null
            {
                DateTime parsedTimeAttended = DateTimeParser.ParseTimeAttended(attendeModel.TimeAttended);
                attendee.TimeAttended = parsedTimeAttended;
            }
            
            return attendee;

        }
    }
}
