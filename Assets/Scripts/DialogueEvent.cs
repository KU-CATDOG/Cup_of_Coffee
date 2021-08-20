using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DialogueEvent : MonoBehaviour
{

    public CsvLoadTest_2 CsvLoad;
    public MoveBackground movebg;
    [HideInInspector]
    public GameTime gameTime;
    [HideInInspector]
    public Button espressoSingle, espressoDouble;
    ColorBlock singleColor, doubleColor;
    [HideInInspector]
    public Image CharacterSprite;
    public GameObject DialogueBox;

    void Start()
    {
        movebg = GameObject.FindObjectOfType(typeof(MoveBackground)) as MoveBackground;
        gameTime = GameObject.FindObjectOfType(typeof(GameTime)) as GameTime;
        CharacterSprite = CsvLoad.CharacterSprite;
        espressoSingle = GameObject.Find("SingleShotLeft").GetComponent<Button>();
        espressoDouble = GameObject.Find("DoubleShotLeft").GetComponent<Button>();
        DialogueBox = CsvLoad.DialogueBox;

        singleColor = espressoSingle.colors;
        doubleColor = espressoDouble.colors;
    }
    void Update()
    {
        if (gameTime.resetDialogue)
        { //날짜 변경 시 스크립트 컨디션 리셋
            CsvLoad.endScript = false;
            CsvLoad.getCustomerOrder = false;
            gameTime.resetDialogue = false;
        }
        if (DialogueBox == null)
        {
            DialogueBox = GameObject.Find("DialogueBox");
        }
    }

    public void EventByDay(int day, int order)
    {
        switch (day)
        {
            case 0:
                Day0_tutorial(order);
                break;
            case 1:
                Day1(order);
                break;
        }
    }

    public void Day0_tutorial(int order)
    {
        switch (order)
        {
            case 0:
                DialogueBox.SetActive(true);
                break;
            case 12:
                CharacterSprite.GetComponent<RectTransform>().localPosition = new Vector2(700, 500);
                movebg.ClickMoveRight();
                break;
            case 13:
                //highlight 1 shot
                movebg.EspressomachineClicked();
                singleColor.colorMultiplier = 2;
                espressoSingle.colors = singleColor;
                break;
            case 14:
                //highlight doubleshot
                singleColor.colorMultiplier = 1;
                espressoSingle.colors = singleColor;

                doubleColor.colorMultiplier = 2;
                espressoDouble.colors = doubleColor;

                break;
            case 15:
                doubleColor.colorMultiplier = 1;
                espressoDouble.colors = doubleColor;
                //highlight espresso type buttons
                break;
            case 17:
                //highlight ristretto
                break;
            case 18:
                //highlight espresso
                break;
            case 19:
                //highlight lungo
                break;
            case 25:
                movebg.ZoomOutClicked();
                CharacterSprite.GetComponent<RectTransform>().localPosition = new Vector2(0, 500);
                break;
            case 29:
                movebg.ClickMoveLeft();
                break;
            case 32:
                CsvLoad.endScript = true;
                break;
            default:
                break;
        }
    }

    public void Day1(int order)
    {
        //event in day1
        switch (order)
        {
            case 19:
                CsvLoad.endScript = true;
                Debug.Log(CsvLoad.endScript);
                break;
            case 29:
                CsvLoad.endScript = true;
                break;

        }
    }

}