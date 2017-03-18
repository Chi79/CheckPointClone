using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointModel.Utilities
{
    public static class DateTimeToLocalTimeConverter
    {
        public static DateTime ConvertDateToTime(DateTime dateTimeData)
        {
            return dateTimeData.ToLocalTime();
        }
    }
}
