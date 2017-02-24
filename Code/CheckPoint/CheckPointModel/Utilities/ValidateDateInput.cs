using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointModel.Utilities
{
    public static class ValidateDateInput
    {
        public static bool IsDateValidate(string date)
        {
            DateTime Date;

            if (!DateTime.TryParse(Convert.ToString(date), out Date))
            {
                return false;
            }
            return true;
        }
    }
}
