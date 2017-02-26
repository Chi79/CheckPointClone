using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ValidationInterfaces;
using CheckPointModel.DTOs;
using CheckPointModel.Utilities;


namespace CheckPointModel.Validation
{
    public class AppointmentValidator : Validator<AppointmentDTO> , IAppointmentValidator<AppointmentDTO>
    {
        //TODO
        private List<string> propertyList;
        private List<int> integerList = new List<int>();
        public List<string> FillPropertyList(AppointmentDTO appointment)
        {
            propertyList = ProperiesToStringListConverter<AppointmentDTO>.ConvertPropertiesToStringList(appointment);
            return propertyList;
        }
        public override void CheckForBrokenRules(AppointmentDTO appointment)
        {
            //if (!ValidateStringInput.AreStringsValid(propertyList))
            //{
            //    base.AddBrokenRule("One or more field is empty! Please fill in all fields. ");
            //}
            if(!ValidateStringInput.IsStringValid(appointment.AppointmentName))
            {
                base.AddBrokenRule("Appointment name must be filled!");
            }
            if (!ValidateStringInput.IsStringValid(appointment.UserName))
            {
                base.AddBrokenRule("User Name must be filled!");
            }
            if (appointment.Date != string.Empty)
            {
                CheckDateFormat(appointment.Date);
            }
            if (appointment.Date == string.Empty)
            {
                base.AddBrokenRule("Date must be filled!");
            }
            if (appointment.StartTime != string.Empty)
            {
                CheckStartTime(appointment.StartTime);
            }
            if (appointment.StartTime == string.Empty)
            {
                base.AddBrokenRule("Start Time must be filled!");
            }
            if (appointment.EndTime != string.Empty)
            {
                CheckEndTime(appointment.EndTime);
            }
            if (appointment.EndTime == string.Empty)
            {
                base.AddBrokenRule("End Time must be filled!");
            }
            //if (!ValidateDateInput.IsDateValidate(appointment.StartTime))
            //{
            //    base.AddBrokenRule("Time must be in correct format! Please enter a time hh:mm. ");
            //}
            //if (!ValidateDateInput.IsDateValidate(appointment.Date))
            //{
            //    base.AddBrokenRule("Dates must be in correct format! Please enter a date mm/dd/yyyy:  ");
            //}
            //if (!ValidateDateInput.IsDateValidate(appointment.EndTime))
            //{
            //    base.AddBrokenRule("Time must be in correct format! Please enter a time hh:mm. ");
            //}
            if (appointment.PostalCode.Length > 4)
            {
                base.AddBrokenRule("PostCode cannot exceed 4 characters!");
            }
            try
            {
                int courseIdInteger = Convert.ToInt32(appointment.CourseId);

                integerList.Add(courseIdInteger);
            }
            catch
            {
                base.AddBrokenRule("Course Id must be an valid integer value!");
            }
            try
            {
                int postcodeInteger = Convert.ToInt32(appointment.PostalCode);

                integerList.Add(postcodeInteger);
            }
            catch
            {
                base.AddBrokenRule("Course Id must be an valid integer value!");
            }

            if(integerList != null)
            {
                CheckIntegers(integerList);
            }     
        }
        private void CheckIntegers(List<int> integers)
        {
            bool integersAreValid = ValidateIntergerInput.AreIntegersValid(integerList);
            if(!integersAreValid)
            {
                base.AddBrokenRule("All integers must be positive whole numbers!");
            }
        }
        private void CheckDateFormat(string date)
        {
            if (!ValidateDateInput.IsDateValidate(date))
            {
                base.AddBrokenRule("Dates must be in correct format! Please enter a date mm/dd/yyyy:  ");
            }
        }
        private void CheckStartTime(string time)
        {
            if (!ValidateDateInput.IsDateValidate(time))
            {
                base.AddBrokenRule("Times must be in correct format! Please enter a time hh:mm .");
            }
        }
        private void CheckEndTime(string time)
        {
            if (!ValidateDateInput.IsDateValidate(time))
            {
                base.AddBrokenRule("Times must be in correct format! Please enter a time hh:mm .");
            }
        }
    }
}
