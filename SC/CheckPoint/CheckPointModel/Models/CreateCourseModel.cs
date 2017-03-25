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
    public class CreateCourseModel : ICreateCourseModel
    {
        //TODO
        public object ConvertToCourse(object courseDTO)
        {
            return CourseDTOMapper.ConvertCourseDTOToCourse(courseDTO as CourseDTO);
        }
    }
}
