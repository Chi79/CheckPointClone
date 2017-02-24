using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointModel.Entities;
using CheckPointModel.Utilities;
using CheckPointCommon.Enums;
namespace CheckPointModel.Validation
{
    public class AttendeeValidator:Validator<AttendeeModel>
    {
        //not tested

        /// <summary>
        /// Checks the AttendeeModel for Broken Business Rules
        /// </summary>
        /// <param name="attendee"></param>
        public override void CheckForBrokenRules(AttendeeModel attendee)
        {            
            if (!ValidateIntergerInput.IsIntergerValid(attendee.AppointmentId))
                base.AddBrokenRule("AppointmentId is not valid");                       

            if(!ValidateStringInput.IsStringValid(attendee.TagId))
                base.AddBrokenRule("TagId Is not valid");

            if (!Enum.IsDefined(typeof(AttendeeStatus), attendee.StatusId))
                base.AddBrokenRule("StatusId is not valid");

            if (!ValidateStringInput.IsStringValid(attendee.TagId))
                base.AddBrokenRule("TagId is not valid");

            if (!(ValidateTimeAttended(attendee.TimeAttended, attendee.StatusId)))
                base.AddBrokenRule("TimeAttended is not Valid");
        }

        private bool ValidateTimeAttended(string timeAttended, int statusId)
        {       
            if (!(statusId == (int)AttendeeStatus.ObligHasAttended || statusId == (int)AttendeeStatus.HasAttended))
            {
                return false;
            }

            if(!ValidateStringInput.IsStringValid(timeAttended))
            {
                return false;
            }

            if (!ValidateDateInput.IsDateValidate(timeAttended))            
                {
                return false;
                }

            return true;
                                                   
         }


    }
}
