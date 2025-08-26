#include <AccelStepper.h>
#include <math.h>

// ---- Pins ----
#define STEP_PINX 2
#define DIR_PINX  3
#define STEP_PINY 4
#define DIR_PINY  5
#define STEP_PINZ 6
#define DIR_PINZ  7

#define HOME_SENSOR_PIN_X A1
#define HOME_SENSOR_PIN_Y A2
#define HOME_SENSOR_PIN_Z A3

#define HOME_TRIG_THRESH 100

// ---- Limits (mm) ----
#define LIMIT_X 140
#define LIMIT_Y 180
#define LIMIT_Z 180

// ---- Steps per mm ----
const float STEPS_PER_MM_X = 3200.0f / 8.0f; // 400
const float STEPS_PER_MM_Y =  800.0f / 8.0f; // 100
const float STEPS_PER_MM_Z = 3200.0f / 8.0f; // 400

// ---- Max speed/accel at 100% (steps/s) ----
const float MAX_SPEED_X = 10000;
const float MAX_SPEED_Y =  2500;
const float MAX_SPEED_Z =  7000;
const float MAX_ACCEL_X = 20000;
const float MAX_ACCEL_Y = 20000;
const float MAX_ACCEL_Z = 20000;

// ---- Steppers ----
AccelStepper stepperX(AccelStepper::DRIVER, STEP_PINX, DIR_PINX);
AccelStepper stepperY(AccelStepper::DRIVER, STEP_PINY, DIR_PINY);
AccelStepper stepperZ(AccelStepper::DRIVER, STEP_PINZ, DIR_PINZ);

// ---- State (mm) ----
float posX = 0, posY = 0, posZ = 0; // vị trí hiện tại theo mm
int   speedPercent = 50;            // 0..100 mặc định 50%

// Teach memory 1..4
struct Pose { float x=0, y=0, z=0; bool taught=false; };
Pose taught[5]; // index 1..4

// ---- helpers ----
long mmToStepsX(float mm){ return lround(mm * STEPS_PER_MM_X); }
long mmToStepsY(float mm){ return lround(mm * STEPS_PER_MM_Y); }
long mmToStepsZ(float mm){ return lround(mm * STEPS_PER_MM_Z); }

float clampf(float v, float lo, float hi){ if(v<lo) return lo; if(v>hi) return hi; return v; }

volatile bool scanOn = false;    // trạng thái quét

int clampi(int v, int lo, int hi){ if(v<lo) return lo; if(v>hi) return hi; return v; }

void applySpeedPercent() {
  float s = clampf(speedPercent, 0, 100) / 100.0f;
  stepperX.setMaxSpeed(MAX_SPEED_X * s);
  stepperY.setMaxSpeed(MAX_SPEED_Y * s);
  stepperZ.setMaxSpeed(MAX_SPEED_Z * s);
  stepperX.setAcceleration(MAX_ACCEL_X * s);
  stepperY.setAcceleration(MAX_ACCEL_Y * s);
  stepperZ.setAcceleration(MAX_ACCEL_Z * s);
}

void runAll() {
  while ( stepperX.distanceToGo()!=0 || stepperY.distanceToGo()!=0 || stepperZ.distanceToGo()!=0 ) {
    stepperX.run(); stepperY.run(); stepperZ.run();
  }
}

void printPos() {
  Serial.print("POS X:"); Serial.print(posX,3);
  Serial.print(" Y:");    Serial.print(posY,3);
  Serial.print(" Z:");    Serial.println(posZ,3);
}

// ---- Commands ----
void cmdSPD(int p) {
  speedPercent = (int)clampf(p, 0, 100);
  applySpeedPercent();
  Serial.print("SPD "); Serial.println(speedPercent);
}

void cmdJOG(float dx, float dy, float dz) {
  float tx = clampf(posX + dx, 0, LIMIT_X);
  float ty = clampf(posY + dy, 0, LIMIT_Y);
  float tz = clampf(posZ + dz, 0, LIMIT_Z);

  stepperX.moveTo(mmToStepsX(tx));
  stepperY.moveTo(mmToStepsY(ty));
  stepperZ.moveTo(mmToStepsZ(tz));
  runAll();

  posX = tx; posY = ty; posZ = tz;
  printPos();
  Serial.println("OK");

}

