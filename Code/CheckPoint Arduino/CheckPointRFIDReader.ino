#include "ArduinoSerial.h"
#include "MFRC522.h"
#include "SPI.h"


//Instantiate objects
#define SS_PIN 10
#define RST_PIN 9

ArduinoSerial *aSerial;
MFRC522 rfidReader(SS_PIN, RST_PIN);

//Global variables
volatile bool isTagDetected = false; //Volatile variable called from RAM in conjunction with the motion sensor ISR

//ISR (Interrupt Service Routine) for the RFID reader
void ISRTagDetected() 
{
  isTagDetected = true; //Flips flag for tag detected.
}

//Callback function that processes incoming serial data
void aSerialCallback(uint8_t* buf, uint8_t len) 
{ 
  //handle received data here
}

void setup() {
  aSerial = new ArduinoSerial(&Serial, aSerialCallback, 9600);
  SPI.begin();           //initiate SPI bus
  rfidReader.PCD_Init(); //initiate RFID reader
  Serial.begin(9600);
  //Serial.println("Please scan you tag...");
}

void loop() {

  // Look for new cards
  if (rfidReader.PICC_IsNewCardPresent()) 
  {
    if (rfidReader.PICC_ReadCardSerial()) 
    {
      uint8_t _obuf[10];
      uint8_t _count = 0;
      for (byte i=0; i < rfidReader.uid.size; i++)
      {
        //Serial.print(rfidReader.uid.uidByte[i],HEX);
        
        _obuf[i] = rfidReader.uid.uidByte[i];
        _count++;   
      }
      //Serial.println();
      
      aSerial->Send(_obuf, _count);  
      delay(2000);   
    }
  }

}
