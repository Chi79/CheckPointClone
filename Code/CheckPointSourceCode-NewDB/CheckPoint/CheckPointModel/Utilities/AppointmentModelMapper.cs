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
            parsedFromTime = DateTimeParser.ParseAppointmentData(appointmentModel.FromTime);
            parsedToTime = DateTimeParser.ParseAppointmentData(appointmentModel.ToTime);
            parsedDate = DateTimeParser.ParseAppointmentData(appointmentModel.Date);

            APPOINTMENT appointment = new APPOINTMENT()
            {
                AppointmentName = appointmentModel.AppointmentName,
                Description = appointmentModel.Description,
                Date = parsedDate,
                FromTime = parsedFromTime.TimeOfDay,
                ToTime = parsedToTime.TimeOfDay,
                StreetAddress = appointmentModel.StreetAddress,
                PostalCode = Convert.ToInt32(appointmentModel.PostalCode),
                UserName = appointmentModel.UserName,
                Private = appointmentModel.Private,
                IsCancelled = appointmentModel.IsCancelled,
                IsObligatory = appointmentModel.IsObligatory,
            }; 
            return appointment;
        }    //TODO
    }
}
