using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointDataTables.Tables;
using CheckPointModel.DTOs;
using CheckPointModel.Utilities;

namespace CheckPointModel.Models
{
    public class ManageAppointmentModel : IManageAppointmentModel
    {
        public object ConvertToAppointment(object appointmentModel)
        {
            return AppointmentDTOMapper.ConvertAppointmentDTOToAppointment(appointmentModel as AppointmentDTO);
        }
    }
}
