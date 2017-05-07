using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ValidationInterfaces;
using CheckPointCommon.DTOInterfaces;
using CheckPointModel.Utilities;

namespace CheckPointModel.Validation
{
    public class CourseValidator : Validator<ICourseDTO>, ICourseValidator<ICourseDTO>
    {
        //TODO
        public List<string> FillPropertyList(ICourseDTO course)
        {
            return ProperiesToStringListConverter<ICourseDTO>.ConvertPropertiesToStringList(course);
        }
        public override void CheckForBrokenRules(ICourseDTO course)
        {
            var propertyList = FillPropertyList(course);

            if (!ValidateStringInput.AreStringsValid(propertyList))
            {
                base.AddBrokenRule("One or more field is empty!  <br /> <br /> Please fill in all fields. ");
            }
        }
    }
}
