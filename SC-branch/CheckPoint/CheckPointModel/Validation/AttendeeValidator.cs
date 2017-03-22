using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointModel.Utilities;
using CheckPointCommon.Enums;
using CheckPointCommon.ValidationInterfaces;
using CheckPointCommon.DTOInterfaces;

namespace CheckPointModel.Validation
{
    public class AttendeeValidator:Validator<IAttendeeDTO>,IAttendeeValidator<IAttendeeDTO>
    {
        //this class is not tested

        /// <summary>
        /// Checks the AttendeeModel for Broken Business Rules
        /// </summary>
        /// <param name="attendee"></param>
        public override void CheckForBrokenRules(IAttendeeDTO attendee)
        {        

            if (!ValidateIntergerInput.IsIntergerValid(attendee.AppointmentId))
            {
                base.AddBrokenRule("AppointmentId is not valid");
            }
            if(!ValidateStringInput.IsStringValid(attendee.TagId))
            {
                base.AddBrokenRule("TagId field is empty");
            }
            if (!Enum.IsDefined(typeof(AttendeeStatus), attendee.StatusId))
            {
                base.AddBrokenRule("StatusId is not valid");
            }
            if (!ValidateStringInput.IsStringValid(attendee.TimeAttended)) //if false & TimeAttended is null/empty..
            {
                ValidateTimeAttendedIsEmpty(attendee); 
            }
            if (ValidateStringInput.IsStringValid(attendee.TimeAttended)) //if false & TimeAttended is not null..
            {
                ValidateTimeAttendedIsFilled(attendee);
            }
        }

        public void ValidateTimeAttendedIsEmpty(IAttendeeDTO attendee)
        {
            if (attendee.StatusId == (int)AttendeeStatus.ObligHasAttended)   //if attended is true, TimeAttended cannot be null
            {
                base.AddBrokenRule("Time attended field cannot be empty if an obligatory appointment has been attended!");
            }
            if (attendee.StatusId == (int)AttendeeStatus.HasAttended)
            {
                base.AddBrokenRule("Time attended field cannot be empty if an appointment has been attended!");
            }
        }

        public void ValidateTimeAttendedIsFilled(IAttendeeDTO attendee)
        {
            if (attendee.StatusId != (int)AttendeeStatus.HasAttended || attendee.StatusId != (int)AttendeeStatus.ObligHasAttended)
            {
                base.AddBrokenRule("Time attended field cannot contain data before the appointment has been attended.");
            }
            if (!ValidateDateInput.IsDateValidate(attendee.TimeAttended))
            {
                base.AddBrokenRule("All dates and times must be in correct format mm/dd/yyyy: hh:mm:ss . ");
            }
        }
    }
}
