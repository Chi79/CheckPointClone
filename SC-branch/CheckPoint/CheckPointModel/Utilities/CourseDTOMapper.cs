using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointDataTables.Tables;
using CheckPointCommon.DTOInterfaces;

namespace CheckPointModel.Utilities
{
    public class CourseDTOMapper
    {
        //TODO
        public static COURSE ConvertCourseDTOToCourse(ICourseDTO courseDTO)
        {
            COURSE course = new COURSE()
            {
                Name = courseDTO.Name,
                Description = courseDTO.Description
            };

            return course;
        }
    }
}
