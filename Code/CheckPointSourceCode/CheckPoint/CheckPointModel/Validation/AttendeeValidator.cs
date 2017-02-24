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
            string errorMessage=null;         

            if (!ValidateIntergerInput.IsIntergerValid(attendee.AppointmentId))
                base.AddBrokenRule("AppointmentId is not valid");                       

            if(!ValidateStringInput.IsStringValid(attendee.TagId))
                base.AddBrokenRule("TagId Is not valid");

            if (!Enum.IsDefined(typeof(AttendeeStatus), attendee.StatusId))
                base.AddBrokenRule("StatusId is not valid");

            if (!ValidateStringInput.IsStringValid(attendee.TagId))
                base.AddBrokenRule("TagId is not valid");

            if (!(ValidateTimeAttended(attendee.TimeAttended, attendee.StatusId, ref errorMessage)))
                base.AddBrokenRule("TimeAttended is not valid:  "+errorMessage);
        }

        public bool ValidateTimeAttended(string timeAttended, int statusId, ref string message)
        {       
            if (!(statusId == (int)AttendeeStatus.ObligHasAttended || statusId == (int)AttendeeStatus.HasAttended))
            {
                message = "Status is not "+ AttendeeStatus.HasAttended.ToString()+" or "+AttendeeStatus.ObligHasAttended.ToString();                
                return false;
            }

            if(!ValidateStringInput.IsStringValid(timeAttended))
            {
                message = "Field is empty "; ;
                return false;
            }

            if (!ValidateDateInput.IsDateValidate(timeAttended))            
                {
                message = "Dates must be in correct format mm/dd/yyyy: hh:mm:ss . ";
                return false;
                }

            return true;
                                                   
         }


    }
}
