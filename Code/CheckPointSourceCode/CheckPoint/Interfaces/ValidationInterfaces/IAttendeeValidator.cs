using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CheckPointCommon.ValidationInterfaces
{
   public interface IAttendeeValidator<T>:IValidator<T> where T:class
    {
        //ToDO
        bool ValidateTimeAttended(T attendee, out string message);
    }
}
