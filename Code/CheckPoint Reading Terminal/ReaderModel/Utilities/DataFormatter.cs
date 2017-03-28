using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderModel.Utilities
{
    public class DataFormatter
    {
        public static IEnumerable<byte> TrimSerialData(byte[] data, byte length)
        {
            byte[] trimmedData = new byte[length];
            for (int i = 0; i < length; i++)
            {
                trimmedData[i] = data[i];
            }

            return trimmedData;
        }

    }
}
