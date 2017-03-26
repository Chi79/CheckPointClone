using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using ReaderCommon.SerialProtocolInterfaces;
using System.Text.RegularExpressions;
using System.Management;

namespace ReaderSerialProtocols.SerialProtocols
{
    /*
     Communication protocol class for data transfer between C# and arduino written by Kevin Brueland (2017). A similar class and definitions is found on the arduino.

         */
    public enum ArduinoSerialCommand : byte
    {

        REGISTRATION_FAILED = 50,
        REGISTRATION_SUCCESS,


    }
    public class ArduinoSerialProtocol : ISerialProtocol
    {
        private const byte PACKAGE_SIZE = 64;
        private const byte HEADER_SIZE = 6;
        private const byte MAX_DATA_SIZE = PACKAGE_SIZE - HEADER_SIZE;


        /// <summary>
        /// The Arduino UNO has a serial receive buffer capable of storing 64 bytes, so this will be our largest possible PACKAGE_SIZE.
        /// Our package will contain some overhead in order to deal with broken packages, so this equals to our HEADER_SIZE.
        /// We then take the difference between these two and get our maximum payload size, defined by MAX_DATA_SIZE.
        /// </summary>

        private enum ArduinoSerialControl : ushort
        {
            NULL = 0x0000,
            SYNC = 0x5f5f,
            END = 0xffff

            ///<summary>
            ///The SYNC and END are arbitrary 16bit values used to distinguish the start and
            ///end of a valid package. They are 16bit in order to separate them from ordinary 8 bit values in the payload.
            ///Formatted in hex for readability.
            /// </summary>

        }

        /// <summary>
        /// A ArduinoSerialPackage must have the following structure:
        /// 
        /// SYNC                2 bytes             : 0x5f5f
        /// length              1 byte              : length of payload in bytes (x)
        /// payload             x bytes             : payload
        /// END                 2 bytes             : 0xffff
        /// 
        /// </summary>

        public class ArduinoSerialPackage
        {
            //Variables used to build a package
            private bool _fragmentedPackage;
            private byte _dataIdxPos;
            private ArduinoSerialControl _sync, _end;
            private ushort _tmp;

            //Payload variables
            private byte[] _data;
            private byte _length;


            /// <summary>
            /// Constructor
            /// </summary>
            public ArduinoSerialPackage()
            {
                _data = new byte[MAX_DATA_SIZE];
                Clear();
            }

            /// <summary>
            /// This resets the package, and gets called after isComplete returns true and the payload is delivered.
            /// </summary>
            public void Clear()
            {
                _length = 0;
                _dataIdxPos = 0;
                _tmp = 0;
                _sync = ArduinoSerialControl.NULL;
                _end = ArduinoSerialControl.NULL;
                _fragmentedPackage = false;


            }

            /// <summary>
            /// This returns true if the package contains both SYNC and END
            /// </summary>
            public bool IsComplete()
            {
                return _sync == ArduinoSerialControl.SYNC && _end == ArduinoSerialControl.END;
            }

            /// <summary>
            /// Attempts to find SYNC in the data received 
            /// </summary>
            /// <param name="idx">By reference so that the same idx variable can be used for the rest of the package</param>
            /// <param name="data"> By reference so that the same byte array can be used for the rest of the package</param>
            /// <param name="size"> Length of data to parse</param>
            /// <returns>True if sync is found, false otherwise</returns>
            public bool Sync(ref byte idx, ref byte[] data, uint size)
            {
                //If the package is fragmented, we may already have SYNC.
                if (_sync == ArduinoSerialControl.SYNC) return true;

                while (idx < size)
                {
                    if ((ArduinoSerialControl)_tmp == ArduinoSerialControl.SYNC) //Checking to see if the byteshifted temporary value equals our SYNC
                    {
                        _sync = ArduinoSerialControl.SYNC;    //We've found SYNC!
                        return true;
                    }

                    //A SYNC is 2 bytes, so here we shift the rightmost byte 1 byte to the left, and add the next byte. The search for SYNC continues.
                    _tmp = (ushort)((_tmp << 8) | data[idx++]);
                }

                //Did not find SYNC in this package. It might be fragmented or corrupt.
                return false;
            }

            /// <summary>
            /// Parse the rest of the bytes received, until END control is found.
            /// </summary>
            /// <param name="idx">By ref, the same idx used for Sync()</param>
            /// <param name="data">By ref, the same data buffer used for Sync()</param>
            /// <param name="size">Length of buffer to parse, same as used for Sync()</param>
            public void ReadDataUntilEnd(ref byte idx, ref byte[] data, uint size)
            {
                //No END found in buffer. Fragmented?
                if (idx >= size) return;

                //Fragmented?
                if (!_fragmentedPackage)
                {
                    _length = data[idx++];

                    //Assumes this package is fragmented if END is found before 
                    //returning from this method. If that is the case, this variable will never be used.
                    _fragmentedPackage = true;

                    //Reset _tmp variable, as we need to do some byteshifting on it again to find END
                    _tmp = 0;
                }

                //Check fragmentation again
                if (idx >= size) { return; }

                //Read the rest, until END is found. This part may also come in broken up bits, but that'll be handled here too :)
                while (idx < size && _end != ArduinoSerialControl.END)
                {
                    if (_dataIdxPos < _length) { _data[_dataIdxPos++] = data[idx++]; }
                    else if (_tmp == 0) { _tmp = data[idx++]; }
                    else { _end = (ArduinoSerialControl)((_tmp << 8) | data[idx++]); }
                }
            }

