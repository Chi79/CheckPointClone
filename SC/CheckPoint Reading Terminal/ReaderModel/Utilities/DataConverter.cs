using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderModel.Utilities
{
    public class DataConverter
    {
        public static string HexToString(byte[] data)
        {
            return BitConverter.ToString(data).Replace("-", string.Empty); //removes the dashes in the hex formatting and returns it as a string

        }

        public static byte[] StringToHex(string data)
        {
            return Encoding.ASCII.GetBytes(data);
        }

    }
}
