using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointModel.Utilities
{
    public static class ValidateStringInput
    {
        public static bool IsStringValid(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }
            return true;
        }
        public static bool AreStringsValid(List<string> list)
        {
           // return list.Any(s => string.IsNullOrEmpty(s));  
            foreach (string s in list)
            {
                if (string.IsNullOrWhiteSpace(s))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
