using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ValidationInterfaces;
using CheckPointModel.Entities;
using CheckPointModel.Utilities;


namespace CheckPointModel.Validation
{
    public class AppointmentValidator : Validator<AppointmentModel> , IAppointmentValidator<AppointmentModel>
    {
        //TODO
        private List<string> propertyList;
        public List<string> FillPropertyList(AppointmentModel appointment)
        {
            propertyList = ProperiesToStringListConverter<AppointmentModel>.ConvertPropertiesToStringList(appointment);
            return propertyList;
        }
        public override void CheckForBrokenRules(AppointmentModel appointment)
        {
            if (!ValidateStringInput.AreStringsValid(propertyList))
            {
                base.AddBrokenRule("One or more field is empty! Please fill in all fields. ");
            }
            if (!ValidateDateInput.IsDateValidate(appointment.FromTime))
            {
                base.AddBrokenRule("Dates must be in correct format! Please enter a date mm/dd/yyyy: hh:mm:ss . ");
            }
            if (!ValidateDateInput.IsDateValidate(appointment.ToTime))
            {
                base.AddBrokenRule("Dates must be in correct format! Please enter a date mm/dd/yyyy: hh:mm:ss . ");
            }
        }
    }
}
