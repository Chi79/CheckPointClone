using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointModel.DTOs;
using CheckPointModel.Utilities;

namespace CheckPointModel.Models
{
    public class CreateAppointmentModel : ICreateAppointmentModel
    {
        public object ConvertToAppointment(object appointmentDTO)
        {
            return AppointmentDTOMapper.ConvertAppointmentDTOToAppointment(appointmentDTO as AppointmentDTO);
        }
    }
}
