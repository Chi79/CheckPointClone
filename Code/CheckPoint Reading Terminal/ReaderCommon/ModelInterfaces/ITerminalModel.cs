using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderCommon.ModelInterfaces
{
    public interface ITerminalModel
    {
        IEnumerable<byte> FormatSerialData(byte[] data, byte length);
        string ConvertSerialDataIntoString(byte[] data);
        byte[] ConvertStringIntoSerialData(string data);
    }
}
