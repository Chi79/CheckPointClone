using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPoint.DTO;
using CheckPoint.Repository.Entities;
using System.Dynamic;
using System.Reflection;

namespace CheckPoint.Repository.Mappers
{
    public class AppointmentMapper
    {
        public AppointmentMapper()
        {

        }

        public Appointment CreateAppointment(APPOINTMENT appointment)
        {
            return new DTO.Appointment()
            {
                AppointmentId = appointment.AppointmentId,
                //CourseId = appointment.CourseId,
                AppointmentName = appointment.AppointmentName,
                //Address = appointment.Address,
                //PostalCode = appointment.PostalCode,
                Date = appointment.Date,
                StartTime = appointment.StartTime,
                EndTime = appointment.EndTime,
                Description = appointment.Description,
                //UserName = appointment.UserName,
                IsObligatory = appointment.IsObligatory,
                //IsCancelled = appointment.IsCancelled
            };
        }

        public APPOINTMENT CreateAppointment(DTO.Appointment appointment)
        {
            return new APPOINTMENT()
            {
                AppointmentId = appointment.AppointmentId,
                //CourseId = appointment.CourseId,
                AppointmentName = appointment.AppointmentName,
                //Address = appointment.Address,
                //PostalCode = appointment.PostalCode,
                Date = appointment.Date,
                StartTime = (TimeSpan)appointment.StartTime,
                EndTime = (TimeSpan)appointment.EndTime,
                Description = appointment.Description,
                //UserName = appointment.UserName,
                IsObligatory = appointment.IsObligatory,
                //IsCancelled = appointment.IsCancelled
            };
        }

        public object CreateShapeDataObject(APPOINTMENT appointment, List<string> listOfFields)
        {
            //pass through from entity to DTO
            return CreateShapeDataObject(CreateAppointment(appointment), listOfFields);
        }

        public object CreateShapeDataObject(DTO.Appointment appointment, List<string> listOfFields)
        {
            if (!listOfFields.Any())
            {
                return appointment;
            }
            else
            {
                ExpandoObject objectToReturn = new ExpandoObject();
                foreach (var field in listOfFields)
                {
                    var fieldValue = appointment.GetType()
                        .GetProperty(field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                        .GetValue(appointment, null);

                    ((IDictionary<string, object>)objectToReturn).Add(field, fieldValue);
                }

                return objectToReturn;
            }


        }
    }
}
