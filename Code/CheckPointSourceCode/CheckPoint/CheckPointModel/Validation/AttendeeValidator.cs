using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointModel.Entities;
using CheckPointModel.Utilities;
namespace CheckPointModel.Validation
{
    public class AttendeeValidator:Validator<AttendeeModel>
    {
        private List<object> PropertyList;

        public List<object> FillPropertyList(AttendeeModel attendee)
        {
            PropertyList = new List<object>();

            PropertyList.Add(attendee.AppointmentId);
            PropertyList.Add(attendee.PersonalNote);
            PropertyList.Add(attendee.StatusId);
            PropertyList.Add(attendee.TagId);
            PropertyList.Add(attendee.TimeAttended);

            return PropertyList;

        }
        public override void CheckForBrokenRules(AttendeeModel attendee)
        {            
            if (!ValidateIntergerInput.IsIntergerValid(attendee.AppointmentId))
                base.AddBrokenRule("AppointmentId is not valid");                       

            if(!ValidateStringInput.IsStringValid(attendee.TagId))
                base.AddBrokenRule("TagId Is not valid!");

        }

        private bool ValidateStatusId(int statusId)
        {
            return true;
        }
    }
}
