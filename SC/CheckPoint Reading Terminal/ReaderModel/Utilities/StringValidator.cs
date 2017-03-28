using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderModel.Utilities
{
    static class StringValidator
    {
        public static bool isStringValid(string data)
        {
            if(string.IsNullOrWhiteSpace(data))
            {
                return false;
            }
            return true;
        }

        public static bool AreStringsValid(List<string> data)
        {
            foreach(string s in data)
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
