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
    public DragRebelObject DragRebelObject;
    public Drink DragDrink;
    
    [HideInInspector]
    public GameTime gameTime;
    [HideInInspector]
    public GameObject singleRistretto, singleEspresso, singleLungo, doubleRistretto, doubleEspresso, doubleLungo, 
                        GiveTokenObject, DialogueBox, EspressoMachine, HotWaterDispenser, BlackOut, Fridge;
    [HideInInspector]
    public Image CharacterSprite;
    private Outline outline;
    public Text ViewScript;
    public int EndingVar_RebelOrAgent = 0; //반란군엔딩, 끄나풀엔딩
    int scriptByCondition = 0;
    int tokenToGive = 0;
    public int AgentButtonCount = 0; //의심 버튼 누른 횟수
    public int RebelObject = 0; // 반란군 물건 // 안 받은 상태 = 0 , 받은 상태 = 1, 받고 나서 준다 = 2, 받고 나서 주지 않는다 = 3
    public bool RebelObjectChoice = false; //반란군 물건 주기 버튼 눌렀는가?
    public GameObject AgentButton; // 의심버튼 
    public bool ButtonPush = false; //의심 버튼을 눌렀는가? True -> 누름, False -> 누르지 않음
    public GameObject RebelGive, RebelNotGive;
    public bool Ending_Rebel = false, Ending_Escape = false;
    public bool Rebel_17 = false; //day17의 반란군 이벤트 성공/실패



    void Start()
    {
        movebg = GameObject.FindObjectOfType(typeof(MoveBackground)) as MoveBackground;
        gameTime = GameObject.FindObjectOfType(typeof(GameTime)) as GameTime;
        recipe = GameObject.FindObjectOfType(typeof(Recipe)) as Recipe;
        CsvCustomer = GameObject.FindObjectOfType(typeof(CsvLoadCustomer)) as CsvLoadCustomer;
        tokenManager = GameObject.FindObjectOfType(typeof(TokenTest)) as TokenTest;
        DragRebelObject = GameObject.FindObjectOfType(typeof(DragRebelObject)) as DragRebelObject;
        DragDrink = GameObject.FindObjectOfType(typeof(Drink)) as Drink;
        CharacterSprite = CsvLoad.CharacterSprite;
        DialogueBox = CsvLoad.DialogueBox;
        ViewScript = CsvLoad.ViewScript;

        EspressoMachine = GameObject.Find("EspressoMachine");
        outline = EspressoMachine.GetComponent<Outline>();

        singleRistretto = GameObject.Find("SingleRistretto");
        singleEspresso = GameObject.Find("SingleEspresso");
        singleLungo= GameObject.Find("SingleLungo");
        doubleRistretto = GameObject.Find("DoubleRistretto");
        doubleEspresso = GameObject.Find("DoubleEspresso");
        doubleLungo = GameObject.Find("DoubleLungo");
        HotWaterDispenser = GameObject.Find("HotWaterDispenser");
        GiveTokenObject = GameObject.Find("GiveToken");
        RebelGive = GameObject.Find("RebelGive");
        RebelNotGive = GameObject.Find("RebelNotGive");
        AgentButton = GameObject.Find("AgentButton");
        BlackOut = GameObject.Find("BlackOut");

        
        GiveTokenObject.SetActive(false);
        RebelGive.SetActive(false);
        RebelNotGive.SetActive(false);
        AgentButton.SetActive(false);
        BlackOut.SetActive(false);

        StartCoroutine(MiddayEvent(gameTime.day));
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

        AgentButtonCount = CsvCustomer.AgentButtonCount;
        
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
            case 8:
                Day8(order);
                break;
            case 9:
                Day9(order);
                break;
            case 10:
                Day10(order);
                break;
            case 11:
                Day11(order);
                break;
            case 12:
                Day12(order);
                break;
            case 13:
                Day13(order);
                break;
            case 14:
                Day14(order);
                break;
            case 15:
                Day15(order);
                break;
            case 16:
                Day16(order);
                break;
            case 17:
                Day17(order);
                break;
            case 18:
                Day18(order);
                break;
            case 19:
                Day19(order);
                break;
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
                outline = singleRistretto.GetComponent<Outline>();
                outline.effectColor = new Color32(255, 255, 255, 255);
                outline.effectDistance = new Vector2(5, 5);
                outline = singleEspresso.GetComponent<Outline>();
                outline.effectColor = new Color32(255, 255, 255, 255);
                outline.effectDistance = new Vector2(5, 5);
                outline = singleLungo.GetComponent<Outline>();
                outline.effectColor = new Color32(255, 255, 255, 255);
                outline.effectDistance = new Vector2(5, 5);
                break;
            case 14:
                outline.effectDistance = new Vector2(0, 0);
                outline.effectColor = new Color32(181, 181, 181, 255);
                outline = singleRistretto.GetComponent<Outline>();
                outline.effectColor = new Color32(181, 181, 181, 255);
                outline.effectDistance = new Vector2(0, 0);
                outline = singleEspresso.GetComponent<Outline>();
                outline.effectColor = new Color32(181, 181, 181, 255);
                outline.effectDistance = new Vector2(0, 0);

                //highlight doubleshot
                outline = doubleRistretto.GetComponent<Outline>();
                outline.effectColor = new Color32(255, 255, 255, 255);
                outline.effectDistance = new Vector2(5, 5);
                outline = doubleEspresso.GetComponent<Outline>();
                outline.effectColor = new Color32(255, 255, 255, 255);
                outline.effectDistance = new Vector2(5, 5);
                outline = doubleLungo.GetComponent<Outline>();
                outline.effectColor = new Color32(255, 255, 255, 255);
                outline.effectDistance = new Vector2(5, 5);

                break;
            case 15:
                outline.effectDistance = new Vector2(0, 0);
                outline.effectColor = new Color32(181, 181, 181, 255);
                outline = doubleRistretto.GetComponent<Outline>();
                outline.effectDistance = new Vector2(0, 0);
                outline.effectColor = new Color32(181, 181, 181, 255);
                outline = doubleEspresso.GetComponent<Outline>();
                outline.effectDistance = new Vector2(0, 0);
                outline.effectColor = new Color32(181, 181, 181, 255);

                break;
            case 17:
                outline = singleRistretto.GetComponent<Outline>();
                outline.effectColor = new Color32(255, 255, 255, 255);
                outline.effectDistance = new Vector2(5, 5);
                outline = doubleRistretto.GetComponent<Outline>();
                outline.effectColor = new Color32(255, 255, 255, 255);
                outline.effectDistance = new Vector2(5, 5);
                break;
            case 18:
                outline.effectDistance = new Vector2(0, 0);
                outline.effectColor = new Color32(181, 181, 181, 255);
                outline = singleRistretto.GetComponent<Outline>();
                outline.effectDistance = new Vector2(0, 0);
                outline.effectColor = new Color32(181, 181, 181, 255);

                outline = singleEspresso.GetComponent<Outline>();
                outline.effectColor = new Color32(255, 255, 255, 255);
                outline.effectDistance = new Vector2(5, 5);
                outline = doubleEspresso.GetComponent<Outline>();
                outline.effectColor = new Color32(255, 255, 255, 255);
                outline.effectDistance = new Vector2(5, 5);

                break;
            case 19:
                outline.effectDistance = new Vector2(0, 0);
                outline.effectColor = new Color32(181, 181, 181, 255);
                outline = singleEspresso.GetComponent<Outline>();
                outline.effectDistance = new Vector2(0, 0);
                outline.effectColor = new Color32(181, 181, 181, 255);

                outline = singleLungo.GetComponent<Outline>();
                outline.effectColor = new Color32(255, 255, 255, 255);
                outline.effectDistance = new Vector2(5, 5);
                outline = doubleLungo.GetComponent<Outline>();
                outline.effectColor = new Color32(255, 255, 255, 255);
                outline.effectDistance = new Vector2(5, 5);
                break;
            case 20:
                outline.effectDistance = new Vector2(0, 0);
                outline.effectColor = new Color32(181, 181, 181, 255);
                outline = singleLungo.GetComponent<Outline>();
                outline.effectDistance = new Vector2(0, 0);
                outline.effectColor = new Color32(181, 181, 181, 255);
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

                    switch (scriptByCondition)
                    {
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
                outline.effectColor = new Color32(0, 0, 0, 255);

                break;
            case 14:
                outline.effectDistance = new Vector2(0, 0);
                outline.effectColor = new Color32(255, 255, 255, 255);
                //highlight espresso double shot
                movebg.EspressomachineClicked();
                outline = doubleEspresso.GetComponent<Outline>();
                outline.effectColor = new Color32(255, 255, 255, 255);
                outline.effectDistance = new Vector2(5, 5);
                //recipe done + recipe sprite + recipe reset
                break;
            case 15:
                movebg.ZoomOutClicked();
                outline.effectDistance = new Vector2(0, 0);
                outline.effectColor = new Color32(181, 181, 181, 255);
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
                outline = doubleEspresso.GetComponent<Outline>();
                outline.effectDistance = new Vector2(5, 5);
                outline.effectColor = new Color32(255, 255, 255, 255);
                break;
            case 17:
                movebg.ZoomOutClicked();
                outline.effectDistance = new Vector2(0, 0);
                outline.effectColor = new Color32(181, 181, 181, 255);
                //highlight fridge


                //recipe done + recipe sprite + recipe reset
                break;
            case 19:
                CsvLoad.endScript = true;
                recipe.menu = 0;
                break;
            case 23:
                CsvLoad.pausescript = true;
                if(recipe.menu == 0 && DialogueBox.activeSelf ==true){
                    StartCoroutine(Special(1, 23));
                    return;
                }
                
                
                if(recipe.menu == 4){
                    CsvLoad.pausescript = false;
                    CsvLoad.currentOrder++;
                    ViewScript.text = "오 잘 마시겠네.";
                }
                else if(recipe.menu != 4 && recipe.menu != 0){
                    CsvLoad.pausescript = false;
                    CsvLoad.currentOrder++;
                    ViewScript.text = "음...이걸 원했던 건 아닌데 말이야.";
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
            case 3:
                recipe.menu = 0;
                break;
            case 4:
                CsvLoad.pausescript = true;
                if(recipe.menu == 0 && DialogueBox.activeSelf ==true){
                    StartCoroutine(Special(4, 4));
                    return;
                }

                if(recipe.menu == 1){ 
                    CsvLoad.pausescript = false;
                    ViewScript.text = "... 고맙다.";
                }
                break;
            case 7:
                CsvLoad.endScript = true;
                StartCoroutine(CountCustomer());
                break;
            case 8:
                
                //손님 +3 이후
                break;
        }
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
                            EndingVar_RebelOrAgent--;
                            ViewScript.text = "줄 수 없다고? 그것 참 실망이구만.";
                            scriptByCondition++;
                        }
                        else if(tokenToGive >= 1){
                            if(tokenToGive <=3){
                                EndingVar_RebelOrAgent++;
                            }
                            else if(tokenToGive >= 4){
                                EndingVar_RebelOrAgent+=2;
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
                            //돈++
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
                            Debug.Log("체포엔딩");
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
            case 5:
                AgentButton.SetActive(true);
                break;
            case 14:
                CsvLoad.endScript = true;
                StartCoroutine(MiddayEvent(-1));
                RebelObject = 1;
                break;
            case 18:
                DragRebelObject.ShowObject();
                break;
            case 22:
                DragRebelObject.HideObject();
                break;
        }
    }


    public void Day9(int order){
        switch(order){
            case 1:
                recipe.menu = 0;
                break;
            case 2:
                CsvLoad.pausescript = true;
                
                if(recipe.menu == 0 && DialogueBox.activeSelf ==true){
                    StartCoroutine(Special(9, 2));
                    return;
                }
                
                if(recipe.menu != 0){
                    CsvLoad.pausescript = false;
                    CsvLoad.currentOrder++;
                    ViewScript.text = "......";
                    DragRebelObject.ShowObject();
                }
                break;
            case 3:
                CsvLoad.pausescript = true;

                if(RebelObjectChoice == true)
                {
                    if (RebelObject == 2) //반란군 물건 줬을 때
                    {
                        EndingVar_RebelOrAgent++;
                        ViewScript.text = "고맙네.";
                        CsvLoad.pausescript = false;
                        CsvLoad.endScript = true;
                    }
                    else if (RebelObject == 3) // 반란군 물건 주지 않았을 때
                    {
                        ViewScript.text = "......고맙네...";
                        DragRebelObject.RebelSmth.SetActive(false);
                        CsvLoad.pausescript = false;
                        CsvLoad.endScript = true;
                    }
                    CsvLoad.currentOrder++;
                }
                
                break;
        }
    }
    

    public void Day10(int order){
        switch(order){
            case 4:
                SoundManager.Instance.PlaySFXSound("radio_channel");
                break;
        }
    }

    
    public void Day11(int order){
        switch(order){
            case 0:
                break;
        }
    }

    public void Day12(int order){
        switch(order){
            case 0:
                break;
        }
    }

    public void Day13(int order){
        switch(order){
            case 2:
                recipe.menu = 0;
                break;
            case 3:
                CsvLoad.pausescript = true;
                
                if(recipe.menu == 0 && DialogueBox.activeSelf ==true){
                    StartCoroutine(Special(13, 3));
                    return;
                }
                
                if(recipe.menu == 13){
                    CsvLoad.pausescript = false;
                    CsvLoad.currentOrder++;
                    ViewScript.text = "냄새가 정말 좋구만~ 잘 마시겠네.";
                }
                else if(recipe.menu != 13 && recipe.menu != 0){
                    CsvLoad.pausescript = false;
                    CsvLoad.currentOrder++;
                    ViewScript.text = "허허...이상한 걸 줬구만 그래.";
                }
                break;
        }
    }

    public void Day14(int order){
        switch(order){
            case 7:
                recipe.menu = 0;
                break;
            case 8:
                CsvLoad.pausescript = true;
                
                if(recipe.menu == 0 && DialogueBox.activeSelf ==true){
                    StartCoroutine(Special(14, 8));
                    return;
                }

                if(recipe.menu == 12 ){ //아바라, 정부소속
                    EndingVar_RebelOrAgent--;
                    CsvLoad.pausescript = false;
                }
                else if(recipe.menu == 17){ //딸기라떼, 고민 중
                    CsvLoad.pausescript = false;
                }
                break;
            case 9:
                CsvLoad.endScript = true;
                StartCoroutine(CountCustomer());
                break;
            case 13:
                RebelGive.SetActive(true);
                RebelNotGive.SetActive(true);
                RebelGive.transform.GetChild(0).gameObject.GetComponent<Text>().text = "O";
                RebelNotGive.transform.GetChild(0).gameObject.GetComponent<Text>().text = "X";
                break;
            case 14:
                RebelGive.SetActive(false);
                RebelNotGive.SetActive(false);
                CsvLoad.pausescript = true;
                if(Ending_Escape == true){ //탈출엔딩
                    ViewScript.text = "좋아, 출발하자고.";
                    CsvLoad.pausescript = false;
                    Debug.Log("탈출엔딩");
                }
                else if(Ending_Escape == false){
                    ViewScript.text = "아쉽구만. 잘 지내시게, 젊은이.";
                    CsvLoad.pausescript = false;
                    //반란군 루트 분기점
                    if(EndingVar_RebelOrAgent >= 2){ //수치가 2 이상일 경우 반란군 엔딩 확정
                        Ending_Rebel = true;
                        CsvLoad.currentOrder++;
                    }
                    else{
                        CsvLoad.currentOrder += 27; //반란군 루트가 아닐 경우 관련 대사 스킵
                    }
                }
                break;
            case 15:
                
                break;
        }

    }

    public void Day15(int order){
        switch(order){
            case 0:
                break;
        }
    }

    public void Day16(int order){
        switch(order){
            case 0:
                break;
        }
    }
    

    public void Day17(int order){
        switch(order){
            case 1:
                CsvLoad.pausescript = true;
                if(Ending_Rebel){
                    Day17_RebelEvent(scriptByCondition);
                }
                else{
                    CsvLoad.pausescript = false;
                }
                break;
            case 5:
                recipe.menu = 0;
                break;
            case 6:
                CsvLoad.pausescript = true;
                if(recipe.menu == 0 && DialogueBox.activeSelf ==true){
                    StartCoroutine(Special(17, 6));
                    return;
                }

                if(recipe.menu == 21){ //녹차스무디 (수상한 인물 있음)
                    CsvLoad.pausescript = false;
                    EndingVar_RebelOrAgent--;
                }
                else if(recipe.menu == 19){ //아이스초코 (수상한 인물 없음)
                    CsvLoad.pausescript = false;
                    EndingVar_RebelOrAgent++;
                }
                break;
            case 7:
                CsvLoad.pausescript = true;
                ViewScript.text = "알겠어요. 다음에 봐요 학생.";
                
                CsvLoad.currentOrder +=3;
                break;
            case 10:
                CsvLoad.pausescript = false;
                CsvLoad.endScript = true;
                CsvLoad.DialogueBox.SetActive(false);
                break;
        }
    }

    public void Day17_RebelEvent(int order){
        switch(order){
            case 0:
                ViewScript.text = "오늘도 평소와 같이 수거하러 왔어요.";
                break;
            case 1:
                ViewScript.text = "어? 학생 근데 그 통은 뭔가요?.";
                break;
            case 2:
                ViewScript.text = "평소엔 없던 통인데...";
                break;
            case 3:
                ViewScript.text = "안을 한 번 봐도 될까요?";
                break;
            case 4:
                ViewScript.text = "흠... 감정 토큰이 되게 많네요.";
                break;
            case 5:
                ViewScript.text = "요즘 커피가 많이 팔렸나 봐요?";
                break;
            case 6:
                ViewScript.text = "두 통이나 나오다니 역대급이네요.";
                break;
            case 7:
                ViewScript.text = "이 통도 제가 수거하면 되는 거죠?";
                RebelGive.SetActive(true);
                RebelNotGive.SetActive(true);
                RebelGive.transform.GetChild(0).gameObject.GetComponent<Text>().text = "준다";
                RebelNotGive.transform.GetChild(0).gameObject.GetComponent<Text>().text = "안 준다";
                scriptByCondition--;
                break;
            case 8:
                RebelGive.SetActive(false);
                RebelNotGive.SetActive(false);
                if(Rebel_17){
                    ViewScript.text = "학생 고마워요. 이만 가 볼게요.";
                }
                else{
                    ViewScript.text = "학생이 이럴 줄은 몰랐는데...";
                }
                break;
            case 9:
                if(Rebel_17){
                    CsvLoad.pausescript = false;
                    CsvLoad.endScript = true;
                    CsvLoad.currentOrder += 9;
                    CsvLoad.DialogueBox.SetActive(false); 
                }
                else{
                    ViewScript.text = "같이 서까지 가 주셔야겠습니다.";
                    Debug.Log("체포엔딩");
                }
                break;
        }
        scriptByCondition++;
    }


    public void Day18(int order){
        switch(order){
            case 0:
                break;
        }
    }

    public void Day19(int order){
        switch(order){
            case 9:
                StartCoroutine(Flickering());           
                break;
            case 29:
                CsvLoad.endScript = true;
                break;
        }
    }

    public void Day20(int order){
        switch(order){
            case 0:
                break;
        }
    }

    IEnumerator Flickering(){
        for(int i =0; i<3; i++){
            BlackOut.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            BlackOut.SetActive(false);
            yield return new WaitForSeconds(0.3f);
        }
    }
    IEnumerator MiddayEvent(int day) //조건에 따라 대사 출력 여부 결정
    {
        if (day == 3 || day == 4 || day == 5 || day == -1 || day == 13 || day==19) //정오에 대사 출력하는 경우
        {
            if(day != -1){
                CsvLoad.endScript = true;
                CsvLoad.getCustomerOrder = true;
                //CsvLoad.startCustomerOrder();
            }
            while (gameTime.hour < 12 || CsvCustomer.currentorder != 1)
            {
                yield return null;
            }
            CsvLoad.pauseCustomerOrder(); 

        }
        else if(day == 2){   //2일차 하루 끝에 대사 출력
            CsvLoad.endScript = true;
        }
        else if(day == 15 || day == 18){ //반란군 루트가 아닐 경우 관련 대사 스킵
            if(!Ending_Rebel){
                switch(day){
                    case 15:
                        CsvLoad.currentOrder += 11;
                        break;
                    case 18:
                        CsvLoad.currentOrder += 9;
                        break;
                }
            }
        }
        else
        {
            yield return null;
        }
    }

    IEnumerator CountCustomer(){ //손님 3명 이후 특수 대사 출력
        int n = CsvCustomer.numberOfCustomer;
        while(CsvCustomer.numberOfCustomer - n < 3 || CsvCustomer.currentorder != 1){ //손님 3명 이후 나머지 대사 출력
            yield return null;
        }

        CsvLoad.pauseCustomerOrder();
    }


    IEnumerator Special(int day, int order){ //특수 등장인물 음료 제조 시 대화창 끄기 & 드래그로 음료 주기
        if(DragDrink.SpecialCustomer ){
            yield return null;
        }

        DialogueBox.SetActive(false);
        while(recipe.menu == 0 || !DragDrink.SpecialCustomer){
            yield return null;
        }
        
        DialogueBox.SetActive(true);
        switch(day){ 
            case 1:
                Day1(order);
                break;
            case 4:
                Day4(order);
                break;
            case 9:
                Day9(order);
                break;
            case 13:
                Day13(order);
                break;
            case 14:
                Day14(order);
                break;
            case 17:
                Day17(order);
                break;
            default:   
                break;
        }
    }

    public void ButtonGive()
    {
        // if(gameTime.day == 9){ //10일차 이벤트: 반란군 일원에게 물건 전해줌
        //     RebelObjectChoice = true;
        //     RebelObject = 2;
        //     Day9(3);
        // }
        if(gameTime.day == 14){ //탈출엔딩: 탈출한다
            //if(money >= 100만원)
            Ending_Escape = true;
            Day14(14);
        }
        else if(gameTime.day == 17){ //18일차 이벤트: 감시자에게 토큰 넘겨줌
            Rebel_17 = true;
            scriptByCondition++;
            Day17_RebelEvent(8);
        }
        

    }
    public void ButtonNotGive()
    {
        // if(gameTime.day == 9){ //10일차 이벤트: 반란군 일원에게 물건 전해주지 않음
        //     RebelObjectChoice = true;
        //     RebelObject = 3;
        //     Day9(3);
        // }
        if(gameTime.day == 14){ //탈출엔딩: 탈출하지 않는다
            Ending_Escape = false;
            Day14(14);
        }
        else if(gameTime.day == 17){ //18일차 이벤트: 감시자에게 토큰 넘겨주지 않음
            Rebel_17 = false;
            scriptByCondition++;
            Day17_RebelEvent(8);
        }

    }

}