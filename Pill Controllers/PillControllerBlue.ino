#include <Keyboard.h>

//Bluepill controller for russian bodybuilding game
//Bluepill goes to player 2, therefore presses keyboard keys R for activation and E for muscleFlex
//Average unpressed values are 55 and 115
//Average pressed values are 5 and 10

int Mat;
int Blue1;
int Blue2;
int BlueTotal;

void setup() {
  Serial.begin(9600);
  Keyboard.begin();
}

void loop() {
  //collect values
  Mat = analogRead(A0);
  Blue1 = analogRead(A1);
  Blue2 = analogRead(A2);
  BlueTotal = Blue1+Blue2;

  if(Mat > 5){
    Keyboard.write('r');
  }

  if(BlueTotal <= 70 && BlueTotal >= 20){
    Keyboard.write('e');
  }
  else if(BlueTotal <= 19 && BlueTotal >= 0){
    Keyboard.write('e');
    Keyboard.write('e');//aint got no time for a for loop lol
  }
  else{
    ;
  }

  

}