            /// <summary>
            /// Data in payload
            /// </summary>
            public byte[] Data { get { return _data; } }

            public byte Length { get { return _length; } }
        }


        //Events & eventdelegates
        /// <summary>
        /// Called whenever a complete package has been received.
        /// </summary>
        /// <param name="data">Data in payload</param>
        public event EventHandler<ISerialEventArgs> SerialPackage;
        //Serial Port
        private SerialPort _comPort;


        //Buffers
        private byte[] _sync;
        private byte[] _end;
        private byte[] _ibuf;
        private ArduinoSerialPackage _package;



        /// <summary>
        /// Constructor
        /// </summary>
        public ArduinoSerialProtocol()
        {
            //Initialize buffers
            _sync = new byte[2];
            _sync[0] = (ushort)ArduinoSerialControl.SYNC >> 8; // MSB
            _sync[1] = (ushort)ArduinoSerialControl.SYNC & 0xff; // LSB

            _end = new byte[2];
            _end[0] = (ushort)ArduinoSerialControl.END >> 8;
            _end[1] = (ushort)ArduinoSerialControl.END & 0xff;

            _ibuf = new byte[MAX_DATA_SIZE * 2]; //This is times two, in case Arduino decides to send two packages in succession
            _package = new ArduinoSerialPackage();


            //Initialize SerialPort
            _comPort = new SerialPort();
            _comPort.ReadTimeout = 500;
            _comPort.WriteTimeout = 500;
            _comPort.Parity = Parity.None;
            _comPort.StopBits = StopBits.One;
            _comPort.DtrEnable = false;  // enabling DTR will cause the arduino to restart when a serial is opened. This is unwanted behaviour. 
            _comPort.ReceivedBytesThreshold = 1;
            _comPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler); //We are lazy, so we let someone else be on the lookout for received data :)

        }


        /// <summary>
        /// Query windows for available Serial devices
        /// </summary>
        /// <returns>An array of available devices in strings</returns>
        public string[] GetAvailablePorts()
        {
            return SerialPort.GetPortNames();
        }

        /// <summary>
        /// Connects to the given device with the specifiec baudrate
        /// </summary>
        /// <param name="comport">Device's Com port</param>
        /// <param name="baudrate">Baudrate must be same as the device uses</param>
        /// <returns></returns>
        public void Connect()
        {
            if(IsConnected())
            {
                _comPort.PortName = GetComPort();
                _comPort.BaudRate = 9600;
                _comPort.Open();
            }
        }

        /// <summary>
        /// Disconnects from previously connected device.
        /// </summary>
        public void Disconnect()
        {
            if (_comPort.IsOpen) _comPort.Close();
        }

        /// <summary>
        /// Automatically detects if there is an arduino unit connected to computer, which port it is connected to,
        /// and then connects it.
        /// 
        /// </summary>
        /// <returns>Returns communication port name</returns>
        public bool IsConnected()
        {
            if(GetComPort() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetComPort()
        {
            ManagementObjectSearcher portSearcher = new ManagementObjectSearcher("root\\CIMV2",
           "SELECT * FROM Win32_PnPEntity");
            try
            {
                foreach (ManagementObject queryObj in portSearcher.Get())
                {
                    if (queryObj["Caption"].ToString().Contains("Arduino"))
                    {

                        string _arduinoPort = queryObj["Name"].ToString(); //Gets the friendly name (Arduino Uno (COM#)
                        _arduinoPort = Regex.Match(_arduinoPort, @"\(([^)]*)\)").Groups[1].Value; //Extracts in COM# format, bit messy mesa knows.
                        return _arduinoPort;
                        
                    }

                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }




        /// <summary>
        /// Transmit a buffer of bytes to the connected device.
        /// </summary>
        /// <param name="data">Buffer of bytes containing just the payload</param>
        /// <param name="length">Length of the buffer (in bytes)</param>
        /// <returns></returns>
        public bool Send(byte[] data)
        {
            if (!_comPort.IsOpen) return false;

            byte[] lbuf = new byte[1] { (byte)data.Length };

            _comPort.Write(_sync, 0, 2);            //Sending SYNC bytes
            _comPort.Write(lbuf, 0, 1);             //Sending the length of our payload
            _comPort.Write(data, 0, data.Length);   //Sending the payload
            _comPort.Write(_end, 0, 2);             //Sending END bytes

            return true;
        }


        //Event handler for the serialcom connection
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs args)
        {
            SerialPort sp = (SerialPort)sender;
            try
            {
                //Read data in the Serial receive buffer.
                int len = sp.Read(_ibuf, 0, MAX_DATA_SIZE * 2);
                sp.DiscardInBuffer();
                byte idx = 0;

                //Handle data in a while loop, because Arduino might have sent two or more packages in succession 
                while (_package.Sync(ref idx, ref _ibuf, (uint)len)) //First we locate SYNC
                {
                    _package.ReadDataUntilEnd(ref idx, ref _ibuf, (uint)len); //Then we read the payload into our buffer all the way to END


                    if (!_package.IsComplete()) { return; }

                    //Raise the event and forward our payload
                    if(SerialPackage != null)
                    {
                        SerialPackage(this, (new TagEventArgs { Data = _package.Data, Length = _package.Length }));
                    }
                    

                    //SerialPackage =>  _package.Data _package.Length);

                    //Clear our package.
                    _package.Clear();
                }
            }
            catch (TimeoutException) //This is the only plausible exception in this case
            {
                //Do something??
            }
        }
    }
}
