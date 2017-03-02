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
    public class ManageAppointmentModel : IManageAppointmentModel<APPOINTMENT, AppointmentDTO>
    {
        //TODO
        public APPOINTMENT ConvertToAppointment(AppointmentDTO appointmentModel)
        {
            return AppointmentDTOMapper.ConvertAppointmentDTOToAppointment(appointmentModel);
        }
    }
}
