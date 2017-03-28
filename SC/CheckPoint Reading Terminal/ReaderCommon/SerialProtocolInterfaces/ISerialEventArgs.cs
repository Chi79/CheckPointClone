using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderCommon.SerialProtocolInterfaces
{
    public interface ISerialEventArgs
    {
        byte[] Data { get; set; }
        byte Length { get; set; }
    }
}
