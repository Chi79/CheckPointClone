using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderCommon.SerialProtocolInterfaces
{
    public interface ISerialProtocol
    {

        event EventHandler<ISerialEventArgs> SerialPackage;
        bool IsConnected();
        void Connect();

        void Disconnect();

        //bool Send(byte[] data);

    }
}
