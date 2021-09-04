using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CsvLoadCustomer : MonoBehaviour
{
    public Text Customertext;
    public GameObject Customertextbox;
    public GameObject token;
    public GameObject recipe;

    public bool isActive;
    public bool isSuccess;
    public bool isFail;
    public bool isLock;

    public int menunumber;
    public string menustring;
    public int currentorder = 0;
    public string[] text = new string[4];
    public int recipe_number;
    public int b; // 에스프레소, 룽고, 리스트레토 중 무엇인가를 담당
    public int real; // real = 진짜 감정을 줄 확률
    public int customertoken; //손님이 들어올 때 결정되는 토큰
    public int AgentButtonCount = 0; //의심 버튼 누른 횟수
    int recentClick = 0; //의심 버튼 중복 클릭 방지

    public Image CustomerSprite;
    public Image RealEmotionSprite;

    public int numberOfCustomer = 0;
    public int totalNumberOfCustomer = 0;

    private int customerTextType;

    void Start()
    {
        isActive = false;
        Customertextbox.SetActive(false);
        text[0] = "안녕하세요";
        b = 0;
        real = 80;
        token = GameObject.Find("TokenObject");
        recipe = GameObject.Find("RecipeTest");
    }

    private void SetRandom() //랜덤으로 들어오는 것들 설정 = 메뉴, 토큰
    {
        do
        {
            menunumber = Random.Range(1, 29); //메뉴 1~29까지 랜덤 선택
        }
        while (UnlockRecipe.Instance.recipeUnlockStatus[menunumber - 1] == false);
        Debug.Log("SetRandom()");
        customerTextType = Random.Range(0, 4);
        Menu(menunumber);
        customertoken = Random.Range(1, 8);

        LoadCustomerSprite(); //손님 스프라이트
        LoadEmotionSprite(customertoken);  //감정 스프라이트 로드
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Customer();
        }
    }

    public void RecipeCheck()
    {
        if (menunumber == recipe_number)
        {
            Pass();
            b = 0;
            Debug.Log("pass");
        }
        else
        {
            Fail();
            b = 0;
            Debug.Log("fail");
        }

    }

    public void Customer()
    {

        if (isActive == true)
        {
            Customertext.text = text[currentorder];
            Debug.Log(currentorder);
            if (currentorder < 3) // 자꾸 배열 크기 오류 나서 이렇게 설정
            {
                currentorder++;
            }

            if (currentorder == 1)
            {

                if (isLock == false) // 반복해서 주문이 오지 않도록 설정
                {

                    SetRandom();
                    SoundManager.Instance.PlaySFXSound("door_open");
                    SoundManager.Instance.PlaySFXSound("door_bell");
                    isLock = true;

                    return;
                }
            }

        }
    }

    public void CustomerReset()
    {
        currentorder = 0;
        isLock = false;
        isSuccess = false;
        isFail = false;
    }

    public void Pass()
    {
        Customertext.text = customerTextType switch
        {
            0 => "감사합니다.",
            1 => "수고해.",
            2 => "감사합니다...",
            3 => "와, 맛있어요! 감사합니다.",
            _ => "",
        };
        CustomerReset();
        numberOfCustomer++;
        totalNumberOfCustomer++;
        int random = Random.Range(0, 100);
        if (random < real) // 진짜 감정을 줄 때
        {
            token.GetComponent<TokenTest>().RealToken(customertoken);
        }
        else // 가짜 감정을 줄 때
        {
            token.GetComponent<TokenTest>().FakeToken(customertoken);
        }
    }

    public void Fail()
    {
        Customertext.text = customerTextType switch
        {
            0 => "저 이거 안 시켰는데...아무튼 감사합니다.",
            1 => "뭐야? 내가 시킨 게 아니잖아!",
            2 => "어... 음료를 잘못 주신 거 같은데요...",
            3 => "으... 이거 맛이 이상한데요.",
            _ => "",
        };
        //Customertext.text = "아니 이걸 시킨 적이 없는데... 이게 왜 나와요;;";
        CustomerReset();
    }

    public void Menu(int number) // 메뉴 호출
    {
        switch (number)
        {
            case 1: // 에스프레소는 리스트레토, 에스프레소, 룽고;
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "에스프레소로 쓰지 않게 한 잔 주세요.";
                    menustring = "espresso_ristretto";
                    menunumber = 30;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "에스프레소로 한 잔 주세요.";
                    menustring = "espresso";
                    break;
                }
                else
                {
                    text[1] = "에스프레소로 시지 않게 한 잔 주세요.";
                    menustring = "espresso_lungo";
                    menunumber = 31;
                    break;
                }

            case 2:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "시원한 카라멜 마끼아또로 한 잔 주세요. 쓰지 않게 해서 주세요.";
                    menustring = "caramel_macchiato_ice_ristretto";
                    menunumber = 32;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "카라멜 마끼아또로 한 잔 주세요.";
                    menustring = "caramel_macchiato_ice";
                    break;
                }
                else
                {
                    text[1] = "시원한 카라멜 마끼아또로 한 잔 주세요. 시지 않게 해서 주세요.";
                    menustring = "caramel_macchiato_ice_lungo";
                    menunumber = 33;
                    break;
                }
            case 3:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "따뜻한 카라멜 마끼아또로 한 잔 주세요. 쓰지 않게 해서 주세요.";
                    menustring = "caramel_macchiato_hot_ristretto";
                    menunumber = 34;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "따뜻한 카라멜 마끼아또로 한 잔 주세요.";
                    menustring = "caramel_macchiato_hot";
                    break;
                }
                else
                {
                    text[1] = "따뜻한 카라멜 마끼아또로 한 잔 주세요. 시지 않게 해서 주세요.";
                    menustring = "caramel_macchiato_hot_lungo";
                    menunumber = 35;
                    break;
                }
            case 4:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "따뜻한 아메리카노로 한 잔 주세요. 쓰지 않게 해서 주세요.";
                    menustring = "americano_hot_ristretto";
                    menunumber = 38;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "따뜻한 아메리카노로 한 잔 주세요.";
                    menustring = "americano_hot";
                    break;
                }
                else
                {
                    text[1] = "따뜻한 아메리카노로 한 잔 주세요. 시지 않게 해서 주세요.";
                    menustring = "americano_hot_lungo";
                    menunumber = 39;
                    break;
                }
            case 5:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "아이스 아메리카노로 한 잔 주세요. 쓰지 않게 해서 주세요.";
                    menustring = "americano_ice_ristretto";
                    menunumber = 36;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "아이스 아메리카노로 한 잔 주세요.";
                    menustring = "americano_ice";
                    break;
                }
                else
                {
                    text[1] = "아이스 아메리카노로 한 잔 주세요. 시지 않게 해서 주세요.";
                    menustring = "americano_ice_lungo";
                    menunumber = 37;
                    break;
                }
            case 6:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "아이스 카페모카로 한 잔 주세요. 쓰지 않게 해서 주세요.";
                    menustring = "caffe_mocha_ice_ristretto";
                    menunumber = 40;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "아이스 카페모카로 한 잔 주세요.";
                    menustring = "caffe_mocha_ice";
                    break;
                }
                else
                {
                    text[1] = "아이스 카페모카로 한 잔 주세요. 시지 않게 해서 주세요.";
                    menustring = "caffe_mocha_ice_lungo";
                    menunumber = 41;
                    break;
                }
            case 7:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "따뜻한 카페모카로 한 잔 주세요. 쓰지 않게 해서 주세요.";
                    menustring = "caffe_mocha_hot_ristretto";
                    menunumber = 42;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "따뜻한 카페모카로 한 잔 주세요.";
                    menustring = "caffe_mocha_hot";
                    break;
                }
                else
                {
                    text[1] = "따뜻한 카페모카로 한 잔 주세요. 시지 않게 해서 주세요.";
                    menustring = "caffe_mocha_hot_lungo";
                    menunumber = 43;
                    break;
                }
            case 8:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "에스프레소 콘 파냐로 한 잔 주세요. 쓰지 않게 해서 주세요.";
                    menustring = "espresso_con_panna_ristretto";
                    menunumber = 44;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "에스프레소 콘 파냐로 한 잔 주세요.";
                    menustring = "espresso_con_panna";
                    break;
                }
                else
                {
                    text[1] = "에스프레소 콘 파냐로 한 잔 주세요. 시지 않게 해서 주세요.";
                    menustring = "espresso_con_panna_lungo";
                    menunumber = 45;
                    break;
                }
            case 9:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "에스프레소 마끼아또로 한 잔 주세요. 쓰지 않게 해서 주세요.";
                    menustring = "espresso_macchiato_ristretto";
                    menunumber = 46;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "에스프레소 마끼아또로 한 잔 주세요.";
                    menustring = "espresso_macchiato";
                    break;
                }
                else
                {
                    text[1] = "에스프레소 마끼아또로 한 잔 주세요. 시지 않게 해서 주세요.";
                    menustring = "espresso_macchiato_lungo";
                    menunumber = 47;
                    break;
                }
            case 10:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "카푸치노로 한 잔 주세요. 쓰지 않게 해서 주세요.";
                    menustring = "cappuccino_ristretto";
                    menunumber = 48;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "카푸치노로 한 잔 주세요.";
                    menustring = "cappuccino";
                    break;
                }
                else
                {
                    text[1] = "카푸치노로 한 잔 주세요. 시지 않게 해서 주세요.";
                    menustring = "cappuccino_lungo";
                    menunumber = 49;
                    break;
                }
            case 11:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "따뜻한 바닐라 라떼로 한 잔 주세요. 쓰지 않게 해서 주세요.";
                    menustring = "vanilla_latte_hot_ristretto";
                    menunumber = 50;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "따뜻한 바닐라 라떼로 한 잔 주세요.";
                    menustring = "vanilla_latte_hot";
                    break;
                }
                else
                {
                    text[1] = "따뜻한 바닐라 라떼로 한 잔 주세요. 시지 않게 해서 주세요.";
                    menustring = "vanilla_latte_hot_lungo";
                    menunumber = 51;
                    break;
                }
            case 12:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "따뜻한 바닐라 라떼로 한 잔 주세요. 쓰지 않게 해서 주세요.";
                    menustring = "vanilla_latte_ice_ristretto";
                    menunumber = 52;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "따뜻한 바닐라 라떼로 한 잔 주세요.";
                    menustring = "vanilla_latte_ice";
                    break;
                }
                else
                {
                    text[1] = "따뜻한 바닐라 라떼로 한 잔 주세요. 시지 않게 해서 주세요.";
                    menustring = "vanilla_latte_ice_lungo";
                    menunumber = 53;
                    break;
                }
            case 13:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "따뜻한 카페 라떼로 한 잔 주세요. 쓰지 않게 해서 주세요.";
                    menustring = "caffe_latte_hot_ristretto";
                    menunumber = 54;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "따뜻한 카페 라떼로 한 잔 주세요.";
                    menustring = "caffe_latte_hot";
                    break;
                }
                else
                {
                    text[1] = "따뜻한 카페 라떼로 한 잔 주세요. 시지 않게 해서 주세요.";
                    menustring = "caffe_latte_hot_lungo";
                    menunumber = 55;
                    break;
                }
            case 14:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "시원한 카페 라떼로 한 잔 주세요. 쓰지 않게 해서 주세요.";
                    menustring = "caffe_latte_ice_ristretto";
                    menunumber = 56;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "시원한 카페 라떼로 한 잔 주세요.";
                    menustring = "caffe_latte_ice";
                    break;
                }
                else
                {
                    text[1] = "시원한 카페 라떼로 한 잔 주세요. 시지 않게 해서 주세요.";
                    menustring = "caffe_latte_ice_lungo";
                    menunumber = 57;
                    break;
                }
            case 15:
                text[1] = "아이스 녹차 라떼로 한 잔 주세요.";
                menustring = "greentea_latte_ice";
                break;
            case 16:
                text[1] = "따뜻한 녹차 라떼로 한 잔 주세요.";
                menustring = "greentea_latte_hot ";
                break;
            case 17:
                text[1] = "딸기 라떼로 한 잔 주세요.";
                menustring = "strawberry_latte ";
                break;
            case 18:
                text[1] = "따뜻한 쵸코로 한 잔 주세요.";
                menustring = "hot_chocolate";
                break;
            case 19:
                text[1] = "시원한 쵸코로 한 잔 주세요.";
                menustring = "ice_chocolate ";
                break;
            case 20:
                text[1] = "요거트 스무디로 한 잔 주세요.";
                menustring = "yogurt_smoothie ";
                break;
            case 21:
                text[1] = "녹차 스무디로 한 잔 주세요.";
                menustring = "greentea_smoothie";
                break;
            case 22:
                text[1] = "딸기 스무디로 한 잔 주세요.";
                menustring = "strawberry_smoothie ";
                break;
            case 23:
                text[1] = "요거트 펄로 한 잔 주세요.";
                menustring = "yogurt_pearl ";
                break;
            case 24:
                text[1] = "녹차 펄로 한 잔 주세요.";
                menustring = "greentea_pearl ";
                break;
            case 25:
                text[1] = "딸기 펄 음료 한 잔 주세요.";
                menustring = "strawberry_pearl ";
                break;
            case 26:
                b = Random.Range(1, 100);
                if (0 <= b && b < 15)
                {
                    text[1] = "에스프레소 프라푸치노로 한 잔 주세요. 쓰지 않게 해서 주세요.";
                    menustring = "espresso_frapp_ristretto";
                    menunumber = 58;
                    break;
                }
                else if (15 <= b && b < 85)
                {
                    text[1] = "에스프레소 프라푸치노로 한 잔 주세요.";
                    menustring = "espresso_frapp";
                    break;
                }
                else
                {
                    text[1] = "에스프레소 프라푸치노로 한 잔 주세요. 시지 않게 해서 주세요.";
                    menustring = "espresso_frapp_lungo";
                    menunumber = 59;
                    break;
                }
            case 27:
                text[1] = "녹차 프라푸치노 한 잔 주세요.";
                menustring = "greentea_frapp";
                break;
            case 28:
                text[1] = "딸기 프라푸치노 한 잔 주세요.";
                menustring = "strawberry_frapp";
                break;
            case 29:
                text[1] = "쵸코 프라푸치노 한 잔 주세요.";
                menustring = "chocolate_frapp";
                break;

        }




    }

    void LoadCustomerSprite()
    {
        int i = Random.Range(1, 24);
        CustomerSprite.sprite = Resources.Load<Sprite>("CustomerSprites/손님" + i);
        CustomerSprite.gameObject.SetActive(true);
    }

    void LoadEmotionSprite(int customertoken)
    {
        switch (customertoken)
        {
            case 1:
                RealEmotionSprite.sprite = Resources.Load<Sprite>("EmotionSprites/행복");
                break;
            case 2:
                RealEmotionSprite.sprite = Resources.Load<Sprite>("EmotionSprites/사랑");
                break;
            case 3:
                RealEmotionSprite.sprite = Resources.Load<Sprite>("EmotionSprites/기대");
                break;
            case 4:
                RealEmotionSprite.sprite = Resources.Load<Sprite>("EmotionSprites/평온");
                break;
            case 5:
                RealEmotionSprite.sprite = Resources.Load<Sprite>("EmotionSprites/슬픔");
                break;
            case 6:
                RealEmotionSprite.sprite = Resources.Load<Sprite>("EmotionSprites/분노");
                break;
            case 7:
                RealEmotionSprite.sprite = Resources.Load<Sprite>("EmotionSprites/피로");
                break;
            case 8:
                RealEmotionSprite.sprite = Resources.Load<Sprite>("EmotionSprites/공포");
                break;

        }
        RealEmotionSprite.gameObject.SetActive(true);
    }


    public void ResetNumberOfCustomer()
    {
        numberOfCustomer = 0;
        return;
    }

    public void ClickAgentButton()
    {
        if (!isActive)
        {
            return;
        }

        if (numberOfCustomer != recentClick)
        {
            recentClick = numberOfCustomer;
            AgentButtonCount++;
        }

    }
}
