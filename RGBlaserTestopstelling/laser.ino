//Definiering van de pinnen aangesloten op de laser, dit zijn PWM poorten voor het dimmen
const int red = 3;
const int green = 5;
const int blue = 6;

const int buttonWhite = 8;
const int buttonRed = 9;

//De variablen voor het bijhouden van de verschillende kleuren en dimwaarden
char receivedChar;
String receivedString;

int color;
int dimFactor;


void setup() {
  //pinnen instellen als INPUT OF OUTPUT
  pinMode(red, OUTPUT);
  pinMode(green, OUTPUT);
  pinMode(blue, OUTPUT);

  pinMode(buttonWhite, INPUT);
  pinMode(buttonRed, INPUT);

  //serial port openen voor communicatie met de PC
  Serial.begin(9600);
}

void loop() {

  //wanneer er een bericht binnenkomt, lees het hele bericht
  //en zet het in de int color
  if (Serial.available() > 0) {
    color = Serial.read();
  }

  //lees allebei de knoppen uit
  bool buttonStateRed = digitalRead(buttonRed);
  bool buttonStateWhite = digitalRead(buttonWhite);

  //als de verhoog knop wordt ingedrukt, verhoog de dimFactor
  if(buttonStateRed == HIGH && dimFactor < 255){
    dimFactor++;
    delay(10);
    Serial.println(dimFactor);
  }
  //als de verlaag knop wordt ingedrukt, verlaag de dimFactor
  if(buttonStateWhite == HIGH && dimFactor > 0){
    dimFactor--;
    delay(10);
    Serial.println(dimFactor);
  }

  //lees het seriële bericht in color
  //en stel aan de hand daarvan de kleur in, bij de juiste dimFactor
  switch (color) {
    case '1':
      analogWrite(red, dimFactor);
      analogWrite(green, 0);
      analogWrite(blue, 0);
      break;
    case '2':
      analogWrite(red, 0);
      analogWrite(green, dimFactor);
      analogWrite(blue, 0);
      break;
    case '3':
      analogWrite(red, 0);
      analogWrite(green, 0);
      analogWrite(blue, dimFactor);
      break;
    case '4':
      analogWrite(red, dimFactor);
      analogWrite(green, dimFactor);
      analogWrite(blue, 0);
      break;
    case '5':
      analogWrite(red, dimFactor);
      analogWrite(green, 0);
      analogWrite(blue, dimFactor);
      break;
    case '6':
      analogWrite(red, 0);
      analogWrite(green, dimFactor);
      analogWrite(blue, dimFactor);
      break;
    case '7':
      analogWrite(red, dimFactor);
      analogWrite(green, dimFactor);
      analogWrite(blue, dimFactor);
      break;
    default:
      analogWrite(red, 0);
      analogWrite(green, 0);
      analogWrite(blue, 0);
    break;
  }
}