void cmdGOTO(bool hx,float x,bool hy,float y,bool hz,float z){
  float tx = hx?clampf(x,0,LIMIT_X):posX;
  float ty = hy?clampf(y,0,LIMIT_Y):posY;
  float tz = hz?clampf(z,0,LIMIT_Z):posZ;

  stepperX.moveTo(mmToStepsX(tx));
  stepperY.moveTo(mmToStepsY(ty));
  stepperZ.moveTo(mmToStepsZ(tz));
  runAll();

  posX=tx; posY=ty; posZ=tz;
  printPos();
  Serial.println("OK");

}

void cmdPSET(int n){
  if(n<1||n>4){ Serial.println("ERR PSET index 1..4"); return; }
  taught[n].x=posX; taught[n].y=posY; taught[n].z=posZ; taught[n].taught=true;
  Serial.print("PSET "); Serial.print(n); Serial.print(" ");
  printPos();

}

void cmdPGOTO(int n){
  if(n<1||n>4||!taught[n].taught){ Serial.println("ERR PGOTO not taught"); return; }
  cmdGOTO(true,taught[n].x,true,taught[n].y,true,taught[n].z);
}

void cmdSCAN(bool on){
  scanOn = on;
  Serial.println(on ? "SCAN ON" : "SCAN OFF");  // không in OK (PC không đợi OK ở lệnh này)
}

void cmdMOVE(bool hx,float x, bool hy,float y, bool hz,float z, bool hasS, int sPercent)
{
  // Nếu có S, đặt % tốc độ cho lần này
  if(hasS){
    speedPercent = clampi(sPercent, 0, 100);
    applySpeedPercent();
  }

  // Tính target từng trục (giới hạn theo LIMIT_*)
  float tx = hx ? clampf(x, 0, LIMIT_X) : posX;
  float ty = hy ? clampf(y, 0, LIMIT_Y) : posY;
  float tz = hz ? clampf(z, 0, LIMIT_Z) : posZ;

  // Lập kế hoạch chuyển động đồng thời
  stepperX.moveTo(mmToStepsX(tx));
  stepperY.moveTo(mmToStepsY(ty));
  stepperZ.moveTo(mmToStepsZ(tz));
  runAll();               // block cho đến khi xong

  // Cập nhật & báo vị trí → OK (PC đợi OK sau MOVE)
  posX = tx; posY = ty; posZ = tz;
  printPos();
  Serial.println("OK");
}

