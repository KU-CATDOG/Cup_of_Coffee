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
    public CsvLoadCustomer CsvCustomer;
    public TokenTest tokenManager;
    [HideInInspector]
    public GameTime gameTime;
    [HideInInspector]
    public GameObject espressoSingle, espressoDouble, GiveTokenObject;
    ColorBlock singleColor, doubleColor;
    [HideInInspector]
    public Image CharacterSprite;
    public GameObject DialogueBox;
    public GameObject EspressoMachine, HotWaterDispenser;
    private Outline outline;
    public Text ViewScript;
    public int EndingVar_Escape = 0; //탈출엔딩
    int scriptByCondition = 0;
    int tokenToGive = 0;
    void Start()
    {
        movebg = GameObject.FindObjectOfType(typeof(MoveBackground)) as MoveBackground;
        gameTime = GameObject.FindObjectOfType(typeof(GameTime)) as GameTime;
        recipe = GameObject.FindObjectOfType(typeof(Recipe)) as Recipe;
        CsvCustomer = GameObject.FindObjectOfType(typeof(CsvLoadCustomer)) as CsvLoadCustomer;
        tokenManager = GameObject.FindObjectOfType(typeof(TokenTest)) as TokenTest;
        CharacterSprite = CsvLoad.CharacterSprite;
        DialogueBox = CsvLoad.DialogueBox;
        ViewScript = CsvLoad.ViewScript;

        EspressoMachine = GameObject.Find("EspressoMachine");
        outline = EspressoMachine.GetComponent<Outline>();

        espressoSingle = GameObject.Find("SingleEspresso");
        espressoDouble = GameObject.Find("DoubleEspresso");
        HotWaterDispenser = GameObject.Find("HotWaterDispenser");
        GiveTokenObject = GameObject.Find("GiveToken");

        
        GiveTokenObject.SetActive(false);
    }
    void Update()
    {
        if (gameTime.resetDialogue)
        { //날짜 변경 시 스크립트 컨디션 리셋
            CsvLoad.endScript = false;
            CsvLoad.getCustomerOrder = false;
            gameTime.resetDialogue = false;
            scriptByCondition = 0;

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
            case 4:
                Day4(order);
                break;
            case 5:
                Day5(order);
                break;
                // case 6:
                //     Day6(order);
                //     break;
            case 8:
                Day8(order);
                break;
            case 9:
                Day9(order);
                break;
            // case 10:
            //     Day10(order);
            //     break;
        }
    }

    
    public void Day0_tutorial(int order)
    {

        switch (order)
        {
            case 12:
                CharacterSprite.GetComponent<RectTransform>().localPosition = new Vector2(700, 500);
                movebg.ClickMoveRight();
                outline.effectDistance = new Vector2(10, 10);
                outline.effectColor = new Color32(0, 0, 0, 255);

                break;
            case 13:
                outline.effectDistance = new Vector2(0, 0);
                outline.effectColor = new Color32(255, 255, 255, 255);

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
                if (recipe.queue.SequenceEqual(espresso_ristretto))
                {
                    CsvLoad.pausescript = false;
                    movebg.ZoomOutClicked();
                    CharacterSprite.GetComponent<RectTransform>().localPosition = new Vector2(0, 500);
                }
                else
                {
                    CsvLoad.pausescript = true;
                    scriptByCondition++;

                    ViewScript.text = scriptByCondition switch
                    {
                        1 => "아니 그거 말고.",
                        2 => "리스트레또. 제일 왼쪽 버튼.",
                        _ => "버튼 하나 누르는게 그렇게 어려워?",
                    };
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
                outline.effectColor = new Color32(0, 0, 0, 255);

                break;
            case 14:
                outline.effectDistance = new Vector2(0, 0);
                outline.effectColor = new Color32(255, 255, 255, 255);
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
                outline.effectColor = new Color32(0, 0, 0, 255);
                break;
            case 16:
                outline.effectDistance = new Vector2(0, 0);
                outline.effectColor = new Color32(255, 255, 255, 255);
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
                break;
            case 23:
                CsvLoad.pausescript = true;
                
                if(recipe.menu == 4 && scriptByCondition == 0){
                    CsvLoad.pausescript = false;
                    //탈출++;
                }
                else if(scriptByCondition > 0){
                    CsvLoad.currentOrder++;
                    CsvLoad.pausescript = false;
                }
                else if(recipe.menu != 4){
                    scriptByCondition++;
                    ViewScript.text = "(음료 제조 실패 시 대사)";
                }

                break;
            case 29:
                CsvLoad.endScript = true;
                break;

        }
    }


    public void Day4(int order)
    {
        switch (order)
        {
            case 7:
                CsvLoad.endScript = true;
                StartCoroutine(CountCustomer());
                break;
            case 8:
                
                //손님 +3 이후
                break;
        }
    }

    
    IEnumerator MiddayEvent(int day)
    {
        if (day == 3 || day == 4 || day == 5 || day == -1)
        {
            if(day != -1){
                CsvLoad.endScript = true;
                CsvLoad.getCustomerOrder = true;
            }
            while (gameTime.hour != 12)
            {
                yield return null;
            }
            CsvLoad.PauseCustomerOrder(); 

        }
        else
        {
            yield return null;
        }
    }

    IEnumerator CountCustomer(){
        int n = CsvCustomer.numberOfCustomer;
        while(CsvCustomer.numberOfCustomer - n != 4 || CsvCustomer.currentorder != 1){ //손님 3명 이후 나머지 대사 출력
            yield return null;
        }

        CsvLoad.PauseCustomerOrder();
    }

    public void Day5(int order){
        
        switch(order){
            case 0:
                //하루 중간
                break;
            case 5:
                //(선택지: 브로커에게 토큰) "0개: 엔딩 -1 // 1~3개: 엔딩 +1 // 4개 이상: 엔딩 +2	최대 10개까지"
                GiveTokenObject.SetActive(true);
                break;
            case 6:
                tokenToGive = tokenManager.tokenToGive;
                GiveTokenObject.SetActive(false);
                CsvLoad.pausescript = true;

                switch(scriptByCondition){
                    case 0:
                        if(tokenToGive == 0){
                            EndingVar_Escape -= 1;
                            ViewScript.text = "줄 수 없다고? 그것 참 실망이구만.";
                            scriptByCondition++;
                        }
                        else if(tokenToGive >= 1){
                            if(tokenToGive <=3){
                                EndingVar_Escape++;
                            }
                            else if(tokenToGive >= 4){
                                EndingVar_Escape +=2;
                            }
                            tokenManager.GiveToken(tokenToGive);
                            ViewScript.text = tokenToGive.ToString() + "개 받았네.";
                            scriptByCondition++;
                        }
                        break;
                    case 1:
                        if(tokenToGive == 0){
                            CsvLoad.pausescript = false;
                            CsvLoad.endScript = true;
                            CsvLoad.currentOrder++;
                            CsvLoad.DialogueBox.SetActive(false);
                            StartCoroutine(CountCustomer());
                        }
                        else if(tokenToGive >= 1){
                            ViewScript.text = "여기 " + (tokenToGive*10).ToString() + "만원일세. 잘 받으시게나. 정말 고맙네~";
                            scriptByCondition++;
                        }
                        break;
                    case 2:
                        CsvLoad.pausescript = false;
                        CsvLoad.endScript = true;
                        CsvLoad.currentOrder++;
                        CsvLoad.DialogueBox.SetActive(false);
                        StartCoroutine(CountCustomer());
                        break;
                }
                break;
            case 8:
                scriptByCondition = 0;
                //손님 +n명 후
                break;
            case 9:
                CsvLoad.pausescript = true;

                switch(scriptByCondition){
                    case 0:
                        if(tokenToGive >= 4){
                            ViewScript.text = "근데 이거, 어째 양이 좀 적은 것 같은데? 흠..."; //브로커에게 토큰을 4개 이상 주었을 경우
                            scriptByCondition++;
                        }
                        else{
                            CsvLoad.pausescript = false; //브로커에게 토큰을 0~3개 주었을 경우
                        }
                        break;
                    case 1:
                        if(tokenToGive >= 4 && tokenToGive <=7){
                            CsvLoad.pausescript = false;
                            CsvLoad.currentOrder++;
                        }
                        else if(tokenToGive >= 8 && tokenToGive <= 10){
                            ViewScript.text = "조사를 좀 해봐야 할 것 같은데, 같이 서까지 가주셔야겠습니다."; //브로커에게 토큰을 8개 이상 주었을 경우
                            //CsvLoad.pausescript = false;
                            Debug.Log("bad ending?");
                        }
                        break;
                }
                break;
        }
    }

    
    public void Day6(int order){
        switch(order){
            case 0:
            break;
        }
    }

    public void Day8(int order){
        switch(order){
            case 14:
                CsvLoad.endScript = true;
                StartCoroutine(MiddayEvent(-1));
                break;
        }
    }
    
    public void Day9(int order){
        switch(order){
            case 0:
                //주문
                break;
            case 3:
                //물건 주면 C, 안주면 D
                CsvLoad.endScript = true;
                break;
        }
    }
    /*
    public void Day10(int order){
        switch(order){
            case 4:
                //라디오 소리
                break;
        }
    }

    */

}