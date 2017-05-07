using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ValidationInterfaces;
using CheckPointModel.Utilities;
using CheckPointCommon.DTOInterfaces;



namespace CheckPointModel.Validation
{
    public class AppointmentValidator : Validator<IAppointmentDTO>, IAppointmentValidator<IAppointmentDTO>
    {

        public List<string> FillPropertyList(IAppointmentDTO appointment)
        {
            return ProperiesToStringListConverter<IAppointmentDTO>.ConvertPropertiesToStringList(appointment);
        }
        public override void CheckForBrokenRules(IAppointmentDTO appointment)
        {
            var propertyList = FillPropertyList(appointment);

            if (!ValidateStringInput.AreStringsValid(propertyList))
            {
                base.AddBrokenRule("One or more field is empty! Please fill in all fields. <br /> ");
            }
            if (!ValidateDateInput.IsDateValidate(appointment.StartTime))
            {
                base.AddBrokenRule("Start Time must be in correct format! hh:mm. <br />");
            }
            if (!ValidateDateInput.IsDateValidate(appointment.Date))
            {
                base.AddBrokenRule("Dates must be in correct format! mm/dd/yyyy: <br />");
            }
            if (!ValidateDateInput.IsDateValidate(appointment.EndTime))
            {
                base.AddBrokenRule("End Time must be in correct format! hh:mm. <br /> ");
            }
            if (appointment.PostalCode.Length > 4)
            {
                base.AddBrokenRule("PostCode cannot exceed 4 characters! <br />");
            }
            try
            {
                int postcodeInteger = Convert.ToInt32(appointment.PostalCode);
            }
            catch
            {
                base.AddBrokenRule("Postal Code not found! <br /> Please check Postal Code is valid ");
            }
        }
    }
}
