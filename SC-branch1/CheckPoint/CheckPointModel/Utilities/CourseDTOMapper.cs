using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointDataTables.Tables;
using CheckPointCommon.DTOInterfaces;
using CheckPointModel.DTOs;

namespace CheckPointModel.Utilities
{
    public class CourseDTOMapper
    {
        //TODO
        public static COURSE ConvertCourseDTOToCourse(ICourseDTO courseDTO)
        {
            COURSE course = new COURSE()
            {
                UserName = courseDTO.UserName,
                Name = courseDTO.Name,
                Description = courseDTO.Description,
                IsPrivate = courseDTO.IsPrivate,
                IsObligatory = courseDTO.IsObligatory,
                CourseId = courseDTO.CourseId

            };

            return course;


        }
    }
}
