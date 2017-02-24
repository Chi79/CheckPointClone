using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointDataTables.Tables;
using CheckPointModel.Entities;

namespace CheckPointModel.Utilities
{
    public class AppointmentModelMapper
    {
        public static APPOINTMENT ConvertAppointmentModelToAppointment(AppointmentModel appointmentModel)
        {
            DateTime parsedFromTime, parsedToTime, parsedDate;
            parsedFromTime = DateTimeParser.ParseAppointmentData(appointmentModel.StartTime);
            parsedToTime = DateTimeParser.ParseAppointmentData(appointmentModel.EndTime);
            parsedDate = DateTimeParser.ParseAppointmentData(appointmentModel.Date);

            APPOINTMENT appointment = new APPOINTMENT()
            {
                CourseId = appointmentModel.CourseId,
                AppointmentName = appointmentModel.AppointmentName,
                Description = appointmentModel.Description,
                Date = parsedDate,
                StartTime = parsedFromTime.TimeOfDay,
                EndTime = parsedToTime.TimeOfDay,
                Address = appointmentModel.Address,
                PostalCode = Convert.ToInt32(appointmentModel.PostalCode),
                UserName = appointmentModel.UserName,
                IsCancelled = appointmentModel.IsCancelled,
                IsObligatory = appointmentModel.IsObligatory,
            }; 
            return appointment;
        }    //TODO
    }
}
