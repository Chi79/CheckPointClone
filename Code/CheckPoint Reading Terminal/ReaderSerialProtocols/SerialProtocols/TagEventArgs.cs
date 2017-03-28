using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReaderCommon.SerialProtocolInterfaces;

namespace ReaderSerialProtocols.SerialProtocols
{
    public class TagEventArgs : ISerialEventArgs
    {
        public byte[] Data { get; set; }
        public byte Length { get; set; }

    }
}