bool homeAxis(AccelStepper &s,
              uint8_t sensorPin,
              float approachSpd,      // steps/s, âm = về công tắc
              float creepSpd,         // steps/s, âm = về công tắc (chậm)
              float releaseSpd,       // steps/s, dương = rời công tắc
              float clearanceMm,      // mm sau khi nhả, lùi thêm để chắc
              uint32_t tApproachMs,
              uint32_t tReleaseMs,
              uint32_t tCreepMs,
              char axisName,
              float stepsPerMm)
{
  // --- Pha A: tiếp cận nhanh tới khi TRIGGER ---
  s.setAcceleration(20000);
  s.setMaxSpeed(fabs(approachSpd));
  s.setSpeed(-fabs(approachSpd)); // vào công tắc
  uint32_t t0 = millis();
  while (analogRead(sensorPin) < HOME_TRIG_THRESH) {
    s.runSpeed();
    if (millis() - t0 > tApproachMs) { Serial.print("ERR HOME A "); Serial.println(axisName); return false; }
  }

  // --- Pha B1: rút ra cho tới khi sensor NHẢ ---
  s.setMaxSpeed(fabs(releaseSpd));
  s.setSpeed(+fabs(releaseSpd)); // rời công tắc
  t0 = millis();
  while (analogRead(sensorPin) >= HOME_TRIG_THRESH) {
    s.runSpeed();
    if (millis() - t0 > tReleaseMs) { Serial.print("ERR HOME B "); Serial.println(axisName); return false; }
  }

  // --- Pha B2: rút thêm một đoạn “clearance” để tránh dính mép ---
  long extra = lround(clearanceMm * stepsPerMm);
  long target = s.currentPosition() + extra;     // tuyệt đối theo steps hiện tại
  s.moveTo(target);
  while (s.distanceToGo() != 0) s.run();         // dùng planner để đi đúng số bước

  // --- Pha C: rà chậm lại vào tới khi TRIGGER (chính xác mép) ---
  s.setMaxSpeed(fabs(creepSpd));
  s.setSpeed(-fabs(creepSpd)); // vào công tắc
  t0 = millis();
  while (analogRead(sensorPin) < HOME_TRIG_THRESH) {
    s.runSpeed();
    if (millis() - t0 > tCreepMs) { Serial.print("ERR HOME C "); Serial.println(axisName); return false; }
  }

  // Đặt gốc tại mép công tắc
  s.setCurrentPosition(0);
  return true;
}
void cmdHOME() {
  Serial.println("Homing...");

  if (!homeAxis(stepperX, HOME_SENSOR_PIN_X,
                /*approach*/ 8000, /*creep*/ 1200, /*release*/ 6000,
                /*clearance*/ 2.0, /*ms*/ 10000, 5000, 5000, 'X', STEPS_PER_MM_X)) return;

  if (!homeAxis(stepperY, HOME_SENSOR_PIN_Y,
                2000, 600, 1500,
                2.0, 8000, 4000, 4000, 'Y', STEPS_PER_MM_Y)) return;

  if (!homeAxis(stepperZ, HOME_SENSOR_PIN_Z,
                5000, 800, 3000,
                2.0, 10000, 5000, 5000, 'Z', STEPS_PER_MM_Z)) return;

  // (Tuỳ chọn) lùi an toàn 10mm sau khi homing cả 3 trục:
  stepperX.move(mmToStepsX(10));
  stepperY.move(mmToStepsY(10));
  stepperZ.move(mmToStepsZ(10));
  runAll();
  stepperX.setCurrentPosition(0);
  stepperY.setCurrentPosition(0);
  stepperZ.setCurrentPosition(0);

  posX = posY = posZ = 0;
  applySpeedPercent();
  delay(100);

  Serial.println("Homing complete. Positions reset to 0.");
  printPos();
  Serial.println("OK");
}

// ---- Legacy buttons (giữ tương thích X+/X-/...) ----
void goToXplus(){  cmdJOG(+1,0,0); }
void goToYplus(){  cmdJOG(0,+1,0); }
void goToZplus(){  cmdJOG(0,0,+1); }
void goToXminus(){ cmdJOG(-1,0,0); }
void goToYminus(){ cmdJOG(0,-1,0); }
void goToZminus(){ cmdJOG(0,0,-1); }

