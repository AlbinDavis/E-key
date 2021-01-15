#include <Firebase.h>  
#include <FirebaseArduino.h>  
#include <FirebaseCloudMessaging.h>  
#include <FirebaseError.h>  
#include <FirebaseHttpClient.h>  
#include <FirebaseObject.h>   
#include <ESP8266WiFi.h>  
#include <FirebaseArduino.h>   
#define FIREBASE_HOST "hkey-95494.firebaseio.com"  
#define FIREBASE_AUTH "Y5HlsW2FYz8GTnX0QdAKoGAvAYUr7GHuKbRMUNjr"  
#define WIFI_SSID "ssid"  
#define WIFI_PASSWORD "password"  
  
void setup() {  
    Serial.begin(9600);   
    WiFi.begin(WIFI_SSID, WIFI_PASSWORD);  
    Serial.print("connecting");  
    while (WiFi.status() != WL_CONNECTED) {  
    Serial.print(".");  
    delay(500);  
  } 
   
  Serial.println();  
  Serial.print("connected: ");  
  Serial.println(WiFi.localIP());    
  Firebase.begin(FIREBASE_HOST, FIREBASE_AUTH);  
  Firebase.set("pin","");  
  Firebase.set("task",0); 
  Firebase.set("re",0); 
  Firebase.set("shut",0); 
}  
  
String str,str1;
void loop() { 


  if (Serial.available() > 0) {
    str=Serial.readString();
    Firebase.setString("pin", str);
  }
  
 str1=Firebase.getInt("task");
 if(str1=="1"){
    Serial.println(1);
    delay(800);
    Firebase.set("task",0);
 }

 
 str1=Firebase.getInt("shut");
 if(str1=="1"){
     Serial.println(2);
     delay(800);
     Firebase.set("shut",0);
 }
 
 str1=Firebase.getInt("re");
 if(str1=="1"){
     Serial.println(3);
     delay(800);
     Firebase.set("re",0);
 }

}  
