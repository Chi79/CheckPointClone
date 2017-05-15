using CheckPoint.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Repository.Mappers
{
    public class CourseMapper
    {
        public CourseMapper()
        {

        }

        public DTO.Course CreateCourse(COURSE course)
        {
            return new DTO.Course()
            {
                CourseId = course.CourseId,
                Name = course.Name,
                Description = course.Description,
                IsPrivate = course.IsPrivate
            };
        }

        public COURSE CreateCourse(DTO.Course course)
        {
            return new COURSE()
            {
                CourseId = course.CourseId,
                Name = course.Name,
                Description = course.Description,
                IsPrivate = course.IsPrivate
            };
        }

        public object CreateShapeDataObject(COURSE course, List<string> listOfFields)
        {
            //pass through from entity to DTO
            return CreateShapeDataObject(CreateCourse(course), listOfFields);
        }

        public object CreateShapeDataObject(DTO.Course course, List<string> listOfFields)
        {
            if (!listOfFields.Any())
            {
                return course;
            }
            else
            {
                ExpandoObject objectToReturn = new ExpandoObject();
                foreach (var field in listOfFields)
                {
                    var fieldValue = course.GetType()
                        .GetProperty(field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                        .GetValue(course, null);

                    ((IDictionary<string, object>)objectToReturn).Add(field, fieldValue);
                }

                return objectToReturn;
            }

        }
    }
}