// ---- Parser ----
String rx;
void parseAndExecute(String cmd){
  cmd.trim(); cmd.toUpperCase();

  if(cmd=="HOME"){ cmdHOME(); return; }
  if(cmd=="GETPOS"){ printPos(); return; }
  if(cmd=="POS?"){ printPos(); return; }
  if(cmd=="STOP"){ cmdSTOP(); return; }
  // legacy UI strings

  if(cmd=="SCAN_ON"){ cmdSCAN(true); return; }
  if(cmd=="SCAN_OFF"){ cmdSCAN(false); return; }

  if(cmd.startsWith("SPD")){
    int p = cmd.substring(3).toInt();
    cmdSPD(p); return;
  }

  if(cmd.startsWith("PSET")) { int n = cmd.substring(4).toInt(); cmdPSET(n); return; }
  if(cmd.startsWith("PGOTO")){ int n = cmd.substring(5).toInt(); cmdPGOTO(n); return; }

  if(cmd.startsWith("JOG")){
    float dx=0,dy=0,dz=0; bool any=false;
    int i=3;
    while(i<cmd.length()){
      while(i<cmd.length() && cmd[i]==' ') i++;
      if(i>=cmd.length()) break;
      char ax = cmd[i++]; String num="";
      while(i<cmd.length() && cmd[i]!=' ') num+=cmd[i++];
      float v = num.toFloat();
      if(ax=='X'){ dx=v; any=true; }
      else if(ax=='Y'){ dy=v; any=true; }
      else if(ax=='Z'){ dz=v; any=true; }
    }
    if(any) cmdJOG(dx,dy,dz); else Serial.println("ERR JOG");
    return;
  }

  if(cmd.startsWith("GOTO")){
    bool hx=false,hy=false,hz=false; float x=0,y=0,z=0;
    int i=4;
    while(i<cmd.length()){
      while(i<cmd.length() && cmd[i]==' ') i++;
      if(i>=cmd.length()) break;
      char ax = cmd[i++]; String num="";
      while(i<cmd.length() && cmd[i]!=' ') num+=cmd[i++];
      float v = num.toFloat();
      if(ax=='X'){ x=v; hx=true; }
      else if(ax=='Y'){ y=v; hy=true; }
      else if(ax=='Z'){ z=v; hz=true; }
    }
    if(hx||hy||hz) cmdGOTO(hx,x,hy,y,hz,z); else Serial.println("ERR GOTO");
    return;
  }
  if(cmd.startsWith("MOVE")){
      bool hx=false, hy=false, hz=false, hasS=false;
      float x=0, y=0, z=0;
      int   s = speedPercent;

      int i = 4;
      while(i < cmd.length()){
        while(i<cmd.length() && cmd[i]==' ') i++;
        if(i>=cmd.length()) break;

        char ax = cmd[i++]; 
        String num = "";
        while(i<cmd.length() && cmd[i]!=' ') num += cmd[i++];
        float v = num.toFloat();

        if(ax=='X'){ x=v; hx=true; }
        else if(ax=='Y'){ y=v; hy=true; }
        else if(ax=='Z'){ z=v; hz=true; }
        else if(ax=='S'){ s=(int)v; hasS=true; }
      }

      if(hx || hy || hz){
        cmdMOVE(hx,x, hy,y, hz,z, hasS, s);
      }else{
        Serial.println("ERR MOVE");
      }
      return;
    }
  Serial.println("ERR Unknown command");
}

void cmdSTOP(){
  stepperX.stop(); stepperY.stop(); stepperZ.stop();
  // chờ decelerate xong
  while (stepperX.distanceToGo()!=0 || stepperY.distanceToGo()!=0 || stepperZ.distanceToGo()!=0){
    stepperX.run(); stepperY.run(); stepperZ.run();
  }
  posX = stepperX.currentPosition() / STEPS_PER_MM_X;
  posY = stepperY.currentPosition() / STEPS_PER_MM_Y;
  posZ = stepperZ.currentPosition() / STEPS_PER_MM_Z;
  printPos();
  Serial.println("OK");
}
void setup(){
  Serial.begin(9600);
  pinMode(HOME_SENSOR_PIN_X, INPUT);
  pinMode(HOME_SENSOR_PIN_Y, INPUT);
  pinMode(HOME_SENSOR_PIN_Z, INPUT);
  applySpeedPercent();
  stepperX.setCurrentPosition(mmToStepsX(posX));
  stepperY.setCurrentPosition(mmToStepsY(posY));
  stepperZ.setCurrentPosition(mmToStepsZ(posZ));
  Serial.println("System ready. Commands: HOME | SPD p | JOG Xd Yd Zd | GOTO X Y Z | GETPOS | PSET n | PGOTO n | STOP");
}

void loop(){
  while(Serial.available()){
    char c = Serial.read();
    if(c=='\n' || c=='\r'){ if(rx.length()>0){ parseAndExecute(rx); rx=""; } }
    else { rx += c; if(rx.length()>120) rx=""; }
  }
}