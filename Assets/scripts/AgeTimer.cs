using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgeTimer : MonoBehaviour
{
    public Text timerText;
     private float secondsCount;
     private int ageCount = 100;
     private int hourCount;
     void Update(){
         UpdateTimerUI();
     }
 //call this on update
     public void UpdateTimerUI(){
         //set timer UI
         secondsCount += Time.deltaTime;
         //timerText.text = hourCount +"h:"+ minuteCount +"m:"+(int)secondsCount + "s";
         timerText.text = ageCount + " years old";
         if(secondsCount >= 2){
             ageCount++;
             secondsCount = 0;
         } 
     }
}
