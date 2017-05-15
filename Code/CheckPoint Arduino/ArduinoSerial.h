/*
 * This class will handle everything related to the data transfer between the Arduino unit and the PC client. A similar class is also written for C#
 * to allow easy and safe serial communication between the two. They are defined with the same protocols and structure, so it is highly reccomended 
 * they be used together. This is coded for serial communication via USB, but can be modified to work within a wireless setup. 
 */

#pragma once
#include <Arduino.h>
#define PACKAGE_SIZE 128
#define HEADER_SIZE 6
#define MAX_DATA_SIZE (PACKAGE_SIZE - HEADER_SIZE)
/*
 * The Arduino UNO has a serial receive buffer capable of storing 64 bytes, so this will be our largest possible PACKAGE_SIZE.
 * Our package will contain some overhead in order to deal with broken packages, so this equals to our HEADER_SIZE.
 * We then take the difference between these two and get our maximum payload size, defined by MAX_DATA_SIZE.
 */

enum arduino_control_t 
{
  A_CTRL_NULL,
  A_CTRL_SYNC = 0x5f5f, //sync byte value
  A_CTRL_END = 0xffff  //end byte value

/*
 * The SYNC and END are arbitrary 16bit values used to distinguish the start and
 * end of a valid package. They are 16bit in order to separate them from ordinary 8 bit values in the payload.
 * Formatted in hex for readability.
 * 
 *  /// A PurpleSerialPackage must have the following structure:
 *  /// 
 *  /// P_CTRL_SYNC        2 bytes             : 0x5f5f
 *  /// length             1 byte             : length of payload in bytes (x)
 *  /// payload            x bytes            : payload
 *  /// P_CTRL_END         2 bytes             : 0xffff
 *           
 */
};

class ArduinoSerialPackage 
{
  //Variables used to build a package
  bool _prevLen;
  uint8_t _udIdx;
  arduino_control_t _sync, _end;
  uint16_t _tmp;

public:
  //Payload variables
  uint8_t length;
  uint8_t data[MAX_DATA_SIZE];

  //Constructor
  ArduinoSerialPackage() 
  {
    Empty();
  }
  
  //This returns true if the package contains both SYNC and END
  bool IsComplete() 
  {
    if (_sync == A_CTRL_SYNC && _end == A_CTRL_END) {return true;}
    else {return false;}
  }
  //This resets the package, and gets called after isComplete returns true and the payload is delivered.
  void Empty() 
  {
    length = 0;
    _udIdx = 0;
    _tmp = 0;
    _sync = A_CTRL_NULL;
    _end = A_CTRL_NULL;
    _prevLen = false;
  }
  //This attempts to find the SYNC in the received data
  bool FindSync(uint8_t & idx, uint8_t * data, const size_t size) 
  {
    if (_sync) {return true;}
    
    while (idx < size)
    {
      if ((arduino_control_t)_tmp == A_CTRL_SYNC) //FOUND SYNC!
      {
        _sync = A_CTRL_SYNC;
        return true;
      }
      else {_tmp = (_tmp << 8) | data[idx++];}
      //This shifts the least significant byte in _tmp to the most significant byte, 
      //then reads the next byte in to LSB of tmp. This gets repeated until the 2 bytes in tmp equals SYNC.
    }
    return false;
  }
  void ReadUntilEnd(uint8_t & idx, uint8_t *data, const size_t size) 
  {
    //Index may already be equal to size. index must be checked each time it is increased outside of a loop here. 
    if (idx >= size) {return;}    //Fragmented package!
    if (!_prevLen) 
    {
      length = (uint8_t)data[idx++];    //Next byte should contain datalength when we're in SYNC.
      _prevLen = true;    //Need a bool here because len can be 0. 
      _tmp = 0;   //_tmp was used in FindSync() and needs to be used again here, so it must be cleared.
    }
    if (idx >= size) {return;}      //Fragmented package!

    //Read the rest until END is found. This part may also come in broken up bits, but that'll be handled here too :)
    while (idx < size && _end != A_CTRL_END) 
    {
      if (_udIdx < length) {this->data[_udIdx++] = data[idx++];}
      else if (!_tmp) {_tmp = data[idx++];}
      else {_end = (arduino_control_t)((_tmp << 8) | data[idx++]);}
    }
  }
};

#ifdef Arduino_h
typedef void(*SerialCallback)(uint8_t *buf, uint8_t len); //Callback function

class ArduinoSerial 
{
  Stream *_serial;
  SerialCallback _callback;
  ArduinoSerialPackage _pckg;

  uint8_t _sync[2];   //Will hold SYNC bytes
  uint8_t _end[2];    //Will hold END bytes
  uint8_t _rxbuf[MAX_DATA_SIZE];  //Will hold payload
public:
  ArduinoSerial(Stream *serial, SerialCallback callback, uint32_t baudrate);                                       
  void HandleSerialInput();
  uint16_t Send(uint8_t *buf, uint8_t len);
};
#endif


















































