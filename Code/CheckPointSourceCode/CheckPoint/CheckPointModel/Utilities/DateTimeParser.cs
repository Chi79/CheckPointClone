using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointModel.Utilities
{
    public static class DateTimeParser
    {
        public static DateTime ParseAppointmentData(string dateTimeData)
        {
          return DateTime.Parse(dateTimeData);      
        }


        // is not tested
        public static DateTime ParseTimeAttended(string timeAttended)
        {
                return DateTime.Parse(timeAttended);          
        }
    }
}
