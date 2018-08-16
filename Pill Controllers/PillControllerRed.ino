#include <Keyboard.h>

//Redpill controller for russian bodybuilding game
//Redpill goes to player 1, therefore presses keyboard keys W for activation and Q for muscleFlex
//Average unpressed values are 60 and 70
//Average pressed values are 5 and 10

int Mat;
int Red1;
int Red2;
int RedTotal;

void setup() {
  Serial.begin(9600);
  Keyboard.begin();
}

void loop() {
  //collect values
  Mat = analogRead(A0);
  Red1 = analogRead(A1);
  Red2 = analogRead(A2);
  RedTotal = Red1+Red2;

  if(Mat > 5){
    Keyboard.write('w');
  }


  if(RedTotal <= 50 && RedTotal >= 10){
    Keyboard.write('q');
  }
  else if(RedTotal <= 9 && RedTotal >= 0){
    Keyboard.write('q');
    Keyboard.write('q');
  }
  else{
    ;
  }
}
