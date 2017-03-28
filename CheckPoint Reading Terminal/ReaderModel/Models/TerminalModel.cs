using ReaderCommon.ModelInterfaces;
using ReaderModel.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderModel.Models
{
    public class TerminalModel : ITerminalModel
    {
        public IEnumerable<byte> FormatSerialData(byte[] data, byte length)
        {
            return DataFormatter.TrimSerialData(data, length);
        }

        public string ConvertSerialDataIntoString(byte[] data)
        {
            return DataConverter.HexToString(data);
        }

        public byte[] ConvertStringIntoSerialData(string data)
        {
            return DataConverter.StringToHex(data);
        }


    }
}
