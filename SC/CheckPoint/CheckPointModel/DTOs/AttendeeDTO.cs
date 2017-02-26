using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointModel.Validation;

namespace CheckPointModel.DTOs
{
    public class AttendeeDTO: AttendeeValidator
    {       
        //Not tested

        public int AppointmentId { get; set; }
        public string PersonalNote { get; set; } //Shall be nullable
        public string TimeAttended { get; set; } //Shall be nullable but not when statuId is 3 or 4
        public int StatusId { get; set; }
        public string TagId { get; set; }

        public override void CheckForBrokenRules(AttendeeDTO entity)
        {
            base.CheckForBrokenRules(this);
        }


    }
}
