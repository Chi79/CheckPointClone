using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointDataTables.Tables;
using CheckPointCommon.DTOInterfaces;

namespace CheckPointModel.Utilities
{
    public class AppointmentDTOMapper
    {
        public static APPOINTMENT ConvertAppointmentDTOToAppointment(IAppointmentDTO appointmentDTO)
        {  
            DateTime parsedFromTime, parsedToTime, parsedDate;
            parsedFromTime = DateTimeParser.ParseAppointmentData(appointmentDTO.StartTime);
            parsedToTime = DateTimeParser.ParseAppointmentData(appointmentDTO.EndTime);
            parsedDate = DateTimeParser.ParseAppointmentData(appointmentDTO.Date);

            APPOINTMENT appointment = new APPOINTMENT()
            {
                AppointmentName = appointmentDTO.AppointmentName,
                Description = appointmentDTO.Description,
                Date = parsedDate,
                StartTime = parsedFromTime.TimeOfDay,
                EndTime = parsedToTime.TimeOfDay,
                Address = appointmentDTO.Address,
                PostalCode = Convert.ToInt32(appointmentDTO.PostalCode),
                UserName = appointmentDTO.UserName,
                IsCancelled = appointmentDTO.IsCancelled,
                IsObligatory = appointmentDTO.IsObligatory,
            }; 
            return appointment;
        }    //TODO
    }
}
