using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointDataTables.Tables;
using CheckPointModel.DTOs;

namespace CheckPointModel.Utilities
{
    public class AttendeeDTOMapper
    {
        //TODO

        public static ATTENDEE ConvertAttendeeDTOToAttendee(AttendeeDTO attendeDTO)
        {
           

            ATTENDEE attendee = new ATTENDEE();


            attendee.AppointmentId = attendeDTO.AppointmentId;
            attendee.TagId = attendeDTO.TagId;
            attendee.StatusId = attendeDTO.StatusId;
            attendee.PersonalNote = attendeDTO.PersonalNote;

            if (ValidateStringInput.IsStringValid(attendeDTO.TimeAttended))  // allows timeattended to be null
            {
                DateTime parsedTimeAttended = DateTimeParser.ParseTimeAttended(attendeDTO.TimeAttended);
                attendee.TimeAttended = parsedTimeAttended;
            }
            
            return attendee;

        }
    }
}
