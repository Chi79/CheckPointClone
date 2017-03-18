using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.DTOInterfaces
{
    public interface IAttendeeDTO
    {
       int AppointmentId { get; set; }
       string PersonalNote { get; set; } //Shall be nullable
       string TimeAttended { get; set; } //Shall be nullable but not when statuId is 3 or 4
       int StatusId { get; set; }
       string TagId { get; set; }
    }
}
