using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class timer : MonoBehaviour

{
  public Text timerText;
  public float timeValue=90;
  public static bool isDead= false;

void Start()
{
            isDead=false;

}
    void Update()
    { 
    if (timeValue>0)
 {
        timeValue-=Time.deltaTime;



}
  else {
    timeValue=0;
          }
 DisplayTime(timeValue);
} 
  void DisplayTime(float timeToDisplay)
{
  if(timeToDisplay<0)
 {
    timeToDisplay=0;

       }
         float minutes=Mathf.FloorToInt(timeToDisplay/ 60);
         float seconds=Mathf.FloorToInt(timeToDisplay%60);
         timerText.text="Time Left : "+string.Format("{0:00}:{1:00}",minutes,seconds);
        if(seconds==0f&&minutes==0f)
        {
          isDead=true;

        }
        else{
          isDead=false;
        }

    }
}