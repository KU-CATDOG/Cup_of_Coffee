using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{

    public float secPerMin = 1; // real time second to game time minute: 1 real time seconds = 1 game time minute

    public Text clock;
    public Text dayCounter;

    float sec;
    int hour = 0;
    int minute = 0;
    int day;



    // Start is called before the first frame update
    void Start()
    {
        clock.text = hour.ToString() + ":" + minute.ToString();
        sec = secPerMin;
    }

    // Update is called once per frame
    void Update()
    {
        sec -= Time.deltaTime;

        if(sec <= 0){
            minute++;
            sec = secPerMin;
            
            if(minute >= 60){
                hour++;
                minute = 0;
                
                if(hour>= 24){
                    day++;
                    hour = 0;

                    dayCounter.text = "Day : " + day.ToString();
                }
            }

            clock.text = hour.ToString("00") + ":" + minute.ToString("00");

        }

        
    }
}
