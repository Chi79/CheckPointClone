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
        public List<string> FillPropertyList(ICourseDTO appointment)
        {
            return ProperiesToStringListConverter<ICourseDTO>.ConvertPropertiesToStringList(appointment);
        }
        public override void CheckForBrokenRules(ICourseDTO appointment)
        {
            var propertyList = FillPropertyList(appointment);

            if (!ValidateStringInput.AreStringsValid(propertyList))
            {
                base.AddBrokenRule("One or more field is empty! Please fill in all fields. ");
            }
        }
    }
}
