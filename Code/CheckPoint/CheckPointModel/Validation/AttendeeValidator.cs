using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointModel.Entities;
using CheckPointModel.Utilities;
using CheckPointCommon.Enums;
using CheckPointCommon.ValidationInterfaces;
namespace CheckPointModel.Validation
{
    public class AttendeeValidator:Validator<AttendeeModel>,IAttendeeValidator<AttendeeModel>
    {
        //this class is not tested

        /// <summary>
        /// Checks the AttendeeModel for Broken Business Rules
        /// </summary>
        /// <param name="attendee"></param>
        public override void CheckForBrokenRules(AttendeeModel attendee)
        {
            string errorMessage;         

            if (!ValidateIntergerInput.IsIntergerValid(attendee.AppointmentId))
                base.AddBrokenRule("AppointmentId is not valid");                       

            if(!ValidateStringInput.IsStringValid(attendee.TagId))
                base.AddBrokenRule("TagId field is empty");

            if (!Enum.IsDefined(typeof(AttendeeStatus), attendee.StatusId))
                base.AddBrokenRule("StatusId is not valid");
           

            if (!(ValidateTimeAttended(attendee, out errorMessage)))
                base.AddBrokenRule("Time Attended is not valid because:  " + errorMessage);
        }

        public bool ValidateTimeAttended(AttendeeModel attendee, out string message)
        {       
            if (!(attendee.StatusId == (int)AttendeeStatus.ObligHasAttended || attendee.StatusId == (int)AttendeeStatus.HasAttended))
            {
                message = "Status is not "+ AttendeeStatus.HasAttended.ToString()+" or "+AttendeeStatus.ObligHasAttended.ToString();                
                return false;
            }

            if(!ValidateStringInput.IsStringValid(attendee.TimeAttended))
            {
                message = "Field is empty "; ;
                return false;
            }

            if (!ValidateDateInput.IsDateValidate(attendee.TimeAttended))            
                {
                message = "Dates must be in correct format mm/dd/yyyy: hh:mm:ss . ";
                return false;
                }

            message=null;
            return true;
                                                   
         }


    }
}
