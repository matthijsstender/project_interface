// MPU 6050   --->   Arduino 
//
//  VCC   ----->   3.3v
//  GND   ----->   GND
//  SCL   ----->   A5 pin
//  SDA   ----->   A4 pin


#include<Wire.h>

const int MPU=0x68;  // I2C address of the MPU-6050
int16_t AcX,AcY,AcZ,Tmp,GyX,GyY,GyZ;

const int buttonPin = 11;     // the number of the pushbutton pin

int buttonState = 0;         // variable for reading the pushbutton status

int buttonOffOn = 0;
bool buttonDown;

void setup(){
 
  // initialize the pushbutton pin as an input:
  pinMode(buttonPin, INPUT);

  Wire.begin();
  Wire.beginTransmission(MPU);
  Wire.write(0x6B);  // PWR_MGMT_1 register
  Wire.write(0);     // set to zero (wakes up the MPU-6050)
  Wire.endTransmission(true);
  Serial.begin(9600);
}


void loop(){

   // read the state of the pushbutton value:
  buttonState = digitalRead(buttonPin);

  // check if the pushbutton is pressed.
  // if it is, the buttonState is HIGH:
  if (buttonState == HIGH && buttonDown == false) {

    buttonDown = true;
    buttonOffOn = 1;
  } 
  else if(buttonState == LOW && buttonDown == true) {

    buttonDown = false;
    buttonOffOn = 0;
  }else{
    buttonOffOn = 0;
  }

  Wire.beginTransmission(MPU);
  Wire.write(0x3B);  // starting with register 0x3B (ACCEL_XOUT_H)
  Wire.endTransmission(false);
  Wire.requestFrom(MPU,14,true);  // request a total of 14 registers
  AcX=Wire.read()<<8|Wire.read();  // 0x3B (ACCEL_XOUT_H) & 0x3C (ACCEL_XOUT_L)
  Tmp=Wire.read()<<8|Wire.read();  // 0x41 (TEMP_OUT_H) & 0x42 (TEMP_OUT_L)
  GyY=Wire.read()<<8|Wire.read();  // 0x45 (GYRO_YOUT_H) & 0x46 (GYRO_YOUT_L)

 
  Serial.print(AcX); Serial.print(","); Serial.print(GyY); Serial.print(",");
  Serial.print(buttonOffOn); Serial.println("");
  Serial.flush();


  delay(25);
}
