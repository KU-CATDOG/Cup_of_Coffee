using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class DialogueEvent : MonoBehaviour
{

    public CsvLoadTest_2 CsvLoad;
    public MoveBackground movebg;
    public Recipe recipe;
    [HideInInspector]
    public GameTime gameTime;
    [HideInInspector]
    public GameObject espressoSingle, espressoDouble;
    ColorBlock singleColor, doubleColor;
    [HideInInspector]
    public Image CharacterSprite;
    public GameObject DialogueBox;
    public GameObject EspressoMachine, HotWaterDispenser;
    private Outline outline;

    public Text ViewScript;

    void Start()
    {
        movebg = GameObject.FindObjectOfType(typeof(MoveBackground)) as MoveBackground;
        gameTime = GameObject.FindObjectOfType(typeof(GameTime)) as GameTime;
        recipe = GameObject.FindObjectOfType(typeof(Recipe)) as Recipe;
        CharacterSprite = CsvLoad.CharacterSprite;
        DialogueBox = CsvLoad.DialogueBox;
        ViewScript = CsvLoad.ViewScript;

        EspressoMachine = GameObject.Find("EspressoMachine");
        outline = EspressoMachine.GetComponent<Outline>();

        espressoSingle = GameObject.Find("SingleEspresso");
        espressoDouble = GameObject.Find("DoubleEspresso");
        HotWaterDispenser = GameObject.Find("HotWaterDispenser");


    }
    void Update()
    {
        if (gameTime.resetDialogue)
        { //날짜 변경 시 스크립트 컨디션 리셋
            CsvLoad.endScript = false;
            CsvLoad.getCustomerOrder = false;
            gameTime.resetDialogue = false;

            StartCoroutine(MiddayEvent(gameTime.day));
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
            case 3:
                //Day3(order);
                break;
            case 4:
                Day4(order);
                break;
            // case 5:
            //     Day5(order);
            //     break;
            // case 6:
            //     Day6(order);
            //     break;
        }
    }

    int wrong = 0;
    public void Day0_tutorial(int order)
    {
        
        switch (order)
        {
            case 12:
                CharacterSprite.GetComponent<RectTransform>().localPosition = new Vector2(700, 500);
                movebg.ClickMoveRight();
                outline.effectDistance = new Vector2(10, 10);
                outline.effectColor = new Color32(0,0,0,255);

                break;
            case 13:
                outline.effectDistance = new Vector2(0, 0);
                outline.effectColor = new Color32(255,255,255,255);
                
                movebg.EspressomachineClicked();

                //highlight 1 shot
                outline = espressoSingle.GetComponent<Outline>();
                outline.effectDistance = new Vector2(5, 5);
                break;
            case 14:
                outline.effectDistance = new Vector2(0, 0);

                //highlight doubleshot
                outline = espressoDouble.GetComponent<Outline>();
                outline.effectDistance = new Vector2(5, 5);

                break;
            case 15:
                outline.effectDistance = new Vector2(0, 0);

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
                List<char> espresso_ristretto = new List<char>(new char[] { 'P' });
                if(recipe.queue.SequenceEqual(espresso_ristretto)){
                    CsvLoad.pausescript = false;
                    movebg.ZoomOutClicked();
                    CharacterSprite.GetComponent<RectTransform>().localPosition = new Vector2(0, 500);
                }
                else{
                    CsvLoad.pausescript = true;
                    wrong++;

                    switch(wrong){
                        case 1:
                            ViewScript.text = "아니 그거 말고.";
                            break;
                        case 2:
                            ViewScript.text = "리스트레또. 제일 왼쪽 버튼.";
                            break;
                        default:
                            ViewScript.text = "버튼 하나 누르는게 그렇게 어려워?";
                            break;
                    }
                }
                recipe.IngredientReset();
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
            case 10:
                CharacterSprite.GetComponent<RectTransform>().localPosition = new Vector2(700, 500);
                movebg.ClickMoveRight();
                break;
            case 13:
                //highlight water dispenser
                outline = HotWaterDispenser.GetComponent<Outline>();
                outline.effectDistance = new Vector2(10, 10);
                outline.effectColor = new Color32(0,0,0,255);
                
                break;
            case 14:
                outline.effectDistance = new Vector2(0, 0);
                outline.effectColor = new Color32(255,255,255,255);
                //highlight espresso double shot
                movebg.EspressomachineClicked();
                outline = espressoDouble.GetComponent<Outline>();
                outline.effectDistance = new Vector2(5, 5);
                //recipe done + recipe sprite + recipe reset
                break;
            case 15:
                movebg.ZoomOutClicked();
                outline.effectDistance = new Vector2(0, 0);
                //highlight water dispenser
                outline = HotWaterDispenser.GetComponent<Outline>();
                outline.effectDistance = new Vector2(10, 10);
                outline.effectColor = new Color32(0,0,0,255);
                break;
            case 16:
                outline.effectDistance = new Vector2(0, 0);
                outline.effectColor = new Color32(255,255,255,255);
                //highlight espresso double
                movebg.EspressomachineClicked();
                outline = espressoDouble.GetComponent<Outline>();
                outline.effectDistance = new Vector2(5, 5);
                break;
            case 17:
                movebg.ZoomOutClicked();
                outline.effectDistance = new Vector2(0, 0);
                //highlight fridge
                //recipe done + recipe sprite + recipe reset
                break;
            case 19:
                CsvLoad.endScript = true;
                Debug.Log(CsvLoad.endScript);
                break;
            case 23:
                //음료 제조 성공 여부 & 탈출엔딩+1
                break;
            case 29:
                CsvLoad.endScript = true;
                break;

        }
    }


    IEnumerator MiddayEvent(int day){
        if(day == 3 || day == 4 || day == 5){
            CsvLoad.endScript = true;
            CsvLoad.getCustomerOrder = true;
            while(gameTime.hour != 12){
                yield return null;
            }

            CsvLoad.endScript = false;
            CsvLoad.getCustomerOrder = false;
        
        }
        else{
            yield return null;
        }
    }

    
    public void Day4(int order){
        switch(order){
            case 6:
                //손님 +3 이후
                break;
        }
    }

    /*

    public void Day5(int order){
        switch(order){
            case 0:
                //하루 중간
                break;
            case 5:
                //(선택지: 브로커에게 토큰) "0개: 엔딩 -1 // 1~3개: 엔딩 +1 // 4개 이상: 엔딩 +2	최대 10개까지"
                break;
            case 6:
                //5에서 0일시 "줄 수 없다고? 그것 참 실망이구만.", 1이상일 시 대사 6-7 출력
                break;
            case 8:
                //손님 +n명 후
                break;
            case 9:
                //그런데 학생, 이런 정치 얘기 싫어할 거 같긴 한데...	        근데 이거, 어째 양이 좀 적은 것 같은데? 흠...	               4-7 (토큰을 브로커에게 준 경우) 
                //학생은 뭐 정부에 반항하거나 이러진 않죠?                  	조사를 좀 해봐야 할 것 같은데, 같이 서까지 가주셔야겠습니다.	8-10개
        }
    }

    public void Day6(int order){
        switch(order){
            case 0:
        }
    }

    public void Day8(int order){
        switch(order){
            //case 15?: 하루 중간
        }
    }

    public void Day9(int order){
        switch(order){
            case 0:
                //주문
                break;
            case 3:
                //물건 주면 C, 안주면 D
                break;
            //case 4?: 하루 끝
        }
    }

    public void Day10(int order){
        switch(order){
            case 4:
                //라디오 소리
                break;
        }
    }

    */

}