using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{

    public float secPerMin = 1; // real time second to game time minute: 1 real time seconds = 1 game time minute

    public Text clock;
    public Text dayCounter;

    public int startTime;
    public int endTime = 24;

    float sec;

    int minute = 0;
    [HideInInspector]
    public int hour = 0;
    [HideInInspector]
    public int day;
    [HideInInspector]
    public bool resetDialogue = false;

    [HideInInspector]
    public bool isTimePassing = true;

    public InGameSaveLoadUI saveLoadUI;
    public GameObject ReceiptObject;
    Receipt receipt;
    public Recipe recipe;

    // Start is called before the first frame update
    void Start()
    {
        hour = startTime;
        clock.text = hour.ToString("00") + ":" + minute.ToString("00");
        sec = secPerMin;
        receipt = ReceiptObject.GetComponent<Receipt>();
        ReceiptObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimePassing)
        {
            sec -= Time.deltaTime;

            if (sec <= 0)
            {
                minute++;
                sec = secPerMin;

                if (minute >= 60)
                {
                    hour++;
                    minute = 0;

                    if (hour == ChangeOutside.instance.dayToTwilight)
                    {
                        ChangeOutside.instance.ChangeImageToTwilight();
                    }
                    else if (hour == ChangeOutside.instance.twilightToNight)
                    {
                        ChangeOutside.instance.ChangeImageToNight();
                    }

                    if (hour >= endTime)
                    {
                        ReceiptObject.SetActive(true);
                        receipt.UpdateGameTime();

                        recipe.totalMistakeCount += recipe.dayMistakeCount;
                        recipe.dayMistakeCount = 0;

                        day++;
                        hour = startTime;
                        resetDialogue = true;

                        dayCounter.text = "Day : " + day.ToString();

                        isTimePassing = false;
                        saveLoadUI.OpenSaveLoadPanel();
                    }
                }

                clock.text = hour.ToString("00") + ":" + minute.ToString("00");

            }
        }


    }

    public void receiptClose()
    {
        ReceiptObject.SetActive(false);
    }

}



