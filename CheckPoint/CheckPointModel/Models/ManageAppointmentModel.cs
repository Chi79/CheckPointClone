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
        public object ConvertToAppointment(object appointmentDTO)
        {
            return AppointmentDTOMapper.ConvertAppointmentDTOToAppointment(appointmentDTO as AppointmentDTO);
        }
        public object ConvertToCourse(object courseDTO)
        {
            return CourseDTOMapper.ConvertCourseDTOToCourse(courseDTO as CourseDTO);
        }
    }
}
