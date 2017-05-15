/*
 * This class will handle everything related to the data transfer between the Arduino unit and the PC client. A similar class is also written for C#
 * to allow easy and safe serial communication between the two. They are defined with the same protocols and structure, so it is highly reccomended 
 * they be used together. This is coded for serial communication via USB, but can be modified to work within a wireless setup. 
 */

#include "ArduinoSerial.h"

#ifdef Arduino_h
//Constructor
ArduinoSerial::ArduinoSerial(Stream *serial, SerialCallback callback, uint32_t baudrate) :_serial(serial), _callback(callback) 
{
  ((HardwareSerial*)_serial)->begin(baudrate); //Sets baudrate and initiates .begin();
  _sync[0] = (uint8_t)(A_CTRL_SYNC >> 8);
  _sync[1] = (uint8_t)(A_CTRL_SYNC);
  _end[0]  = (uint8_t)(A_CTRL_END >> 8);
  _end[1]  = (uint8_t)(A_CTRL_END);
}
void ArduinoSerial::HandleSerialInput() 
{
  //Check if there is available data in the receive buffer
  if (!(_serial->available() > 0)) {return;} 
  //Get the amount of data waiting
  uint8_t len = _serial->available();
  //Store the data from the receive buffer into our own data buffer
  for (uint8_t i = 0; i < len; i++) 
  {
    _rxbuf[i] = (uint8_t)_serial->read();
  }
  
  uint8_t idx = 0;
  //Finding SYNC
  while (_pckg.FindSync(idx, _rxbuf, len))
  {
    _pckg.ReadUntilEnd(idx,_rxbuf,len);
    if (!_pckg.IsComplete()) {return;}

    //Package is complete, deliver data. 
    _callback(_pckg.data, _pckg.length);

    //Callback has returned, time to make ready for the next transmission. 
    _pckg.Empty();
  }
}
uint16_t ArduinoSerial::Send(uint8_t *buf, uint8_t len) 
{
  uint16_t writtenBytes = 0;
  
  writtenBytes += _serial->write(_sync, 2); //Sending SYNC bytes
  writtenBytes += _serial->write(len);      //Sending length of payload
  writtenBytes += _serial->write(buf, len); //Sending payload
  writtenBytes += _serial->write(_end, 2);  //Sending END bytes
  
  _serial->flush();
  return writtenBytes;
}
#endif


