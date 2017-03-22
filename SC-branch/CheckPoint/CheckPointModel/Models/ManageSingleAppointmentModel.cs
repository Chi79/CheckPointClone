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
    public class ManageSingleAppointmentModel : IManageSingleAppointmentModel
    {
        public object ConvertToAppointment(object appointmentModel)
        {
            return AppointmentDTOMapper.ConvertAppointmentDTOToAppointment(appointmentModel as AppointmentDTO);
        }
        public object ConvertToCourse(object courseDTO)
        {
            return CourseDTOMapper.ConvertCourseDTOToCourse(courseDTO as CourseDTO);
        }
    }
}
