using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointDataTables.Tables;
using CheckPointModel.Entities;
using CheckPointModel.Utilities;

namespace CheckPointModel.Models
{
    public class CreateAppointmentModel : ICreateAppointmentModel<APPOINTMENT, AppointmentModel>
    {
        public APPOINTMENT ConvertAppointmentModelToAppointment(AppointmentModel appointmentModel)
        {
            return AppointmentModelMapper.ConvertAppointmentModelToAppointment(appointmentModel);
        }
    }
}
